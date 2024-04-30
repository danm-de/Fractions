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
| **TryParseInvalidString**       | ****                     | **?**                    |  **30.16 ns** | **10.181 ns** | **0.558 ns** | **0.0081** |     **136 B** |
| TryParseInvalidReadOnlySpan |                      | ?                    |  34.11 ns |  9.915 ns | 0.543 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **-1**                   |  **65.85 ns** | **13.104 ns** | **0.718 ns** | **0.0081** |     **136 B** |
| TryParseValidReadOnlySpan   | ?                    | -1                   |  68.53 ns |  0.869 ns | 0.048 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **-1/5**                 |  **98.35 ns** | **19.496 ns** | **1.069 ns** | **0.0181** |     **304 B** |
| TryParseValidReadOnlySpan   | ?                    | -1/5                 |  88.75 ns | 44.429 ns | 2.435 ns | 0.0148 |     248 B |
| **TryParseInvalidString**       | **-10242048/**           | **?**                    |  **87.28 ns** |  **9.407 ns** | **0.516 ns** | **0.0172** |     **288 B** |
| TryParseInvalidReadOnlySpan | -10242048/           | ?                    |  85.75 ns | 12.145 ns | 0.666 ns | 0.0148 |     248 B |
| **TryParseValidString**         | **?**                    | **-3.5**                 |  **80.54 ns** |  **0.783 ns** | **0.043 ns** | **0.0100** |     **168 B** |
| TryParseValidReadOnlySpan   | ?                    | -3.5                 |  84.17 ns |  6.115 ns | 0.335 ns | 0.0105 |     176 B |
| **TryParseValidString**         | **?**                    | **0**                    |  **57.20 ns** |  **2.581 ns** | **0.141 ns** | **0.0081** |     **136 B** |
| TryParseValidReadOnlySpan   | ?                    | 0                    |  59.97 ns |  6.146 ns | 0.337 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **1**                    |  **61.28 ns** | **11.467 ns** | **0.629 ns** | **0.0081** |     **136 B** |
| TryParseValidReadOnlySpan   | ?                    | 1                    |  65.91 ns | 16.230 ns | 0.890 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **1.234(...)67890 [21]** | **305.22 ns** |  **7.346 ns** | **0.403 ns** | **0.0257** |     **432 B** |
| TryParseValidReadOnlySpan   | ?                    | 1.234(...)67890 [21] | 319.84 ns | 17.511 ns | 0.960 ns | 0.0262 |     440 B |
| **TryParseInvalidString**       | **1.234(...)7890f [22]** | **?**                    |  **96.46 ns** |  **4.093 ns** | **0.224 ns** | **0.0181** |     **304 B** |
| TryParseInvalidReadOnlySpan | 1.234(...)7890f [22] | ?                    | 102.53 ns | 27.203 ns | 1.491 ns | 0.0186 |     312 B |
| **TryParseValidString**         | **?**                    | **1/5**                  |  **99.21 ns** |  **9.211 ns** | **0.505 ns** | **0.0176** |     **296 B** |
| TryParseValidReadOnlySpan   | ?                    | 1/5                  |  87.73 ns | 18.454 ns | 1.012 ns | 0.0148 |     248 B |
| **TryParseValidString**         | **?**                    | **10242048**             |  **77.85 ns** | **10.199 ns** | **0.559 ns** | **0.0081** |     **136 B** |
| TryParseValidReadOnlySpan   | ?                    | 10242048             |  83.15 ns | 13.706 ns | 0.751 ns | 0.0086 |     144 B |
| **TryParseValidString**         | **?**                    | **3.5**                  |  **79.67 ns** |  **6.357 ns** | **0.348 ns** | **0.0100** |     **168 B** |
| TryParseValidReadOnlySpan   | ?                    | 3.5                  |  85.15 ns | 14.436 ns | 0.791 ns | 0.0105 |     176 B |
| **TryParseInvalidString**       | **invalid**              | **?**                    |  **39.70 ns** | **12.264 ns** | **0.672 ns** | **0.0081** |     **136 B** |
| TryParseInvalidReadOnlySpan | invalid              | ?                    |  41.05 ns |  9.943 ns | 0.545 ns | 0.0086 |     144 B |
