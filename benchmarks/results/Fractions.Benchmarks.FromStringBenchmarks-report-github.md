```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]   : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                      | invalidString        | validString          | invalid  | valid    | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------------- |--------------------- |--------------------- |--------- |--------- |----------:|----------:|---------:|-------:|----------:|
| **TryParseInvalidString**       | ****                     | **?**                    | **?**        | **?**        |  **28.10 ns** |  **3.292 ns** | **0.180 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **-1**                   | **?**        | **?**        |  **56.78 ns** |  **6.630 ns** | **0.363 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **-1/5**                 | **?**        | **?**        |  **99.16 ns** | **11.952 ns** | **0.655 ns** | **0.0181** |     **304 B** |
| **TryParseInvalidString**       | **-10242048/**           | **?**                    | **?**        | **?**        |  **86.59 ns** |  **3.589 ns** | **0.197 ns** | **0.0172** |     **288 B** |
| **TryParseValidString**         | **?**                    | **-3.5**                 | **?**        | **?**        |  **83.28 ns** |  **7.260 ns** | **0.398 ns** | **0.0100** |     **168 B** |
| **TryParseValidString**         | **?**                    | **0**                    | **?**        | **?**        |  **51.24 ns** |  **7.062 ns** | **0.387 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **1**                    | **?**        | **?**        |  **53.97 ns** |  **2.777 ns** | **0.152 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **1.234(...)67890 [21]** | **?**        | **?**        | **308.90 ns** | **20.176 ns** | **1.106 ns** | **0.0257** |     **432 B** |
| **TryParseInvalidString**       | **1.234(...)7890f [22]** | **?**                    | **?**        | **?**        |  **93.91 ns** | **20.341 ns** | **1.115 ns** | **0.0181** |     **304 B** |
| **TryParseValidString**         | **?**                    | **1/5**                  | **?**        | **?**        |  **96.39 ns** | **12.141 ns** | **0.665 ns** | **0.0176** |     **296 B** |
| **TryParseValidString**         | **?**                    | **10242048**             | **?**        | **?**        |  **74.14 ns** |  **9.243 ns** | **0.507 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **3.5**                  | **?**        | **?**        |  **86.13 ns** |  **4.282 ns** | **0.235 ns** | **0.0100** |     **168 B** |
| **TryParseInvalidReadOnlySpan** | **?**                    | **?**                    | **Char[0]**  | **?**        |  **32.15 ns** |  **4.564 ns** | **0.250 ns** | **0.0086** |     **144 B** |
| **TryParseInvalidReadOnlySpan** | **?**                    | **?**                    | **Char[10]** | **?**        |  **83.34 ns** |  **6.022 ns** | **0.330 ns** | **0.0148** |     **248 B** |
| **TryParseInvalidReadOnlySpan** | **?**                    | **?**                    | **Char[22]** | **?**        | **101.45 ns** |  **1.808 ns** | **0.099 ns** | **0.0186** |     **312 B** |
| **TryParseInvalidReadOnlySpan** | **?**                    | **?**                    | **Char[7]**  | **?**        |  **38.80 ns** |  **0.760 ns** | **0.042 ns** | **0.0086** |     **144 B** |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[1]**  |  **58.61 ns** |  **2.416 ns** | **0.132 ns** | **0.0086** |     **144 B** |
| TryParseValidReadOnlySpan   | ?                    | ?                    | ?        | Char[1]  |  56.08 ns |  3.847 ns | 0.211 ns | 0.0086 |     144 B |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[21]** | **317.70 ns** | **36.392 ns** | **1.995 ns** | **0.0262** |     **440 B** |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[2]**  |  **60.42 ns** |  **4.449 ns** | **0.244 ns** | **0.0086** |     **144 B** |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[3]**  |  **90.07 ns** |  **1.191 ns** | **0.065 ns** | **0.0105** |     **176 B** |
| TryParseValidReadOnlySpan   | ?                    | ?                    | ?        | Char[3]  |  88.44 ns |  4.215 ns | 0.231 ns | 0.0148 |     248 B |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[4]**  |  **88.62 ns** |  **9.128 ns** | **0.500 ns** | **0.0105** |     **176 B** |
| TryParseValidReadOnlySpan   | ?                    | ?                    | ?        | Char[4]  |  89.37 ns |  6.602 ns | 0.362 ns | 0.0148 |     248 B |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[8]**  |  **76.03 ns** | **11.496 ns** | **0.630 ns** | **0.0086** |     **144 B** |
| **TryParseInvalidString**       | **invalid**              | **?**                    | **?**        | **?**        |  **36.84 ns** |  **0.283 ns** | **0.015 ns** | **0.0081** |     **136 B** |
