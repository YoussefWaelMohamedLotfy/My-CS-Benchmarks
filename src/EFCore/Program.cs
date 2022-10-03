using BenchmarkDotNet.Running;
using EFCore.Benchmarks;

BenchmarkRunner.Run<DbContextBenchmarks>();
