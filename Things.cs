using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public bool t = false;
    public void MaybeThrow()
    {
        if (Random.Shared.NextDouble() >= 0.2)
        {
            //Console.ReadLine();
            Console.WriteLine(f(2));
            throw new InvalidOperationException();
        }
    }
    public ThingC()
    {
        MaybeThrow();
    }

    public int f(int i)
    {
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (t) { Console.WriteLine("Hello World"); }
        if (i == 0) { return new StackTrace(false).FrameCount; }
        return f(i - 1);
    }
}


