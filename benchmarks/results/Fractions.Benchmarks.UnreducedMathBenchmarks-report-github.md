```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]                      : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9232.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method   | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|--------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **26.473 ns** |  **0.2333 ns** | **0.0128 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  30.886 ns |  0.8669 ns | 0.0475 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  57.382 ns |  7.0191 ns | 0.3847 ns |      - |         - |
| **Mod**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |   **6.206 ns** |  **0.8655 ns** | **0.0474 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **27.895 ns** |  **2.3217 ns** | **0.1273 ns** |      **-** |         **-** |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  44.249 ns |  1.6774 ns | 0.0919 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |  **14.853 ns** |  **0.7785 ns** | **0.0427 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1/0                  | 1/1                  |  16.574 ns |  2.0530 ns | 0.1125 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/0                  | 1/1                  |  30.011 ns |  0.5602 ns | 0.0307 ns |      - |         - |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **15.786 ns** |  **0.9470 ns** | **0.0519 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **46.456 ns** |  **5.9716 ns** | **0.3273 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               |  **72.871 ns** |  **9.5452 ns** | **0.5232 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |  **15.865 ns** |  **0.5964 ns** | **0.0327 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/0                  | 1/1                  |  27.752 ns |  0.2188 ns | 0.0120 ns |      - |         - |
| **Multiply** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               | **210.452 ns** | **36.3967 ns** | **1.9950 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 124.787 ns |  5.5034 ns | 0.3017 ns |      - |         - |
| **Multiply** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **28.485 ns** |  **0.0401 ns** | **0.0022 ns** |      **-** |         **-** |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **49.525 ns** |  **2.1285 ns** | **0.1167 ns** | **0.0057** |      **96 B** |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |   **7.128 ns** |  **0.5684 ns** | **0.0312 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               |  **58.853 ns** |  **3.6111 ns** | **0.1979 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **51.018 ns** |  **4.8627 ns** | **0.2665 ns** | **0.0057** |      **96 B** |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  98.140 ns |  2.7163 ns | 0.1489 ns | 0.0067 |     112 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 246.298 ns | 16.0682 ns | 0.8808 ns | 0.0291 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 125.415 ns | 18.1132 ns | 0.9928 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 153.897 ns |  2.0050 ns | 0.1099 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024/1**              | **-1/1024**              |  **31.592 ns** |  **2.4848 ns** | **0.1362 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  32.673 ns |  1.4509 ns | 0.0795 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  26.291 ns |  0.6869 ns | 0.0376 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  15.767 ns |  0.8202 ns | 0.0450 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  33.342 ns |  1.5667 ns | 0.0859 ns |      - |         - |
| **Divide**   | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **57.649 ns** |  **1.1684 ns** | **0.0640 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **31.182 ns** |  **1.3369 ns** | **0.0733 ns** | **0.0029** |      **48 B** |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  63.940 ns |  9.3267 ns | 0.5112 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 118.520 ns |  7.4675 ns | 0.4093 ns | 0.0153 |      96 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 132.116 ns | 16.6123 ns | 0.9106 ns | 0.0153 |      96 B |
| **Add**      | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **-1024/1**              | **-1/1024**              |  **70.273 ns** |  **3.0943 ns** | **0.1696 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  89.269 ns |  5.4997 ns | 0.3015 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              | 137.722 ns | 70.6051 ns | 3.8701 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  59.495 ns |  2.2291 ns | 0.1222 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              | 136.505 ns | 31.7771 ns | 1.7418 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45/1**                | **1/6**                  |  **31.648 ns** |  **0.3444 ns** | **0.0189 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  32.858 ns |  0.1839 ns | 0.0101 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  27.091 ns |  0.5766 ns | 0.0316 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  15.714 ns |  0.8542 ns | 0.0468 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  32.468 ns |  0.6524 ns | 0.0358 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  67.881 ns |  2.7901 ns | 0.1529 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  88.481 ns |  1.5134 ns | 0.0830 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 130.605 ns |  1.6043 ns | 0.0879 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  58.259 ns |  1.1746 ns | 0.0644 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 119.304 ns | 39.5671 ns | 2.1688 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **25.492 ns** |  **0.2392 ns** | **0.0131 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  27.131 ns |  2.7288 ns | 0.1496 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  28.705 ns |  0.1508 ns | 0.0083 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  15.687 ns |  0.1668 ns | 0.0091 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  30.894 ns |  1.2073 ns | 0.0662 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  53.427 ns |  1.2638 ns | 0.0693 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  80.208 ns |  0.3620 ns | 0.0198 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 139.962 ns | 14.6924 ns | 0.8053 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  60.635 ns |  6.8475 ns | 0.3753 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 127.139 ns |  6.8948 ns | 0.3779 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |  **25.356 ns** |  **0.1624 ns** | **0.0089 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  27.205 ns |  1.2801 ns | 0.0702 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  47.559 ns |  2.7197 ns | 0.1491 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  15.848 ns |  0.5487 ns | 0.0301 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  27.847 ns |  4.6501 ns | 0.2549 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  62.682 ns |  4.4615 ns | 0.2445 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  73.355 ns |  1.2974 ns | 0.0711 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 198.743 ns |  0.4486 ns | 0.0246 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  65.066 ns |  0.7997 ns | 0.0438 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  95.507 ns |  9.0048 ns | 0.4936 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **54.193 ns** |  **2.9602 ns** | **0.1623 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  54.726 ns |  2.9757 ns | 0.1631 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  27.828 ns |  1.3344 ns | 0.0731 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  15.734 ns |  0.1365 ns | 0.0075 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  59.769 ns |  3.4844 ns | 0.1910 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 171.074 ns | 40.2335 ns | 2.2053 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 202.029 ns | 14.0328 ns | 0.7692 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 126.316 ns |  3.8474 ns | 0.2109 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  59.569 ns |  4.2254 ns | 0.2316 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 240.737 ns | 26.4422 ns | 1.4494 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **54.537 ns** |  **1.4733 ns** | **0.0808 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  54.790 ns |  7.1541 ns | 0.3921 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  44.189 ns |  0.4254 ns | 0.0233 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  15.795 ns |  2.2047 ns | 0.1208 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  70.319 ns |  7.0234 ns | 0.3850 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 177.669 ns | 56.5405 ns | 3.0992 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 205.406 ns | 16.8287 ns | 0.9224 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 194.436 ns | 19.2667 ns | 1.0561 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  59.981 ns |  5.5186 ns | 0.3025 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 282.068 ns | 13.5380 ns | 0.7421 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **70742(...)85248 [33]** | **70742(...)70496 [33]** |  **75.501 ns** |  **1.7845 ns** | **0.0978 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  75.520 ns |  3.9846 ns | 0.2184 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 206.002 ns | 24.4855 ns | 1.3421 ns | 0.0124 |     208 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  41.599 ns |  0.3558 ns | 0.0195 ns | 0.0048 |      80 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 107.629 ns | 58.0450 ns | 3.1816 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 201.736 ns |  7.3634 ns | 0.4036 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 231.169 ns | 23.3409 ns | 1.2794 ns | 0.0215 |     136 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 343.413 ns | 45.7255 ns | 2.5064 ns | 0.0429 |     273 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 115.460 ns | 15.9498 ns | 0.8743 ns | 0.0126 |      80 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 330.313 ns |  9.8644 ns | 0.5407 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |  **14.871 ns** |  **0.4182 ns** | **0.0229 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  16.002 ns |  1.3839 ns | 0.0759 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.183 ns |  0.7936 ns | 0.0435 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.008 ns |  0.7833 ns | 0.0429 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.100 ns |  1.5195 ns | 0.0833 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.258 ns |  0.1438 ns | 0.0079 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  49.438 ns |  1.6417 ns | 0.0900 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  30.221 ns |  0.5820 ns | 0.0319 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  23.823 ns |  3.2171 ns | 0.1763 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.556 ns |  1.5934 ns | 0.0873 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |  **14.951 ns** |  **0.3670 ns** | **0.0201 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  16.539 ns |  3.0366 ns | 0.1664 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   8.142 ns |  0.5610 ns | 0.0308 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   5.996 ns |  0.6970 ns | 0.0382 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.260 ns |  0.3819 ns | 0.0209 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.059 ns |  4.9491 ns | 0.2713 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  44.434 ns |  0.3287 ns | 0.0180 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  31.004 ns |  4.7349 ns | 0.2595 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  24.525 ns |  4.8757 ns | 0.2673 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  27.075 ns |  3.7039 ns | 0.2030 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |  **14.965 ns** |  **3.3816 ns** | **0.1854 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  15.818 ns |  0.7406 ns | 0.0406 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  35.251 ns |  2.7231 ns | 0.1493 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  15.682 ns |  0.2320 ns | 0.0127 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   6.253 ns |  0.1886 ns | 0.0103 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.025 ns |  0.2099 ns | 0.0115 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  41.059 ns |  2.6542 ns | 0.1455 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    | 123.058 ns | 27.2287 ns | 1.4925 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  54.691 ns |  5.2091 ns | 0.2855 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  26.939 ns |  1.0044 ns | 0.0551 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97/1**                 | **89/1**                 |  **25.482 ns** |  **0.3961 ns** | **0.0217 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  27.039 ns |  0.9915 ns | 0.0543 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  15.703 ns |  0.3222 ns | 0.0177 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  15.853 ns |  3.5795 ns | 0.1962 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  15.451 ns |  0.9433 ns | 0.0517 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  59.666 ns |  1.1529 ns | 0.0632 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  73.148 ns |  2.7383 ns | 0.1501 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  64.256 ns |  1.3092 ns | 0.0718 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  56.828 ns |  1.0036 ns | 0.0550 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  58.361 ns |  1.2544 ns | 0.0688 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000/1**               | **100/1**                |  **25.566 ns** |  **1.0793 ns** | **0.0592 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  27.165 ns |  0.6791 ns | 0.0372 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  15.661 ns |  2.1877 ns | 0.1199 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  15.735 ns |  0.1337 ns | 0.0073 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  15.229 ns |  0.0550 ns | 0.0030 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  53.720 ns |  2.0647 ns | 0.1132 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  73.961 ns |  1.4280 ns | 0.0783 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  64.554 ns |  3.9072 ns | 0.2142 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  58.386 ns |  8.6776 ns | 0.4756 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  48.551 ns |  0.3255 ns | 0.0178 ns |      - |         - |
