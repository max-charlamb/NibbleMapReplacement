using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NibbleMapReplacement;

class Program
{
    static void Main(string[] args)
    {
        C1 c = new();

        c.M6();
    }
}

unsafe class C1
{
    public void M1()
    {
        try
        {
            Block();
        }
        catch
        {
        }
    }

    public void M2()
    {
        try
        {
            throw new Exception();
        }
        catch
        {
            Block();
        }
    }

    public void M3()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception e) when (F1(e))
        {

        }
    }

    public void M4()
    {
        try
        {
            Console.ReadLine();
            throw new Exception();
        }
        catch (Exception e) when (F2(e))
        {

        }
    }

    public void M5()
    {
        var handle = GCHandle.Alloc(this);
        var fptr = (delegate* unmanaged<IntPtr, int, void>)&U1;
        fptr(GCHandle.ToIntPtr(handle), 4);
        handle.Free();
    }

    public void M6()
    {
        var m1 = typeof(C1).GetMethod("M5");
        m1.Invoke(this, null);
    }

    public void M7()
    {
        P1();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void P1()
    {
        try
        {
            try
            {
                P2();
            }
            finally
            {
                P3();
            }
        }
        catch
        {
            Block();
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void P2()
    {
        throw new Exception();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void P3()
    {
        throw new Exception();
    }

    [UnmanagedCallersOnly]
    private static void U1(IntPtr ptr, int method)
    {
        var c = (C1)GCHandle.FromIntPtr(ptr).Target;
        switch (method)
        {
            case 1: c.M1(); break;
            case 2: c.M2(); break;
            case 3: c.M3(); break;
            case 4: c.M4(); break;
            case 5: c.M5(); break;
            case 6: c.M6(); break;
            case 7: c.M7(); break;
        }
    }

    private bool F1(Exception e)
    {
        Block();
        throw new NotImplementedException();
    }

    private bool F2(Exception e)
    {
        M2();
        throw new NotImplementedException();
    }

    public void Block()
    {
        Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        Console.ReadLine();
    }
}