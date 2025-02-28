using System;
using System.Runtime;
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

        //Task.Run(c.M1);
        //Task.Run(c.M2);
        //Task.Run(c.M3);
        //Task.Run(c.M4);
        //Task.Run(c.M5);
        //Task.Run(c.M6);
        //Task.Run(c.M7);

        //c.Block();

        //c.Block();
        //c.M6();

        //HijackTest hijack = new();
        //hijack.Test();

        //FaultingExceptionTest fef = new();
        //fef.TestLoop();

        RedirectedThreadFrame rtf = new();
        rtf.Test();
    }
}

class RedirectedThreadFrame
{
    public volatile bool flag;
    public volatile int num;

    public RedirectedThreadFrame()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public void Test()
    {
        // sxe clr
        Console.ReadLine();
        var cts = new CancellationTokenSource();
        cts.CancelAfter(500);
        ControlledExecution.Run(Work, cts.Token);

        while (!flag)
        {
            TestLoop();
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveOptimization)]
    public void TestLoop()
    {
        for (int i = 0; i < 20; i++)
        {
            num++;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public void Work()
    {
        try
        {
            while (!flag)
            {
                TestLoop();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}

class HijackTest
{
    public volatile bool flag;
    public volatile int num;

    public HijackTest()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public void Test()
    {
        // bu coreclr!ThreadSuspend::SuspendEE step out then look at the main thread.
        Console.ReadLine();

        Task.Run(Work);
        while (!flag)
        {
            TestLoop();
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveOptimization)]

    public void TestLoop()
    {
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
        num++;
    }


    public void Work()
    {
        Thread.Sleep(500);
        GC.Collect();
    }
}

class FaultingExceptionTest
{
    public volatile bool flag;
    public volatile int num;

    public FaultingExceptionTest()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public void Test()
    {
        // bu coreclr!ThrowControlForThread
        Console.ReadLine();
        var cts = new CancellationTokenSource();
        cts.CancelAfter(500);
        ControlledExecution.Run(Work, cts.Token);
        
        while (!flag)
        {
            TestLoop();
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveOptimization)]
    public void TestLoop()
    {
        for (int i = 0; i < 20; i++)
        {
            if (num > 10000)
            {
                Console.WriteLine("num is greater than 10000");
            }
            num++;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public void Work()
    {
        try
        {
            while (!flag)
            {
                TestLoop();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
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