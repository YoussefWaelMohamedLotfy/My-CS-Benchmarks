﻿using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace Csharp;

[MemoryDiagnoser]
public class StringConcatenationBenchmarks
{
    private readonly ObjectPool<StringBuilder> _stringBuilderPool 
        = new DefaultObjectPoolProvider().CreateStringBuilderPool();

    private string testString;

    [GlobalSetup]
    public void Setup()
    {
        testString = "abcdefghijklmnopqrstuvwxyz0123456789";
    }

    [Benchmark(Baseline = true)]
    public void DefaultConcatenation()
    {
        string result = string.Empty;

        for (int i = 0; i < testString.Length; i++)
        {
            result += testString[i];
        }
    }

    [Benchmark]
    public void StringBuilder()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < testString.Length; i++)
        {
            sb.Append(testString[i]);
        }
    }

    [Benchmark]
    public void StringBuilder_Pool()
    {
        var sb = _stringBuilderPool.Get();

        for (int i = 0; i < testString.Length; i++)
        {
            sb.Append(testString[i]);
        }

        _stringBuilderPool.Return(sb);
    }
}
