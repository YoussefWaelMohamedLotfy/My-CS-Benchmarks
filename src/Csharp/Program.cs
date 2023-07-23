using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Csharp;
using Elastic.CommonSchema.BenchmarkDotNetExporter;

var options = new ElasticsearchBenchmarkExporterOptions("http://localhost:9200")
{
    GitBranch = "externally-provided-branch",
    GitCommitMessage = "externally provided git commit message",
    GitRepositoryIdentifier = "repository",
};

var exporter = new ElasticsearchBenchmarkExporter(options);
var config = DefaultConfig.Instance.AddExporter(exporter);
BenchmarkRunner.Run<StringConcatenationBenchmarks>(config);
