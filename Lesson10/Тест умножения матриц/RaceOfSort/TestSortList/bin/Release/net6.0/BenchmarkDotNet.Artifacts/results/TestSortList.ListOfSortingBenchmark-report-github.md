``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22631
11th Gen Intel Core i9-11900K 3.50GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.200
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT


```
|                Method |       Mean |    Error |   StdDev | Rank | Allocated |
|---------------------- |-----------:|---------:|---------:|-----:|----------:|
|         TestSerialMul | 2,705.3 ms | 49.01 ms | 61.98 ms |    2 |     16 KB |
| TestParallelMulThread |   335.1 ms |  6.39 ms |  9.57 ms |    1 |      2 KB |
|   TestParallelMulTask |   336.8 ms |  6.42 ms |  7.13 ms |    1 |      9 KB |
