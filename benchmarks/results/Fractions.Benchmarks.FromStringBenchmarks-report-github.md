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
| **TryParseInvalidString**       | ****                     | **?**                    | **?**        | **?**        |  **29.79 ns** |  **1.586 ns** | **0.087 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **-1**                   | **?**        | **?**        |  **59.58 ns** |  **1.655 ns** | **0.091 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **-1/5**                 | **?**        | **?**        | **100.34 ns** | **10.656 ns** | **0.584 ns** | **0.0181** |     **304 B** |
| **TryParseInvalidString**       | **-10242048/**           | **?**                    | **?**        | **?**        |  **87.61 ns** | **15.921 ns** | **0.873 ns** | **0.0172** |     **288 B** |
| **TryParseValidString**         | **?**                    | **-3.5**                 | **?**        | **?**        |  **79.25 ns** |  **7.358 ns** | **0.403 ns** | **0.0100** |     **168 B** |
| **TryParseValidString**         | **?**                    | **0**                    | **?**        | **?**        |  **56.23 ns** |  **2.869 ns** | **0.157 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **1**                    | **?**        | **?**        |  **60.12 ns** |  **3.006 ns** | **0.165 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **1.234(...)67890 [21]** | **?**        | **?**        | **300.63 ns** | **55.489 ns** | **3.042 ns** | **0.0257** |     **432 B** |
| **TryParseInvalidString**       | **1.234(...)7890f [22]** | **?**                    | **?**        | **?**        | **100.15 ns** | **10.868 ns** | **0.596 ns** | **0.0181** |     **304 B** |
| **TryParseValidString**         | **?**                    | **1/5**                  | **?**        | **?**        |  **96.92 ns** |  **2.996 ns** | **0.164 ns** | **0.0176** |     **296 B** |
| **TryParseValidString**         | **?**                    | **10242048**             | **?**        | **?**        |  **78.70 ns** |  **2.369 ns** | **0.130 ns** | **0.0081** |     **136 B** |
| **TryParseValidString**         | **?**                    | **3.5**                  | **?**        | **?**        |  **78.66 ns** | **13.180 ns** | **0.722 ns** | **0.0100** |     **168 B** |
| **TryParseInvalidReadOnlySpan** | **?**                    | **?**                    | **Char[0]**  | **?**        |  **38.01 ns** |  **6.839 ns** | **0.375 ns** | **0.0086** |     **144 B** |
| **TryParseInvalidReadOnlySpan** | **?**                    | **?**                    | **Char[10]** | **?**        |  **85.86 ns** |  **5.992 ns** | **0.328 ns** | **0.0148** |     **248 B** |
| **TryParseInvalidReadOnlySpan** | **?**                    | **?**                    | **Char[22]** | **?**        | **107.93 ns** | **17.865 ns** | **0.979 ns** | **0.0186** |     **312 B** |
| **TryParseInvalidReadOnlySpan** | **?**                    | **?**                    | **Char[7]**  | **?**        |  **41.22 ns** |  **7.284 ns** | **0.399 ns** | **0.0086** |     **144 B** |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[1]**  |  **63.63 ns** |  **3.545 ns** | **0.194 ns** | **0.0086** |     **144 B** |
| TryParseValidReadOnlySpan   | ?                    | ?                    | ?        | Char[1]  |  60.39 ns |  2.563 ns | 0.141 ns | 0.0086 |     144 B |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[21]** | **315.80 ns** | **24.460 ns** | **1.341 ns** | **0.0262** |     **440 B** |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[2]**  |  **64.34 ns** |  **1.276 ns** | **0.070 ns** | **0.0086** |     **144 B** |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[3]**  |  **83.33 ns** |  **2.917 ns** | **0.160 ns** | **0.0105** |     **176 B** |
| TryParseValidReadOnlySpan   | ?                    | ?                    | ?        | Char[3]  |  87.30 ns | 21.200 ns | 1.162 ns | 0.0148 |     248 B |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[4]**  |  **93.25 ns** |  **8.730 ns** | **0.479 ns** | **0.0105** |     **176 B** |
| TryParseValidReadOnlySpan   | ?                    | ?                    | ?        | Char[4]  |  91.53 ns |  6.185 ns | 0.339 ns | 0.0148 |     248 B |
| **TryParseValidReadOnlySpan**   | **?**                    | **?**                    | **?**        | **Char[8]**  |  **86.49 ns** |  **6.839 ns** | **0.375 ns** | **0.0086** |     **144 B** |
| **TryParseInvalidString**       | **invalid**              | **?**                    | **?**        | **?**        |  **38.74 ns** |  **6.956 ns** | **0.381 ns** | **0.0081** |     **136 B** |
