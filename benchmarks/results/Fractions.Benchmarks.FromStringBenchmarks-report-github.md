```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4170/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.202
  [Host]   : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                | invalidString        | validString          | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------- |--------------------- |--------------------- |----------:|----------:|---------:|-------:|----------:|
| **TryParseInvalidString** | ****                     | **?**                    |  **25.56 ns** |  **9.329 ns** | **0.511 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**   | **?**                    | **-1**                   |  **55.19 ns** |  **7.987 ns** | **0.438 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**   | **?**                    | **-1/5**                 |  **98.22 ns** | **28.841 ns** | **1.581 ns** | **0.0181** |     **304 B** |
| **TryParseInvalidString** | **-10242048/**           | **?**                    |  **88.97 ns** | **27.235 ns** | **1.493 ns** | **0.0172** |     **288 B** |
| **TryParseValidString**   | **?**                    | **-3.5**                 |  **94.33 ns** | **25.173 ns** | **1.380 ns** | **0.0143** |     **240 B** |
| **TryParseValidString**   | **?**                    | **0**                    |  **52.23 ns** | **14.984 ns** | **0.821 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**   | **?**                    | **1**                    |  **57.02 ns** | **10.939 ns** | **0.600 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**   | **?**                    | **1.234(...)67890 [21]** | **284.26 ns** | **88.149 ns** | **4.832 ns** | **0.0219** |     **368 B** |
| **TryParseInvalidString** | **1.234(...)7890f [22]** | **?**                    |  **69.54 ns** | **24.148 ns** | **1.324 ns** | **0.0019** |      **32 B** |
| **TryParseValidString**   | **?**                    | **1/5**                  |  **98.51 ns** |  **5.826 ns** | **0.319 ns** | **0.0176** |     **296 B** |
| **TryParseValidString**   | **?**                    | **10242048**             |  **72.15 ns** |  **5.655 ns** | **0.310 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**   | **?**                    | **3.5**                  |  **96.59 ns** | **30.307 ns** | **1.661 ns** | **0.0143** |     **240 B** |
| **TryParseInvalidString** | **invalid**              | **?**                    |  **31.25 ns** |  **0.504 ns** | **0.028 ns** | **0.0081** |     **136 B** |
