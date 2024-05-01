```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]   : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method | FractionToRaise | Mean       | Error     | StdDev   | Gen0   | Allocated |
|------- |---------------- |-----------:|----------:|---------:|-------:|----------:|
| **Sqrt**   | **2/3**             | **1,387.2 ns** |  **54.77 ns** |  **3.00 ns** | **0.0381** |     **656 B** |
| **Sqrt**   | **2**               | **1,324.1 ns** |  **68.27 ns** |  **3.74 ns** | **0.0343** |     **592 B** |
| **Sqrt**   | **3**               | **1,391.1 ns** |  **16.00 ns** |  **0.88 ns** | **0.0420** |     **720 B** |
| **Sqrt**   | **1024**            |   **415.8 ns** | **182.95 ns** | **10.03 ns** | **0.0105** |     **176 B** |
