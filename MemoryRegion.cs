using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbleMapReplacement;
public class MemoryRegion
{
    public byte[] Data;
    public ulong BaseAddress;

    public MemoryRegion(uint size) : this(0, size) { }
    public MemoryRegion(ulong baseAddress, uint size)
    {
        Data = new byte[size];
        BaseAddress = baseAddress;
    }

    public uint ReadDWord(ulong address)
    {
        Debug.Assert(address >= BaseAddress, "Address is below the base address");
        int offset = (int)(address - BaseAddress);
        Debug.Assert(offset + 4 <= Data.Length, "DWORD goes out of bounds");

        return BitConverter.ToUInt32(Data, offset);
    }

    public unsafe void WriteDWord(ulong address, uint value)
    {
        Debug.Assert(address >= BaseAddress, "Address is below the base address");
        int offset = (int)(address - BaseAddress);
        Debug.Assert(offset + 4 <= Data.Length, "DWORD goes out of bounds");

        byte* bytes = (byte*)&value;

        for(int i = 0; i < 4; i++)
        {
            Data[offset + i] = bytes[i];
        }
    }

    public override string ToString()
    {
        return BitConverter.ToString(Data);
    }
}

