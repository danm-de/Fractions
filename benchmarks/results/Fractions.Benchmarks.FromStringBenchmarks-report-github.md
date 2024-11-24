```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.100
  [Host]             : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 9.0           : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9282.0), X64 RyuJIT VectorSize=256


```
| Method                | Job                | Runtime            | Normalize | invalidString        | validString          | Mean         | Error     | StdDev    | Gen0   | Allocated |
|---------------------- |------------------- |------------------- |---------- |--------------------- |--------------------- |-------------:|----------:|----------:|-------:|----------:|
| **TryParseInvalidString** | **.NET 9.0**           | **.NET 9.0**           | **False**     | ****                     | **?**                    |     **3.590 ns** | **0.0046 ns** | **0.0038 ns** |      **-** |         **-** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | False     |                      | ?                    |    13.635 ns | 0.0020 ns | 0.0015 ns |      - |         - |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **-1**                   |    **57.864 ns** | **0.1400 ns** | **0.1241 ns** | **0.0024** |      **40 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | -1                   |   157.853 ns | 0.6413 ns | 0.5355 ns | 0.0687 |     433 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **-1/5**                 |    **96.540 ns** | **0.2271 ns** | **0.2013 ns** | **0.0024** |      **40 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | -1/5                 |   201.601 ns | 0.2850 ns | 0.2527 ns | 0.0610 |     385 B |
| **TryParseInvalidString** | **.NET 9.0**           | **.NET 9.0**           | **False**     | **-10242048/**           | **?**                    |    **68.953 ns** | **0.1958 ns** | **0.1635 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | False     | -10242048/           | ?                    |   433.409 ns | 0.1322 ns | 0.1104 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **-3.5**                 |    **95.540 ns** | **0.1679 ns** | **0.1402 ns** | **0.0067** |     **112 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | -3.5                 |   277.422 ns | 1.3142 ns | 1.2293 ns | 0.0801 |     505 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **0**                    |    **44.818 ns** | **0.1289 ns** | **0.1076 ns** |      **-** |         **-** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 0                    |    71.429 ns | 0.1109 ns | 0.1038 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **1**                    |    **48.173 ns** | **0.0757 ns** | **0.0708 ns** |      **-** |         **-** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 1                    |    99.374 ns | 0.0164 ns | 0.0128 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **1.234(...)67890 [21]** |   **209.656 ns** | **0.2479 ns** | **0.2197 ns** | **0.0124** |     **208 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 1.234(...)67890 [21] | 1,388.789 ns | 3.3058 ns | 3.0922 ns | 0.2136 |    1356 B |
| **TryParseInvalidString** | **.NET 9.0**           | **.NET 9.0**           | **False**     | **1.234(...)7890f [22]** | **?**                    |    **26.441 ns** | **0.0221 ns** | **0.0196 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | False     | 1.234(...)7890f [22] | ?                    |   149.340 ns | 1.5950 ns | 1.4919 ns | 0.1235 |     778 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **1/5**                  |    **96.436 ns** | **0.0824 ns** | **0.0771 ns** | **0.0024** |      **40 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 1/5                  |   201.887 ns | 0.1495 ns | 0.1399 ns | 0.0610 |     385 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **10242048**             |    **82.044 ns** | **0.0747 ns** | **0.0583 ns** | **0.0048** |      **80 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 10242048             |   437.075 ns | 0.1616 ns | 0.1512 ns | 0.0353 |     225 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **False**     | **?**                    | **3.5**                  |    **93.900 ns** | **0.2320 ns** | **0.2057 ns** | **0.0067** |     **112 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | False     | ?                    | 3.5                  |   236.441 ns | 0.0807 ns | 0.0630 ns | 0.0484 |     305 B |
| **TryParseInvalidString** | **.NET 9.0**           | **.NET 9.0**           | **False**     | **invalid**              | **?**                    |    **20.698 ns** | **0.0177 ns** | **0.0157 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | False     | invalid              | ?                    |   140.700 ns | 1.2390 ns | 1.1590 ns | 0.1147 |     722 B |
| **TryParseInvalidString** | **.NET 9.0**           | **.NET 9.0**           | **True**      | ****                     | **?**                    |     **3.211 ns** | **0.0017 ns** | **0.0015 ns** |      **-** |         **-** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | True      |                      | ?                    |    13.747 ns | 0.0023 ns | 0.0020 ns |      - |         - |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **-1**                   |    **57.636 ns** | **0.0586 ns** | **0.0548 ns** | **0.0024** |      **40 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | -1                   |   156.689 ns | 0.7242 ns | 0.6774 ns | 0.0687 |     433 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **-1/5**                 |   **102.974 ns** | **2.0692 ns** | **4.0358 ns** | **0.0024** |      **40 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | -1/5                 |   226.338 ns | 2.4677 ns | 2.3083 ns | 0.0610 |     385 B |
| **TryParseInvalidString** | **.NET 9.0**           | **.NET 9.0**           | **True**      | **-10242048/**           | **?**                    |    **70.141 ns** | **0.8099 ns** | **0.7576 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | True      | -10242048/           | ?                    |   442.488 ns | 2.9647 ns | 2.6281 ns | 0.0625 |     393 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **-3.5**                 |   **114.831 ns** | **1.1059 ns** | **1.0345 ns** | **0.0067** |     **112 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | -3.5                 |   405.614 ns | 1.7063 ns | 1.5126 ns | 0.0801 |     505 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **0**                    |    **44.154 ns** | **0.4676 ns** | **0.4374 ns** |      **-** |         **-** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 0                    |    72.333 ns | 0.9527 ns | 0.8446 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **1**                    |    **49.912 ns** | **0.3645 ns** | **0.3410 ns** |      **-** |         **-** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 1                    |   100.044 ns | 0.4192 ns | 0.3716 ns | 0.0166 |     104 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **1.234(...)67890 [21]** |   **312.137 ns** | **2.9989 ns** | **2.6584 ns** | **0.0162** |     **272 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 1.234(...)67890 [21] | 1,695.839 ns | 6.4138 ns | 5.3558 ns | 0.2251 |    1420 B |
| **TryParseInvalidString** | **.NET 9.0**           | **.NET 9.0**           | **True**      | **1.234(...)7890f [22]** | **?**                    |    **27.149 ns** | **0.3642 ns** | **0.3407 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | True      | 1.234(...)7890f [22] | ?                    |   149.333 ns | 1.2769 ns | 1.1944 ns | 0.1235 |     778 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **1/5**                  |    **99.490 ns** | **0.5728 ns** | **0.5358 ns** | **0.0024** |      **40 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 1/5                  |   222.819 ns | 2.9958 ns | 2.8023 ns | 0.0610 |     385 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **10242048**             |    **82.071 ns** | **0.6226 ns** | **0.5520 ns** | **0.0048** |      **80 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 10242048             |   441.628 ns | 1.2333 ns | 0.9629 ns | 0.0353 |     225 B |
| **TryParseValidString**   | **.NET 9.0**           | **.NET 9.0**           | **True**      | **?**                    | **3.5**                  |   **112.154 ns** | **0.8391 ns** | **0.7849 ns** | **0.0067** |     **112 B** |
| TryParseValidString   | .NET Framework 4.8 | .NET Framework 4.8 | True      | ?                    | 3.5                  |   355.632 ns | 0.9512 ns | 0.8432 ns | 0.0482 |     305 B |
| **TryParseInvalidString** | **.NET 9.0**           | **.NET 9.0**           | **True**      | **invalid**              | **?**                    |    **21.331 ns** | **0.1804 ns** | **0.1599 ns** | **0.0024** |      **40 B** |
| TryParseInvalidString | .NET Framework 4.8 | .NET Framework 4.8 | True      | invalid              | ?                    |   138.459 ns | 0.7771 ns | 0.6489 ns | 0.1147 |     722 B |
