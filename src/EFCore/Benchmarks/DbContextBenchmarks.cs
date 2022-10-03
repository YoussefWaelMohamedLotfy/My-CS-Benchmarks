using BenchmarkDotNet.Attributes;
using EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.Benchmarks;

[MemoryDiagnoser]
public class DbContextBenchmarks
{
    private DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF-Benchmarks;Integrated Security=True;Connect Timeout=30")
        .Options;

    private PooledDbContextFactory<AppDbContext> _dbContextPoolingFactory;

    [GlobalSetup]
    public void Setup()
    {
        _dbContextPoolingFactory = new PooledDbContextFactory<AppDbContext>(options);
    }

    [Benchmark(Baseline = true)]
    public List<Person> GetAll_WithoutContextPooling()
    {
        using var context = new AppDbContext(options);
        return context.People.ToList();
    }

    [Benchmark]
    public List<Person> GetAll_WithoutContextPooling_AsNoTracking()
    {
        using var context = new AppDbContext(options);
        return context.People.AsNoTracking().ToList();
    }

    [Benchmark]
    public List<Person> GetAll_WithContextPooling()
    {
        using var context = _dbContextPoolingFactory.CreateDbContext();
        return context.People.ToList();
    }

    [Benchmark]
    public List<Person> GetAll_WithContextPooling_AsNoTracking()
    {
        using var context = _dbContextPoolingFactory.CreateDbContext();
        return context.People.AsNoTracking().ToList();
    }
}
