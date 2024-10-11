using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NibbleMapReplacement.tests;

public class MemoryRegionTest
{
    [Fact]
    public void ReadWriteTest()
    {
        MemoryRegion m = new(100);

        Assert.Equal(0u, m.ReadDWord(0));

        m.WriteDWord(0, 100);
        Assert.Equal(100u, m.ReadDWord(0));

        Console.WriteLine(m);
    }
}

