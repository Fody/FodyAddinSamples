using System;
using NUnit.Framework;
using System.Diagnostics;

[TestFixture]
public class ArraySlicesSample
{
    void ReduceStepWithArrays(double[] array, int length)
    {
        var size = length/2;
        for (var i = 0; i < size; i++)
        {
            array[i] = array[i] + array[size + i];
        }
    }

    double ReduceWithArrays(double[] array)
    {
        var watch = new Stopwatch();
        watch.Start();

        var length = array.Length;
        do
        {
            ReduceStepWithArrays(array, length);
            length /= 2;
        } while (length > 1);

        watch.Stop();
        Console.WriteLine(string.Format("Reduced with Arrays: '{0}' elements in {1}ms.", array.Length, watch.ElapsedMilliseconds));

        return array[0];
    }

    void ReduceStepWithSlices(ArraySlice<double> first, ArraySlice<double> second)
    {
        var length = first.Length;
        for (var i = 0; i < length; i++)
        {
            first[i] = first[i] + second[i];
        }
    }

    double ReduceWithSlices(ArraySlice<double> array)
    {
        var watch = new Stopwatch();
        watch.Start();

        var length = array.Length;
        do
        {
            var size = length/2;
            ReduceStepWithSlices(new ArraySlice<double>(array.Array, 0, size), new ArraySlice<double>(array.Array, size, size));
            length /= 2;
        } while (length > 1);

        watch.Stop();
        Console.WriteLine(string.Format("Reduced with ArraySlice: '{0}' elements in {1}ms.", array.Length, watch.ElapsedMilliseconds));

        return array[0];
    }

    void ReduceRecursiveStepWithSlices(ArraySlice<double> first, ArraySlice<double> second)
    {
        var length = first.Length;
        if (length > 1)
        {
            for (var i = 0; i < length; i++)
            {
                first[i] = first[i] + second[i];
            }

            var size = length/2;
            ReduceRecursiveStepWithSlices(new ArraySlice<double>(first, 0, size), new ArraySlice<double>(first, size, size));
        }
        else
        {
            first[0] = first[0] + second[0];
        }
    }

    double ReduceRecursiveWithSlices(ArraySlice<double> array)
    {
        var watch = new Stopwatch();
        watch.Start();

        var size = array.Length/2;
        ReduceRecursiveStepWithSlices(new ArraySlice<double>(array, 0, size), new ArraySlice<double>(array, size, size));

        watch.Stop();

        Console.WriteLine(string.Format("Reduced with ArraySlice-Recursive: '{0}' elements in {1}ms.", array.Length, watch.ElapsedMilliseconds));
        return array[0];
    }

    [ArraySliceDoNotOptimize]
    void ReduceStepWithSlicesNoOptimization(ArraySlice<double> first, ArraySlice<double> second)
    {
        var length = first.Length;
        for (var i = 0; i < length; i++)
        {
            first[i] = first[i] + second[i];
        }
    }

    [ArraySliceDoNotOptimize]
    double ReduceWithSlicesNoOptimization(ArraySlice<double> array)
    {
        var watch = new Stopwatch();
        watch.Start();

        var length = array.Length;
        do
        {
            var size = length/2;
            ReduceStepWithSlicesNoOptimization(new ArraySlice<double>(array.Array, 0, size), new ArraySlice<double>(array.Array, size, size));
            length /= 2;
        } while (length > 1);

        watch.Stop();
        Console.WriteLine(string.Format("Reduced with unoptimized ArraySlice: '{0}' elements in {1}ms.", array.Length, watch.ElapsedMilliseconds));

        return array[0];
    }

    [Test]
    public void Run()
    {
        var data = new double[1024*4096];

        for (var i = 0; i < data.Length; i++)
        {
            data[i] = 1;
        }
        var withArrays = ReduceWithArrays(data);

        for (var i = 0; i < data.Length; i++)
        {
            data[i] = 1;
        }
        var withSlices = ReduceWithSlices(data);

        for (var i = 0; i < data.Length; i++)
        {
            data[i] = 1;
        }
        var withRecursiveSlices = ReduceRecursiveWithSlices(data);

        for (var i = 0; i < data.Length; i++)
        {
            data[i] = 1;
        }
        var withSlicesWithoutOptimization = ReduceWithSlicesNoOptimization(data);

        Assert.AreEqual(withArrays, withSlices);
        Assert.AreEqual(withSlices, withRecursiveSlices);
        Assert.AreEqual(withSlices, withSlicesWithoutOptimization);

        Console.WriteLine("Timings are not representative when run in debug mode or under tests.");
    }
}
