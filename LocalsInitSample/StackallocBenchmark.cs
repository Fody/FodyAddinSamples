using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using LocalsInit;

[InProcess]
public unsafe class StackallocBenchmark
{
	const int BufferSize = 4096;

	[Benchmark(Baseline = true)]
	[LocalsInit(true)]
	public void LocalsInitTrue()
	{
		var ptr = stackalloc byte[BufferSize];
		Consume(ptr);
	}

	[Benchmark]
	[LocalsInit(false)]
	public void LocalsInitFalse()
	{
		var ptr = stackalloc byte[BufferSize];
		Consume(ptr);
	}

	[SuppressMessage("ReSharper", "UnusedParameter.Local")]
	[MethodImpl(MethodImplOptions.NoInlining)]
	static void Consume(void* _)
	{
	}
}