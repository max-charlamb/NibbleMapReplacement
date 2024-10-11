using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NibbleMapReplacement.Constants;

namespace NibbleMapReplacement;
public class NewNibbleMap : INibbleMap
{
    public readonly MemoryRegion memoryRegion;

    private readonly ulong codeRegionStart;
    private readonly ulong codeRegionSize;

    public const ulong mapBase = 0x00001000;

    private NewNibbleMap(ulong codeRegionStart, ulong codeRegionSize)
    {
        this.codeRegionStart = codeRegionStart;
        this.codeRegionSize = codeRegionSize;

        uint mapBytesNeeded = (uint)((codeRegionSize + 63) / 64);
        uint mapDwordsNeeded = (mapBytesNeeded + 3) / 4;

        memoryRegion = new(mapBase, mapDwordsNeeded * 4);
    }

    // We load the map contents as 32-bit integers, which contains 8 4-bit nibbles.
    // The algorithm will focus on each nibble in a map unit before moving on to the previous map unit
    internal readonly struct MapUnit
    {
        public enum DWordState
        {
            Empty,
            Nibbles,
            Pointer
        }

        public const int SizeInBytes = sizeof(uint);
        public const ulong SizeInNibbles = 2 * SizeInBytes;
        public readonly uint Value;

        public MapUnit(uint value) => Value = value;

        public static implicit operator uint(MapUnit m) => m.Value;
        public static implicit operator MapUnit(uint i) => new MapUnit(i);

        public override string ToString() => $"0x{Value:x}";

        // Shift the next nibble into the least significant position.
        public MapUnit ShiftNextNibble => new MapUnit(Value >>> 4);

        public const uint NibbleMask = 0x0Fu;
        internal Nibble Nibble => new((int)(Value & NibbleMask));

        public DWordState State 
        { 
            get {
                if(Value == 0) return DWordState.Empty;
                
                Nibble nib0 = GetNibble(0);

                // If nib0 is greater than or equal to 8, implies pointer.
                if (nib0.IsEmpty || nib0.Value < 8)
                {
                    return DWordState.Nibbles;
                } 
                else
                {
                    return DWordState.Pointer;
                }
            } 
        } 

        public bool IsZero => Value == 0;


        public Nibble GetNibble(byte i) => GetNibble(new MapKey(i));

        public Nibble GetNibble(MapKey mapIdx)
        {
            int shift = mapIdx.GetNibbleShift();
            return new Nibble((int)(Value >>> shift) & 0xF);
        }

        public MapUnit WriteNibble(byte i, byte value) => WriteNibble(new MapKey(i), value);

        public MapUnit WriteNibble(MapKey mapIdx, uint value)
        {
            Debug.Assert(value >= 0 && value < 15, "Nibble value out of bounds");
            uint mask = ~(0xFu << mapIdx.GetNibbleShift());
            uint nibble = (value + 1) << mapIdx.GetNibbleShift();

            uint newValue = (Value & mask) | nibble;
            return new MapUnit(newValue);
        }

        public uint GetPointer()
        {
            uint nibble = GetNibble(0).Value;

            return (Value & ~0xFu) + ((nibble - 8) << 2);
        }

        public static MapUnit WriteDirectPointer(uint pointer)
        {
            uint top28 = pointer & ~0xFu;
            uint bottom4 = ((pointer & 0xFu) >>> 2) + 8 + 1;
            return new MapUnit(top28 + bottom4);
        }
    }

    // Each nibble is a 4-bit integer that gives an offset within a bucket.
    // We reserse 0 to mean that there is no method starting at any offset within a bucket
    internal readonly struct Nibble
    {
        public readonly uint RawValue;

        public Nibble(int value)
        {
            Debug.Assert(value >= 0 && value <= 0xF, "Nibble value out of bounds");
            RawValue = (uint)value;
        }

        public static Nibble Zero => new Nibble(0);
        public bool IsEmpty => RawValue == 0;

        public uint Value => !IsEmpty ? RawValue - 1 : throw new InvalidOperationException("This nibble is empty");

        public ulong TargetByteOffset
        {
            get
            {
                Debug.Assert(RawValue != 0, "Can not get target byte offset when nibble is uninitialized");
                return (uint)(RawValue - 1) * MapUnit.SizeInBytes;
            }
        }
    }

    // The key to the map is the index of an individual nibble
    internal readonly struct MapKey
    {
        private readonly ulong MapIdx;
        public MapKey(ulong mapIdx) => MapIdx = mapIdx;
        public override string ToString() => $"0x{MapIdx:x}";

        // The offset of the address in the target space that this map index represents
        public ulong TargetByteOffset => MapIdx * BytesPerBucket;

        // The index of the map unit that contains this map index
        public ulong ContainingMapUnitIndex => MapIdx / MapUnit.SizeInNibbles;

        // The offset of the map unit that contains this map index
        public ulong ContainingMapUnitByteOffset => ContainingMapUnitIndex * MapUnit.SizeInBytes;

        // The map index is the index of a nibble within the map, this gives the index of that nibble within a map unit.
        public int NibbleIndexInMapUnit => (int)(MapIdx & (MapUnit.SizeInNibbles - 1));

        // go to the previous nibble
        public MapKey Prev => new MapKey(MapIdx - 1);

        // to to the previous map unit
        public MapKey PrevMapUnit => new MapKey(MapIdx - MapUnit.SizeInNibbles);

        // Get a MapKey that is aligned to the first nibble in the map unit that contains this map index
        public MapKey AlignDownToMapUnit() => new MapKey(MapIdx & (~(MapUnit.SizeInNibbles - 1)));

        // If the map index is less than the size of a map unit, we are in the first MapUnit and
        // can stop searching
        public bool InFirstMapUnit => MapIdx < MapUnit.SizeInNibbles;

        public bool IsZero => MapIdx == 0;

        // given the index of a nibble in the map, compute how much we have to shift a MapUnit to put that
        // nibble in the least significant position.
        internal int GetNibbleShift()
        {
            return NibbleIndexInMapUnit * 4;  // bit shift - 4 bits per nibble
        }
    }

    private static ulong MapToRelativeAddress(ulong dwordIndex, ulong nibbleIndex, ulong nibbleValue) =>
        dwordIndex * 256 + nibbleIndex * 32 + nibbleValue * 4;

    public static uint PointerToDword(uint pointer)
    {
        uint top28 = pointer & ~0xFu;
        uint bottom4 = ((pointer & 0xFu) >>> 2) + 8 + 1;
        return new MapUnit(top28 + bottom4);
    }

    public static INibbleMap Create(ulong codeRegionStart, ulong codeRegionSize)
        => new NewNibbleMap(codeRegionStart, codeRegionSize);

    public void AllocateCodeChunk(ulong codeStart, uint codeSize)
    {
        // paraphrased from EEJitManager::NibbleMapSetUnlocked
        if (codeStart < codeRegionStart)
        {
            throw new ArgumentException("Code start address is below the map base");
        }
        if(codeStart + codeSize > codeRegionStart + codeRegionSize)
        {
            throw new ArgumentException("Code end is above the code map end");
        }

        ulong delta = codeStart - codeRegionStart;

        ulong lastMethodData = delta + codeSize;

        ulong dwordIndex = delta / 256;
        ulong nibbleIndex = (delta / 32) % 8;
        int nibbleShift = (int)(nibbleIndex * 4);

        MapUnit oldValue = memoryRegion.ReadDWord(mapBase + dwordIndex * sizeof(uint));

        // write initial nibble

        // ensure not overwritting existing
        // TODO: also assert that the dword is not a pointer
        Debug.Assert((oldValue & (0xFul << nibbleShift)) == 0, "Overwriting existing nibble");
        Debug.Assert(oldValue.State != MapUnit.DWordState.Pointer, "Overwriting existing pointer");

        // some value between 1 - 8
        uint nibbleValue = (uint)(delta % 32u / 4u) + 1;
        uint newValue = oldValue | nibbleValue << nibbleShift;

        memoryRegion.WriteDWord(mapBase + dwordIndex * sizeof(uint), newValue);

        // if the function completely covers the following dwords, write the relative pointer
        uint pointer = PointerToDword((uint)delta);
        ulong nextDwordIndex = dwordIndex + 2;
        while (nextDwordIndex * 256 <= lastMethodData)
        {
            ulong dwordToWrite = nextDwordIndex - 1;
            memoryRegion.WriteDWord(mapBase + dwordToWrite * sizeof(uint), pointer);
            nextDwordIndex++;
        }
    }

    public ulong FindMethodCode(ulong currentPC)
    {
        // dword offset * 256 + nibble index * 32 + nibble value * 4
        ulong delta = currentPC - codeRegionStart;
        ulong dwordIndex = delta / 256;
        ulong nibbleIndex = (delta / 32) % 8;

        // #1 look up DWORD representing current PC
        MapUnit dword = memoryRegion.ReadDWord(mapBase + dwordIndex * sizeof(uint));

        // #2 if DWORD is a pointer, then we are done
        if(dword.State is MapUnit.DWordState.Pointer)
        {
            return dword.GetPointer() + codeRegionStart;
        }

        // #3 if DWORD is nibbles and corresponding nibble is intialized, return the corresponding address
        // TODO: fix to check if the mapped value preceeds the currentPC
        if(dword.State is MapUnit.DWordState.Nibbles)
        {
            Nibble nib = dword.GetNibble((byte)nibbleIndex);
            if (!nib.IsEmpty)
            {
                ulong codeStart = dwordIndex * 256 + nibbleIndex * 32 + nib.Value * 4 + codeRegionStart;
                if (codeStart <= currentPC) return codeStart;
            }
        }

        // #4 find preceeding nibble and return if found
        // TODO: get rid of loop using CLZ
        if(nibbleIndex != 0)
        {
            uint maskNibbleAndHigher = (~0x0u >>> (32 - (int)nibbleIndex * 4));
            uint clz = uint.LeadingZeroCount(dword.Value & maskNibbleAndHigher);
            if(clz != 32)
            {
                uint firstSetBitPos = 31 - clz;
                uint nibbleToCheck = firstSetBitPos / 4;
                Nibble nib = dword.GetNibble((byte)nibbleToCheck);
                if (!nib.IsEmpty)
                {
                    return dwordIndex * 256ul + nibbleToCheck * 32 + nib.Value * 4 + codeRegionStart;
                }
            }
        }

        // #5 repeat steps 1, 2, and 4 for the previous DWORD
        // no preceeding DWORD, return null pointer
        if (dwordIndex == 0) return 0;
        dwordIndex--;
        nibbleIndex = 7;

        // #5.1
        dword = memoryRegion.ReadDWord(mapBase + dwordIndex * sizeof(uint));

        // #5.2 if DWORD is a pointer, then we are done
        if (dword.State is MapUnit.DWordState.Pointer)
        {
            return dword.GetPointer() + codeRegionStart;
        }

        // #5.4 find preceeding nibble and return if found
        // Since we want to check the entire DWORD, no need to mask
        if (dword != 0)
        {
            uint clz = uint.LeadingZeroCount(dword.Value);
            uint firstSetBitPos = 31 - clz;
            uint nibbleToCheck = firstSetBitPos / 4;
            Nibble nib = dword.GetNibble((byte)nibbleToCheck);
            if (!nib.IsEmpty)
            {
                return dwordIndex * 256ul + nibbleToCheck * 32 + nib.Value * 4 + codeRegionStart;
            }
        }

        return 0;
    }

    public void DeleteMethodCode(ulong codeHeader)
    {
        if (codeHeader < codeRegionStart)
        {
            throw new ArgumentException("Code start address is below the map base");
        }
        if (codeHeader > codeRegionStart + codeRegionSize)
        {
            throw new ArgumentException("Code start address is above the code map end");
        }

        ulong delta = codeHeader - codeRegionStart;

        ulong dwordIndex = delta / 256;
        ulong nibbleIndex = (delta / 32) % 8;
        int nibbleShift = (int)(nibbleIndex * 4);

        MapUnit dword = memoryRegion.ReadDWord(mapBase + dwordIndex * sizeof(uint));
        Debug.Assert(dword.State == MapUnit.DWordState.Nibbles, "Code header pointing to DWORD not representing Nibbles");

        Nibble nib = dword.GetNibble((byte)nibbleIndex);
        Debug.Assert(!nib.IsEmpty, "Code header pointing to nibble which is not initialized");

        // some value between 1 - 8
        uint nibbleValue = (uint)(delta % 32u / 4u) + 1;
        uint newValue = dword & ~(0xFu << nibbleShift);

        memoryRegion.WriteDWord(mapBase + dwordIndex * sizeof(uint), newValue);

        // remove following pointers
        ulong nextDwordIndex = dwordIndex + 1;

        while(((int)nextDwordIndex + 1) * sizeof(uint) <= memoryRegion.Data.Length)
        {
            dword = memoryRegion.ReadDWord(mapBase + nextDwordIndex * sizeof(uint));
            if(dword.State == MapUnit.DWordState.Pointer)
            {
                // Clear pointer
                memoryRegion.WriteDWord(mapBase + nextDwordIndex * sizeof(uint), 0x0u);

                nextDwordIndex++;
            } else
            {
                return;
            }
        }

    }

    public override string ToString()
    {
        return memoryRegion.ToString();
    }
}
