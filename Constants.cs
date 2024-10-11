using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbleMapReplacement;
public static class Constants
{
    public static readonly ulong BytesPerBucket = 8 * sizeof(uint);

    public static readonly int Log2CodeAlign = 2; // N.B. this might be different on 64-bit in the future
    public static readonly int Log2NibblesPerDword = 3;
    public static readonly int Log2BytesPerBucket = Log2CodeAlign + Log2NibblesPerDword;
    public static readonly int Log2NibbleSize = 2;
    public static readonly int NibbleSize = 1 << Log2NibbleSize;
    public static readonly uint NibblesPerDword = (uint)((8 * sizeof(uint)) >> Log2NibbleSize);
    public static readonly uint NibblesPerDwordMask = NibblesPerDword - 1;

    public static readonly uint MaskBytesPerBucket = (uint)(BytesPerBucket - 1);

    public static readonly uint NibbleMask = 0xf;
    public static readonly int HighestNibbleBit = 32 - NibbleSize;

    public static readonly uint HighestNibbleMask = NibbleMask << HighestNibbleBit;

    public static ulong Addr2Pos(ulong addr)
    {
        return addr >> Log2BytesPerBucket;
    }

    public static uint Addr2Offs(ulong addr)
    {
        return (uint)(((addr & MaskBytesPerBucket) >> Log2CodeAlign) + 1);
    }

    public static int Pos2ShiftCount(ulong addr)
    {
        return HighestNibbleBit - (int)((addr & NibblesPerDwordMask) << Log2NibbleSize);
    }

}
