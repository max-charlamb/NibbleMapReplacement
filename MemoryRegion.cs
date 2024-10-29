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
        Debug.Assert(offset + 4 <= Data.Length, $"{address} - {BaseAddress} = {offset} <= {Data.Length} goes out of bounds");

        return BitConverter.ToUInt32(Data, offset);
    }

    public unsafe void WriteDWord(ulong address, uint value)
    {
        Debug.Assert(address >= BaseAddress, "Address is below the base address");
        int offset = (int)(address - BaseAddress);
        Debug.Assert(offset + 4 <= Data.Length, $"{address} - {BaseAddress} = {offset} <= {Data.Length} goes out of bounds");

        byte* bytes = (byte*)&value;

        for(int i = 0; i < 4; i++)
        {
            Data[offset + i] = bytes[i];
        }
    }

    public void WriteToFile()
    {
        var path = @"C:\Users\maxcharlamb\OneDrive - Microsoft\Desktop\out.txt";
        File.WriteAllText(path, ToString());
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 4; i < Data.Length; i += 4)
        {
            sb.Append(Convert.ToHexString(Data, i - 1, 1));
            sb.Append(Convert.ToHexString(Data, i - 2, 1));
            sb.Append(Convert.ToHexString(Data, i - 3, 1));
            sb.Append(Convert.ToHexString(Data, i - 4, 1));

            if ((i) % 16 == 0)
            {
                sb.AppendLine();
            } else
            {
                sb.Append(' ');
            }
        }
        return sb.ToString();
    }
}

