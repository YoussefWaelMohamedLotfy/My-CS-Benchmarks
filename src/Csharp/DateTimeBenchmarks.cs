using BenchmarkDotNet.Attributes;

namespace Csharp;

[MemoryDiagnoser]
public class DateTimeBenchmarks
{
    [Benchmark(Baseline = true)]
    public DateTimeOffset DateTimeOffset_UtcNow() => DateTimeOffset.UtcNow;

    [Benchmark]
    public DateTimeOffset DateTimeOffset_Now() => DateTimeOffset.Now;

    [Benchmark]
    public DateTimeOffset DateTime_UtcNow() => DateTime.UtcNow;

    [Benchmark]
    public DateTimeOffset DateTime_Now() => DateTime.Now;
}