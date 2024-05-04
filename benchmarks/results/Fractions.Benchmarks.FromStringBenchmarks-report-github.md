```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]             : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 8.0           : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9232.0), X64 RyuJIT VectorSize=256


```
| Method                | Job                | Runtime            | invalidString        | validString          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|---------------------- |------------------- |------------------- |--------------------- |--------------------- |------------:|---------:|---------:|-------:|----------:|
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | ****                     | **?**                    |    **32.16 ns** | **0.304 ns** | **0.284 ns** | **0.0081** |     **136 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 |                      | ?                    |   123.03 ns | 1.264 ns | 1.182 ns | 0.0610 |     385 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **-1**                   |    **60.50 ns** | **0.400 ns** | **0.374 ns** | **0.0081** |     **136 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | -1                   |   191.76 ns | 1.852 ns | 1.732 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **-1/5**                 |    **98.79 ns** | **0.819 ns** | **0.766 ns** | **0.0181** |     **304 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | -1/5                 |   199.26 ns | 1.588 ns | 1.485 ns | 0.0610 |     385 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **-10242048/**           | **?**                    |    **86.54 ns** | **0.817 ns** | **0.724 ns** | **0.0172** |     **288 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | -10242048/           | ?                    |   426.30 ns | 1.573 ns | 1.471 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **-3.5**                 |    **79.19 ns** | **0.486 ns** | **0.406 ns** | **0.0100** |     **168 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | -3.5                 |   349.30 ns | 2.129 ns | 1.992 ns | 0.0787 |     497 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **0**                    |    **57.50 ns** | **0.446 ns** | **0.417 ns** | **0.0081** |     **136 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 0                    |   160.82 ns | 1.124 ns | 1.051 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **1**                    |    **59.75 ns** | **0.278 ns** | **0.247 ns** | **0.0081** |     **136 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 1                    |   191.25 ns | 1.319 ns | 1.169 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **1.234(...)67890 [21]** |   **303.05 ns** | **1.305 ns** | **1.157 ns** | **0.0257** |     **432 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 1.234(...)67890 [21] | 1,694.03 ns | 8.369 ns | 6.988 ns | 0.2556 |    1613 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **1.234(...)7890f [22]** | **?**                    |   **101.26 ns** | **1.050 ns** | **0.982 ns** | **0.0181** |     **304 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | 1.234(...)7890f [22] | ?                    |   241.97 ns | 0.758 ns | 0.672 ns | 0.1197 |     754 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **1/5**                  |    **93.78 ns** | **0.817 ns** | **0.765 ns** | **0.0176** |     **296 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 1/5                  |   197.88 ns | 0.825 ns | 0.731 ns | 0.0610 |     385 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **10242048**             |    **77.34 ns** | **0.217 ns** | **0.181 ns** | **0.0081** |     **136 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 10242048             |   474.95 ns | 3.166 ns | 2.961 ns | 0.0663 |     417 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **3.5**                  |    **79.82 ns** | **0.354 ns** | **0.331 ns** | **0.0100** |     **168 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 3.5                  |   333.29 ns | 1.649 ns | 1.377 ns | 0.0787 |     497 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **invalid**              | **?**                    |    **38.08 ns** | **0.421 ns** | **0.394 ns** | **0.0081** |     **136 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | invalid              | ?                    |   145.76 ns | 1.339 ns | 1.187 ns | 0.0663 |     417 B |
