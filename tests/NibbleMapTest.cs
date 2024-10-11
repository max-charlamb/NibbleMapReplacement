using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Reflection.Metadata.BlobBuilder;

namespace NibbleMapReplacement.tests;

public abstract class NibbleMapTest<T>
    where T : class, INibbleMap
{
    [Fact]
    public void BasicNibbleWriteTest()
    {
        ulong codeRegionBase = 0x0000_0000;
        uint size = 1024;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        List<FunctionBlock> blocks = [];
        blocks.Add(new(codeRegionBase, 0x0));
        blocks.Add(new(codeRegionBase + 0x100, 32));

        Console.WriteLine(nibbleMap);

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.AllocateCodeChunk(block.codeStart, block.size);
        }

        Console.WriteLine(nibbleMap);

        foreach (FunctionBlock block in blocks)
        {
            ulong expectedMethodCode = block.codeStart;
            for (ulong i = 0; i < block.size; i++)
            {
                ulong actualMethodCode = nibbleMap.FindMethodCode(block.codeStart + i);
                actualMethodCode.Should().Be(expectedMethodCode, $"search value: {block.codeStart + i}, Function starts at {block.codeStart} with size {block.size}");
            }
        }
    }

    [Fact]
    public void CloseFunctionTest()
    {
        ulong codeRegionBase = 0x0000_0000;
        uint size = 1024;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        Console.WriteLine(nibbleMap);

        List<FunctionBlock> blocks = [];
        blocks.Add(new(codeRegionBase, 39));
        blocks.Add(new(codeRegionBase + 40, 32));

        Console.WriteLine(nibbleMap);

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.AllocateCodeChunk(block.codeStart, block.size);
        }

        foreach (FunctionBlock block in blocks)
        {
            //if (block.codeStart == 0) continue;
            ulong expectedMethodCode = block.codeStart;
            for (ulong i = 0; i < block.size; i++)
            {
                ulong actualMethodCode = nibbleMap.FindMethodCode(block.codeStart + i);
                actualMethodCode.Should().Be(expectedMethodCode, $"search value: {block.codeStart + i}, Function starts at {block.codeStart} with size {block.size}");
            }
        }
    }

    record FunctionBlock(ulong codeStart, uint size);

    [Fact]
    public void RandomizedNibbleWrite()
    {
        ulong codeRegionBase = 0x0000_0000;
        uint size = 0x1000;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        int lastRelativeFuncPosition = 0;
        List<FunctionBlock> blocks = [];

        while(lastRelativeFuncPosition < size)
        {
            int funcSize = Random.Shared.Next(1000);
            int relativeAddress = lastRelativeFuncPosition + Random.Shared.Next(1000);
            relativeAddress = (relativeAddress >>> 2 << 2) + 4; // 4-byte align
            if(relativeAddress + funcSize < size)
            {
                blocks.Add(new(codeRegionBase + (ulong)relativeAddress, (uint)funcSize));
            }
            lastRelativeFuncPosition = relativeAddress + funcSize;
        }

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.AllocateCodeChunk(block.codeStart, block.size);
        }

        foreach (FunctionBlock block in blocks)
        {
            ulong expectedMethodCode = block.codeStart;
            for (ulong i = 0; i < block.size; i++)
            {
                ulong actualMethodCode = nibbleMap.FindMethodCode(block.codeStart + i);
                actualMethodCode.Should().Be(expectedMethodCode, $"search value: {block.codeStart + i}, Function starts at {block.codeStart} with size {block.size}");
            }
        }
    }

    [Fact]
    public void RandomizedNibbleWriteTest()
    {
        for(int i = 0; i < 100; i++)
        {
            RandomizedNibbleWrite();
        }
    }
}

public class OriginalNibbleMapTest : NibbleMapTest<NibbleMap> { }
public class OptimizedNibbleMapTest : NibbleMapTest<NewNibbleMap> { }
