```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]             : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 8.0           : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9232.0), X64 RyuJIT VectorSize=256


```
| Method                | Job                | Runtime            | invalidString        | validString          | Mean         | Error      | StdDev     | Gen0   | Allocated |
|---------------------- |------------------- |------------------- |--------------------- |--------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | ****                     | **?**                    |     **3.345 ns** |  **0.0227 ns** |  **0.0212 ns** |      **-** |         **-** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 |                      | ?                    |    14.225 ns |  0.0976 ns |  0.0913 ns |      - |         - |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **-1**                   |    **57.852 ns** |  **0.5626 ns** |  **0.5262 ns** | **0.0086** |     **144 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | -1                   |   122.959 ns |  1.0664 ns |  0.9975 ns | 0.0370 |     233 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **-1/5**                 |    **88.455 ns** |  **0.5880 ns** |  **0.5501 ns** | **0.0148** |     **248 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | -1/5                 |   198.595 ns |  0.6160 ns |  0.5461 ns | 0.0610 |     385 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **-10242048/**           | **?**                    |    **84.137 ns** |  **0.7511 ns** |  **0.7026 ns** | **0.0148** |     **248 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | -10242048/           | ?                    |   426.828 ns |  1.7457 ns |  1.5476 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **-3.5**                 |   **101.180 ns** |  **0.7106 ns** |  **0.6647 ns** | **0.0129** |     **216 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | -3.5                 |   321.658 ns |  2.9962 ns |  2.6560 ns | 0.0482 |     305 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **0**                    |    **44.087 ns** |  **0.3582 ns** |  **0.3351 ns** | **0.0062** |     **104 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 0                    |    70.681 ns |  0.6145 ns |  0.5447 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **1**                    |    **42.968 ns** |  **0.2609 ns** |  **0.2440 ns** | **0.0062** |     **104 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 1                    |    98.378 ns |  0.3744 ns |  0.3503 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **1.234(...)67890 [21]** |   **322.732 ns** |  **1.7210 ns** |  **1.6098 ns** | **0.0286** |     **480 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 1.234(...)67890 [21] | 1,657.941 ns | 11.6836 ns | 10.9288 ns | 0.2251 |    1420 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **1.234(...)7890f [22]** | **?**                    |    **28.973 ns** |  **0.2281 ns** |  **0.2134 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | 1.234(...)7890f [22] | ?                    |    45.321 ns |  0.1405 ns |  0.1246 ns | 0.0280 |     177 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **1/5**                  |    **87.047 ns** |  **0.5250 ns** |  **0.4654 ns** | **0.0148** |     **248 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 1/5                  |   199.466 ns |  0.6251 ns |  0.5542 ns | 0.0610 |     385 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **10242048**             |    **91.197 ns** |  **0.5182 ns** |  **0.4847 ns** | **0.0110** |     **184 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 10242048             |   436.608 ns |  2.8126 ns |  2.6309 ns | 0.0353 |     225 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **?**                    | **3.5**                  |    **98.186 ns** |  **0.7883 ns** |  **0.6988 ns** | **0.0129** |     **216 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | ?                    | 3.5                  |   330.823 ns |  3.9265 ns |  3.4808 ns | 0.0482 |     305 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **invalid**              | **?**                    |    **22.253 ns** |  **0.0948 ns** |  **0.0792 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | invalid              | ?                    |    36.715 ns |  0.1461 ns |  0.1366 ns | 0.0191 |     120 B |
