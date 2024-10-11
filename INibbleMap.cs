using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbleMapReplacement;

public interface INibbleMap
{
    public static abstract INibbleMap Create(ulong codeRegionStart, ulong codeRegionSize);

    public void AllocateCodeChunk(ulong codeStart, uint codeSize);

    public ulong FindMethodCode(ulong currentPC);

    public void DeleteMethodCode(ulong codeHeader);
}

