using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

[TestFixture]
public class AsyncErrorHandlerSample
{
    private void ReduceStepWithArrays(double[] array, int lenght)
    {
        int size = lenght / 2;
        for (int i = 0; i < size; i++)
            array[i] = array[i] + array[size + i];
    }

    protected double ReduceWithArrays(double[] array)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        int lenght = array.Length;
        do
        {
            ReduceStepWithArrays(array, lenght);
            lenght /= 2;
        }
        while (lenght > 1);

        watch.Stop();
        Console.WriteLine(string.Format("Reduced with Arrays: '{0}' elements in {1}ms.", array.Length, watch.ElapsedMilliseconds));

        return array[0];
    }

    private void ReduceStepWithSlices(ArraySlice<double> first, ArraySlice<double> second)
    {
        int length = first.Length;
        for (int i = 0; i < length; i++)
            first[i] = first[i] + second[i];
    }

    protected double ReduceWithSlices(ArraySlice<double> array)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        int lenght = array.Length;
        do
        {
            var size = lenght / 2;
            ReduceStepWithSlices(new ArraySlice<double>(array.Array, 0, size), new ArraySlice<double>(array.Array, size, size));
            lenght /= 2;
        }
        while (lenght > 1);

        watch.Stop();
        Console.WriteLine(string.Format("Reduced with ArraySlice: '{0}' elements in {1}ms.", array.Length, watch.ElapsedMilliseconds));

        return array[0];
    }

    private void ReduceRecursiveStepWithSlices(ArraySlice<double> first, ArraySlice<double> second)
    {
        int length = first.Length;
        if (length > 1)
        {
            for (int i = 0; i < length; i++)
                first[i] = first[i] + second[i];

            var size = length / 2;
            ReduceRecursiveStepWithSlices(new ArraySlice<double>(first, 0, size), new ArraySlice<double>(first, size, size));
        }
        else
        {
            first[0] = first[0] + second[0];
        }
    }

    protected double ReduceRecursiveWithSlices(ArraySlice<double> array)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        var size = array.Length / 2;
        ReduceRecursiveStepWithSlices(new ArraySlice<double>(array, 0, size), new ArraySlice<double>(array, size, size));

        watch.Stop();

        Console.WriteLine(string.Format("Reduced with ArraySlice-Recursive: '{0}' elements in {1}ms.", array.Length, watch.ElapsedMilliseconds));
        return array[0];
    }

    [ArraySliceBehavior(OptimizationMode.None)]
    private void ReduceStepWithSlicesNoOptimization(ArraySlice<double> first, ArraySlice<double> second)
    {
        int length = first.Length;
        for (int i = 0; i < length; i++)
            first[i] = first[i] + second[i];
    }

    [ArraySliceBehavior(OptimizationMode.None)]
    protected double ReduceWithSlicesNoOptimization(ArraySlice<double> array)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        int lenght = array.Length;
        do
        {
            var size = lenght / 2;
            ReduceStepWithSlicesNoOptimization(new ArraySlice<double>(array.Array, 0, size), new ArraySlice<double>(array.Array, size, size));
            lenght /= 2;
        }
        while (lenght > 1);

        watch.Stop();
        Console.WriteLine(string.Format("Reduced with unoptimized ArraySlice: '{0}' elements in {1}ms.", array.Length, watch.ElapsedMilliseconds));

        return array[0];
    }

    [Test]
    public void Run()
    {
        double[] data = new double[1024 * 4096];

        for (int i = 0; i < data.Length; i++)
            data[i] = 1;
        var withArrays = ReduceWithArrays(data);

        for (int i = 0; i < data.Length; i++)
            data[i] = 1;
        double withSlices = ReduceWithSlices(data);

        for (int i = 0; i < data.Length; i++)
            data[i] = 1;
        double withRecursiveSlices = ReduceRecursiveWithSlices(data);

        for (int i = 0; i < data.Length; i++)
            data[i] = 1;
        double withSlicesWithoutOptimization = ReduceWithSlicesNoOptimization(data);

        Assert.AreEqual(withArrays, withSlices);
        Assert.AreEqual(withSlices, withRecursiveSlices);
        Assert.AreEqual(withSlices, withSlicesWithoutOptimization);

        Console.WriteLine("Timings are not representative when run in debug mode or under tests.");
    }
}
