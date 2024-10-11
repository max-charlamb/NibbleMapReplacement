using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using static NibbleMapReplacement.NewNibbleMap;

namespace NibbleMapReplacement.tests;

public class NewNibbleMapTest
{
    [Fact]
    public void TestDirectPointer()
    {
        List<uint> ints = [0, uint.MaxValue - 3, 0x1000];
        foreach (uint i in ints)
        {
            MapUnit t = MapUnit.WriteDirectPointer(i);

            t.State.Should().Be(MapUnit.DWordState.Pointer, $"test value: {i}");

            t.GetPointer().Should().Be(i, $"test value: {i}");
        }
    }

    [Fact]
    public void BasicWrite()
    {
        NewNibbleMap nibbleMap = (NewNibbleMap)NewNibbleMap.Create(0x0000_1000, 2000);

        Console.WriteLine(nibbleMap);

        nibbleMap.AllocateCodeChunk(0x0000_1004, 513);

        Console.WriteLine(nibbleMap);

        MapUnit v = nibbleMap.memoryRegion.ReadDWord(NewNibbleMap.mapBase + 4);
        Console.WriteLine(v.GetPointer());

        Console.WriteLine(nibbleMap.FindMethodCode(0x1148));
    }
}

