```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                | Job                | Runtime            | Normalize | invalidString        | validString          | Mean         | Error     | StdDev    | Gen0   | Allocated |
|---------------------- |------------------- |------------------- |---------- |--------------------- |--------------------- |-------------:|----------:|----------:|-------:|----------:|
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **False**     | ****                     | **?**                    |     **3.366 ns** | **0.0099 ns** | **0.0088 ns** |      **-** |         **-** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | False     |                      | ?                    |    14.238 ns | 0.0231 ns | 0.0216 ns |      - |         - |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **-1**                   |    **56.341 ns** | **0.2216 ns** | **0.2073 ns** | **0.0086** |     **144 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | -1                   |   123.717 ns | 0.2685 ns | 0.2511 ns | 0.0370 |     233 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **-1/5**                 |    **89.896 ns** | **0.2687 ns** | **0.2382 ns** | **0.0148** |     **248 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | -1/5                 |   200.481 ns | 0.5822 ns | 0.5161 ns | 0.0610 |     385 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **False**     | **-10242048/**           | **?**                    |    **82.693 ns** | **0.3413 ns** | **0.3192 ns** | **0.0148** |     **248 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | False     | -10242048/           | ?                    |   431.249 ns | 0.6337 ns | 0.5617 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **-3.5**                 |    **88.353 ns** | **0.1957 ns** | **0.1634 ns** | **0.0129** |     **216 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | -3.5                 |   237.426 ns | 0.5677 ns | 0.5033 ns | 0.0482 |     305 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **0**                    |    **40.395 ns** | **0.1113 ns** | **0.1041 ns** | **0.0062** |     **104 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 0                    |    70.230 ns | 0.2331 ns | 0.2180 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **1**                    |    **43.237 ns** | **0.1932 ns** | **0.1807 ns** | **0.0062** |     **104 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 1                    |    98.939 ns | 0.3922 ns | 0.3477 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **1.234(...)67890 [21]** |   **225.724 ns** | **0.6140 ns** | **0.5443 ns** | **0.0248** |     **416 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 1.234(...)67890 [21] | 1,379.537 ns | 2.5657 ns | 2.3999 ns | 0.2136 |    1356 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **False**     | **1.234(...)7890f [22]** | **?**                    |    **27.447 ns** | **0.0578 ns** | **0.0512 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | False     | 1.234(...)7890f [22] | ?                    |    46.274 ns | 0.0559 ns | 0.0467 ns | 0.0280 |     177 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **1/5**                  |    **89.742 ns** | **0.2876 ns** | **0.2690 ns** | **0.0148** |     **248 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 1/5                  |   198.696 ns | 0.2434 ns | 0.2158 ns | 0.0610 |     385 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **10242048**             |    **89.055 ns** | **0.3112 ns** | **0.2911 ns** | **0.0110** |     **184 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 10242048             |   432.297 ns | 0.4791 ns | 0.4481 ns | 0.0353 |     225 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **False**     | **?**                    | **3.5**                  |    **87.885 ns** | **0.3173 ns** | **0.2968 ns** | **0.0129** |     **216 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 3.5                  |   239.433 ns | 0.6943 ns | 0.6494 ns | 0.0482 |     305 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **False**     | **invalid**              | **?**                    |    **22.234 ns** | **0.1296 ns** | **0.1213 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | False     | invalid              | ?                    |    38.270 ns | 0.1134 ns | 0.1005 ns | 0.0191 |     120 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **True**      | ****                     | **?**                    |     **3.355 ns** | **0.0191 ns** | **0.0178 ns** |      **-** |         **-** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | True      |                      | ?                    |    12.638 ns | 0.0718 ns | 0.0672 ns |      - |         - |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **-1**                   |    **58.504 ns** | **0.3191 ns** | **0.2984 ns** | **0.0086** |     **144 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | -1                   |   124.443 ns | 0.7336 ns | 0.6503 ns | 0.0370 |     233 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **-1/5**                 |    **91.005 ns** | **0.4019 ns** | **0.3356 ns** | **0.0148** |     **248 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | -1/5                 |   219.321 ns | 1.2736 ns | 1.1913 ns | 0.0610 |     385 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **True**      | **-10242048/**           | **?**                    |    **82.245 ns** | **0.3754 ns** | **0.3328 ns** | **0.0148** |     **248 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | True      | -10242048/           | ?                    |   431.795 ns | 2.6071 ns | 2.4387 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **-3.5**                 |    **99.776 ns** | **0.6468 ns** | **0.6050 ns** | **0.0129** |     **216 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | -3.5                 |   320.805 ns | 2.2800 ns | 2.1327 ns | 0.0482 |     305 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **0**                    |    **40.234 ns** | **0.1854 ns** | **0.1734 ns** | **0.0062** |     **104 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 0                    |    69.007 ns | 0.1566 ns | 0.1223 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **1**                    |    **44.106 ns** | **0.2155 ns** | **0.1911 ns** | **0.0062** |     **104 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 1                    |    98.683 ns | 0.5621 ns | 0.5258 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **1.234(...)67890 [21]** |   **310.431 ns** | **2.9036 ns** | **2.7161 ns** | **0.0286** |     **480 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 1.234(...)67890 [21] | 1,642.757 ns | 6.8213 ns | 6.3806 ns | 0.2251 |    1420 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **True**      | **1.234(...)7890f [22]** | **?**                    |    **28.860 ns** | **0.1448 ns** | **0.1354 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | True      | 1.234(...)7890f [22] | ?                    |    46.027 ns | 0.0908 ns | 0.0805 ns | 0.0280 |     177 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **1/5**                  |    **97.199 ns** | **0.3042 ns** | **0.2845 ns** | **0.0148** |     **248 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 1/5                  |   216.430 ns | 0.7757 ns | 0.6056 ns | 0.0610 |     385 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **10242048**             |    **91.523 ns** | **0.3893 ns** | **0.3251 ns** | **0.0110** |     **184 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 10242048             |   432.377 ns | 2.1183 ns | 1.9814 ns | 0.0353 |     225 B |
| **TryParseValidString**   | **.NET 8.0**           | **.NET 8.0**           | **True**      | **?**                    | **3.5**                  |    **98.283 ns** | **0.2496 ns** | **0.2084 ns** | **0.0129** |     **216 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 3.5                  |   327.317 ns | 0.3326 ns | 0.2777 ns | 0.0482 |     305 B |
| **TryParseInvalidString** | **.NET 8.0**           | **.NET 8.0**           | **True**      | **invalid**              | **?**                    |    **21.980 ns** | **0.0694 ns** | **0.0650 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | True      | invalid              | ?                    |    37.918 ns | 0.0705 ns | 0.0625 ns | 0.0191 |     120 B |
