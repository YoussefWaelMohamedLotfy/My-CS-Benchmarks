using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Csharp;

[MemoryDiagnoser(false)]
public class LoopBenchmarks
{
    private static readonly Random randomRange = new(420);

    [Params(100, 100_000, 1_000_000)]
    public int Size { get; set; }

    private List<int> _items;

    [GlobalSetup]
    public void Setup()
    {
        _items = Enumerable.Range(1, Size).Select(x => randomRange.Next()).ToList();
    }

    [Benchmark]
    public void ForLoop()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            var item = _items[i];
        }
    }

    [Benchmark]
    public void ForeachLoop()
    {
        foreach (var item in _items)
        {
        }
    }

    [Benchmark]
    public void Foreach_Linq()
    {
        _items.ForEach(item => { });
    }

    [Benchmark]
    public void ParallelForEach()
    {
        Parallel.ForEach(_items, i => { });
    }

    [Benchmark]
    public void Parallel_Linq()
    {
        _items.AsParallel().ForAll(i => { });
    }

    [Benchmark]
    public void ForLoop_Span()
    {
        var span = CollectionsMarshal.AsSpan(_items);

        for (int i = 0; i < span.Length; i++)
        {
            var item = span[i];
        }
    }

    [Benchmark]
    public void ForeachLoop_Span()
    {
        foreach (int item in CollectionsMarshal.AsSpan(_items))
        {
        }
    }
}
