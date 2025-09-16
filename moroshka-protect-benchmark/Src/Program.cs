using BenchmarkDotNet.Running;
using Moroshka.Protect.Benchmark;

BenchmarkRunner.Run<Benchmark>();

/*
| Method           | Mean     | Error     | StdDev    | Rank | Gen0   | Allocated |
|----------------- |---------:|----------:|----------:|-----:|-------:|----------:|
| Protect_System   | 1.894 us | 0.0148 us | 0.0131 us |    2 | 0.0267 |     448 B |
| Protect_Moroshka | 1.810 us | 0.0148 us | 0.0139 us |    1 | 0.0267 |     448 B |
*/
