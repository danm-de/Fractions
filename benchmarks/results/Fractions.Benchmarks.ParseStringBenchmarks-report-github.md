```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4170/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.202
  [Host]   : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                | invalidString        | validString          | Mean     | Error     | StdDev   | Allocated |
|---------------------- |--------------------- |--------------------- |---------:|----------:|---------:|----------:|
| **TryParseInvalidString** | **-1**                   | **?**                    | **20.75 ns** |  **7.741 ns** | **0.424 ns** |         **-** |
| **TryParseValidString**   | **?**                    | **-1**                   | **22.05 ns** |  **0.384 ns** | **0.021 ns** |         **-** |
| **TryParseInvalidString** | **-3.5**                 | **?**                    | **21.41 ns** |  **7.954 ns** | **0.436 ns** |         **-** |
| **TryParseValidString**   | **?**                    | **-3.5**                 | **23.02 ns** |  **5.821 ns** | **0.319 ns** |         **-** |
| **TryParseInvalidString** | **0**                    | **?**                    | **21.18 ns** |  **0.724 ns** | **0.040 ns** |         **-** |
| **TryParseValidString**   | **?**                    | **0**                    | **21.58 ns** |  **6.064 ns** | **0.332 ns** |         **-** |
| **TryParseInvalidString** | **0.00123**              | **?**                    | **27.24 ns** |  **0.330 ns** | **0.018 ns** |         **-** |
| **TryParseValidString**   | **?**                    | **0.00123**              | **29.17 ns** | **10.252 ns** | **0.562 ns** |         **-** |
| **TryParseInvalidString** | **1**                    | **?**                    | **22.08 ns** |  **0.589 ns** | **0.032 ns** |         **-** |
| **TryParseValidString**   | **?**                    | **1**                    | **23.88 ns** |  **0.558 ns** | **0.031 ns** |         **-** |
| **TryParseInvalidString** | **1.234(...)67890 [21]** | **?**                    | **53.43 ns** |  **6.453 ns** | **0.354 ns** |         **-** |
| **TryParseValidString**   | **?**                    | **1.234(...)67890 [21]** | **57.67 ns** | **23.540 ns** | **1.290 ns** |         **-** |
| **TryParseInvalidString** | **10242048**             | **?**                    | **35.48 ns** |  **2.877 ns** | **0.158 ns** |         **-** |
| **TryParseValidString**   | **?**                    | **10242048**             | **35.08 ns** | **11.203 ns** | **0.614 ns** |         **-** |
| **TryParseInvalidString** | **3.5**                  | **?**                    | **22.93 ns** |  **6.723 ns** | **0.368 ns** |         **-** |
| **TryParseValidString**   | **?**                    | **3.5**                  | **25.29 ns** |  **0.209 ns** | **0.011 ns** |         **-** |
