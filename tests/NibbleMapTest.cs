﻿using FluentAssertions;
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
    record FunctionBlock(ulong codeStart, uint size);

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

    [Fact]
    public void SetThenDelete()
    {
        ulong codeRegionBase = 0x0000_1000;
        uint size = 1024;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        List<FunctionBlock> blocks = [];
        blocks.Add(new(codeRegionBase, 39));
        blocks.Add(new(codeRegionBase + 40, 32));
        blocks.Add(new(codeRegionBase + 100, 512));

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.AllocateCodeChunk(block.codeStart, block.size);
        }

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.DeleteMethodCode(block.codeStart);
        }

        foreach (FunctionBlock block in blocks)
        {
            for (ulong i = 0; i < block.size; i++)
            {
                ulong actualMethodCode = nibbleMap.FindMethodCode(block.codeStart + i);
                actualMethodCode.Should().Be(0, $"search value: {block.codeStart + i}, Function starts at {block.codeStart} with size {block.size}");
            }
        }
    }

    [Fact]
    public void SetDeleteSet()
    {
        ulong codeRegionBase = 0x0000_1000;
        uint size = 1024;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        List<FunctionBlock> blocks = [];
        blocks.Add(new(codeRegionBase, 39));
        blocks.Add(new(codeRegionBase + 40, 32));
        blocks.Add(new(codeRegionBase + 100, 512));

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.AllocateCodeChunk(block.codeStart, block.size);
        }

        nibbleMap.DeleteMethodCode(blocks[1].codeStart);
        blocks.RemoveAt(1);

        foreach (FunctionBlock block in blocks)
        {
            for (ulong i = 0; i < block.size; i++)
            {
                ulong actualMethodCode = nibbleMap.FindMethodCode(block.codeStart + i);
                actualMethodCode.Should().Be(block.codeStart, $"search value: {block.codeStart + i}, Function starts at {block.codeStart} with size {block.size}");
            }
        }
    }

    [Fact]
    public void ThumbBit()
    {
        ulong codeRegionBase = 0x0000_1000;
        uint size = 1024;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        List<FunctionBlock> blocks = [];
        blocks.Add(new(codeRegionBase + 3, 508));
        blocks.Add(new(codeRegionBase + 508, 32));

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.AllocateCodeChunk(block.codeStart, block.size);
        }

        foreach (FunctionBlock block in blocks)
        {
            for (ulong i = 0; i < block.size; i++)
            {
                ulong actualCodeStart = block.codeStart & ~0b11u;
                ulong actualMethodCode = nibbleMap.FindMethodCode(actualCodeStart + i);
                actualMethodCode.Should().Be(actualCodeStart, $"search value: {actualCodeStart + i}, Function starts at {actualCodeStart} with size {block.size}");
            }
        }
    }

    [Fact]
    public void FullLengthMethod()
    {
        ulong codeRegionBase = 0x0000_1000;
        uint size = 1024;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        List<FunctionBlock> blocks = [];
        blocks.Add(new(codeRegionBase, 1024));

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.AllocateCodeChunk(block.codeStart, block.size);
        }

        foreach (FunctionBlock block in blocks)
        {
            for (ulong i = 0; i < block.size; i++)
            {
                ulong actualMethodCode = nibbleMap.FindMethodCode(block.codeStart + i);
                actualMethodCode.Should().Be(block.codeStart, $"search value: {block.codeStart + i}, Function starts at {block.codeStart} with size {block.size}");
            }
        }

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.DeleteMethodCode(block.codeStart);
        }

        foreach (FunctionBlock block in blocks)
        {
            for (ulong i = 0; i < block.size; i++)
            {
                ulong actualMethodCode = nibbleMap.FindMethodCode(block.codeStart + i);
                actualMethodCode.Should().Be(0, $"search value: {block.codeStart + i}, Function starts at {block.codeStart} with size {block.size}");
            }
        }
    }

    public void RandomizedNibbleWrite()
    {
        ulong codeRegionBase = 0x0000_0000;
        uint size = 0x10000;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        int lastRelativeFuncPosition = 0;
        List<FunctionBlock> blocks = [];

        while(lastRelativeFuncPosition < size)
        {
            int funcSize = Random.Shared.Next(1000) + 1;
            int relativeAddress = lastRelativeFuncPosition + Random.Shared.Next(1000);
            relativeAddress = (relativeAddress >>> 2 << 2) + 4; // 4-byte align
            if(relativeAddress + funcSize < size)
            {
                blocks.Add(new(codeRegionBase + (ulong)relativeAddress, (uint)funcSize));
            }
            int padding = (int)Math.Max(0, ((relativeAddress + 32) & ~31) - (relativeAddress + funcSize));
            lastRelativeFuncPosition = relativeAddress + funcSize + padding;
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

    [Fact]
    public void SampleTest()
    {
        ulong codeRegionBase = 0x7f3b56900000;
        uint size = 0x3ffe0;

        INibbleMap nibbleMap = T.Create(codeRegionBase, size);

        List<FunctionBlock> blocks = [];
        blocks.Add(new(0x00007f3b5691bdb0, 336));

        foreach (FunctionBlock block in blocks)
        {
            nibbleMap.AllocateCodeChunk(block.codeStart, block.size);
        }

        foreach (FunctionBlock block in blocks)
        {
            for (ulong i = 0; i < 499; i++)
            {
                ulong actualCodeStart = block.codeStart & ~0b11ul;
                ulong actualMethodCode = nibbleMap.FindMethodCode(actualCodeStart + i);
                actualMethodCode.Should().Be(actualCodeStart, $"search value: {actualCodeStart + i}, Function starts at {actualCodeStart} with size {block.size}");
            }
        }
    }
}

public class OriginalNibbleMapTest : NibbleMapTest<NibbleMap> { }
public class OptimizedNibbleMapTest : NibbleMapTest<NewNibbleMap> { }
