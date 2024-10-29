using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibbleMapReplacement;

public class ThingA
{
    List<ThingB> things;

    public ThingA()
    {
        things = new List<ThingB>();
        for(int i = 0; i < 10; i++)
        {
            try
            {
                things.Add(new ThingB());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}

public class ThingB
{
    List<ThingC> things;

    public ThingB()
    {
        things = new List<ThingC>();
        for (int i = 0; i < 10; i++)
        {
            things.Add(new ThingC());
        }
    }
}

public class ThingC
{
    public static void MaybeThrow()
    {
        if (Random.Shared.NextDouble() >= 0.2)
        {
            throw new InvalidOperationException();
        }
    }
    public ThingC()
    {
        MaybeThrow();
    }
}


