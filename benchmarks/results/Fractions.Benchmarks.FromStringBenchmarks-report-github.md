```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]   : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                      | invalidString        | validString          | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------------- |--------------------- |--------------------- |----------:|----------:|---------:|-------:|----------:|
| **TryParseInvalidString**       | ****                     | **?**                    |  **29.48 ns** |  **2.456 ns** | **0.135 ns** | **0.0081** |     **136 B** |
| TryParseInvalidReadOnlySpan |                      | ?                    |  33.93 ns |  4.411 ns | 0.242 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **-1**                   |  **56.36 ns** |  **3.310 ns** | **0.181 ns** | **0.0081** |     **136 B** |
| TryParseValidReadOnlySpan   | ?                    | -1                   |  60.22 ns |  2.503 ns | 0.137 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **-1/5**                 |  **96.34 ns** |  **7.234 ns** | **0.397 ns** | **0.0181** |     **304 B** |
| TryParseValidReadOnlySpan   | ?                    | -1/5                 |  88.55 ns | 20.557 ns | 1.127 ns | 0.0148 |     248 B |
| **TryParseInvalidString**       | **-10242048/**           | **?**                    |  **88.16 ns** |  **7.502 ns** | **0.411 ns** | **0.0172** |     **288 B** |
| TryParseInvalidReadOnlySpan | -10242048/           | ?                    |  85.39 ns |  7.891 ns | 0.433 ns | 0.0148 |     248 B |
| **TryParseValidString**         | **?**                    | **-3.5**                 |  **79.94 ns** | **14.519 ns** | **0.796 ns** | **0.0100** |     **168 B** |
| TryParseValidReadOnlySpan   | ?                    | -3.5                 |  84.49 ns | 27.339 ns | 1.499 ns | 0.0105 |     176 B |
| **TryParseValidString**         | **?**                    | **0**                    |  **52.81 ns** |  **9.045 ns** | **0.496 ns** | **0.0081** |     **136 B** |
| TryParseValidReadOnlySpan   | ?                    | 0                    |  58.10 ns | 10.521 ns | 0.577 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **1**                    |  **59.39 ns** |  **7.918 ns** | **0.434 ns** | **0.0081** |     **136 B** |
| TryParseValidReadOnlySpan   | ?                    | 1                    |  63.52 ns | 11.646 ns | 0.638 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **1.234(...)67890 [21]** | **310.55 ns** | **53.211 ns** | **2.917 ns** | **0.0257** |     **432 B** |
| TryParseValidReadOnlySpan   | ?                    | 1.234(...)67890 [21] | 328.02 ns | 90.127 ns | 4.940 ns | 0.0262 |     440 B |
| **TryParseInvalidString**       | **1.234(...)7890f [22]** | **?**                    |  **99.22 ns** | **11.087 ns** | **0.608 ns** | **0.0181** |     **304 B** |
| TryParseInvalidReadOnlySpan | 1.234(...)7890f [22] | ?                    | 110.23 ns | 25.623 ns | 1.404 ns | 0.0186 |     312 B |
| **TryParseValidString**         | **?**                    | **1/5**                  |  **98.17 ns** |  **6.198 ns** | **0.340 ns** | **0.0176** |     **296 B** |
| TryParseValidReadOnlySpan   | ?                    | 1/5                  |  85.42 ns |  3.685 ns | 0.202 ns | 0.0148 |     248 B |
| **TryParseValidString**         | **?**                    | **10242048**             |  **76.23 ns** | **24.176 ns** | **1.325 ns** | **0.0081** |     **136 B** |
| TryParseValidReadOnlySpan   | ?                    | 10242048             |  80.76 ns |  6.534 ns | 0.358 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **3.5**                  |  **83.27 ns** | **28.197 ns** | **1.546 ns** | **0.0100** |     **168 B** |
| TryParseValidReadOnlySpan   | ?                    | 3.5                  |  86.50 ns |  9.325 ns | 0.511 ns | 0.0105 |     176 B |
| **TryParseInvalidString**       | **invalid**              | **?**                    |  **38.63 ns** |  **9.891 ns** | **0.542 ns** | **0.0081** |     **136 B** |
| TryParseInvalidReadOnlySpan | invalid              | ?                    |  41.43 ns | 14.066 ns | 0.771 ns | 0.0086 |     144 B |
