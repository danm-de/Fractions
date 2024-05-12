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
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **26.330 ns** |  **2.4477 ns** | **0.1342 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  30.530 ns |  0.9126 ns | 0.0500 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  53.958 ns |  1.4783 ns | 0.0810 ns |      - |         - |
| **Mod**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |   **6.232 ns** |  **0.6546 ns** | **0.0359 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **34.155 ns** |  **2.1380 ns** | **0.1172 ns** |      **-** |         **-** |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  53.070 ns |  1.9163 ns | 0.1050 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |  **14.830 ns** |  **0.3524 ns** | **0.0193 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1/0                  | 1/1                  |  16.679 ns |  0.6096 ns | 0.0334 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/0                  | 1/1                  |  30.268 ns |  3.2079 ns | 0.1758 ns |      - |         - |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **15.734 ns** |  **0.2091 ns** | **0.0115 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **44.061 ns** |  **5.6519 ns** | **0.3098 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               |  **74.275 ns** |  **1.1918 ns** | **0.0653 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |  **15.769 ns** |  **0.9644 ns** | **0.0529 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/0                  | 1/1                  |  27.152 ns |  0.4057 ns | 0.0222 ns |      - |         - |
| **Multiply** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               | **208.298 ns** | **23.2479 ns** | **1.2743 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 124.992 ns | 27.1222 ns | 1.4867 ns |      - |         - |
| **Multiply** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **28.282 ns** |  **5.3959 ns** | **0.2958 ns** |      **-** |         **-** |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **50.492 ns** |  **2.9298 ns** | **0.1606 ns** | **0.0057** |      **96 B** |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |   **7.067 ns** |  **2.7741 ns** | **0.1521 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               |  **60.921 ns** |  **4.1602 ns** | **0.2280 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **51.034 ns** |  **3.1487 ns** | **0.1726 ns** | **0.0057** |      **96 B** |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  99.867 ns | 11.9025 ns | 0.6524 ns | 0.0067 |     112 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 242.832 ns | 12.3544 ns | 0.6772 ns | 0.0291 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  88.126 ns |  4.0718 ns | 0.2232 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 154.310 ns | 19.2907 ns | 1.0574 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024/1**              | **-1/1024**              |  **31.514 ns** |  **0.3928 ns** | **0.0215 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  33.059 ns |  3.0408 ns | 0.1667 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  28.813 ns |  0.2542 ns | 0.0139 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  15.736 ns |  1.2892 ns | 0.0707 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  34.038 ns |  0.4189 ns | 0.0230 ns |      - |         - |
| **Divide**   | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **58.520 ns** |  **2.9327 ns** | **0.1608 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **30.844 ns** |  **3.0994 ns** | **0.1699 ns** | **0.0029** |      **48 B** |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  64.058 ns | 14.4142 ns | 0.7901 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 119.116 ns |  9.7147 ns | 0.5325 ns | 0.0153 |      96 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 135.194 ns | 23.3292 ns | 1.2788 ns | 0.0153 |      96 B |
| **Add**      | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **-1024/1**              | **-1/1024**              |  **69.671 ns** |  **2.6442 ns** | **0.1449 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  89.012 ns | 15.0824 ns | 0.8267 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              | 149.408 ns | 13.0199 ns | 0.7137 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  56.875 ns |  8.2992 ns | 0.4549 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              | 123.926 ns |  3.8542 ns | 0.2113 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45/1**                | **1/6**                  |  **32.338 ns** |  **1.6042 ns** | **0.0879 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  33.234 ns |  0.9763 ns | 0.0535 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  30.892 ns |  1.4952 ns | 0.0820 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  15.822 ns |  0.7487 ns | 0.0410 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  32.496 ns |  6.2160 ns | 0.3407 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  70.727 ns |  3.5687 ns | 0.1956 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  89.833 ns |  3.9035 ns | 0.2140 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 151.862 ns | 16.0552 ns | 0.8800 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  58.653 ns |  7.7139 ns | 0.4228 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 118.666 ns | 31.8487 ns | 1.7457 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **25.548 ns** |  **1.8607 ns** | **0.1020 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  27.024 ns |  0.9595 ns | 0.0526 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  34.218 ns |  1.5959 ns | 0.0875 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  15.837 ns |  1.8246 ns | 0.1000 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  30.634 ns |  3.3875 ns | 0.1857 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  54.073 ns |  2.3274 ns | 0.1276 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  74.168 ns |  0.4262 ns | 0.0234 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 154.646 ns | 57.0914 ns | 3.1294 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  60.539 ns |  6.2420 ns | 0.3421 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 129.888 ns | 17.0180 ns | 0.9328 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |  **24.999 ns** |  **1.3329 ns** | **0.0731 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  27.126 ns |  1.8539 ns | 0.1016 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  53.074 ns |  1.1915 ns | 0.0653 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  15.709 ns |  0.4853 ns | 0.0266 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  27.477 ns |  0.3648 ns | 0.0200 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  54.689 ns |  5.6584 ns | 0.3102 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  73.239 ns |  4.3177 ns | 0.2367 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 217.834 ns | 21.0809 ns | 1.1555 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  59.288 ns |  5.3655 ns | 0.2941 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  96.273 ns | 16.5699 ns | 0.9083 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **53.840 ns** |  **1.3185 ns** | **0.0723 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  55.058 ns |  1.3368 ns | 0.0733 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  32.410 ns |  0.7017 ns | 0.0385 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  15.792 ns |  0.6564 ns | 0.0360 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  61.511 ns |  6.8102 ns | 0.3733 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 175.470 ns | 18.3349 ns | 1.0050 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 203.623 ns | 28.7237 ns | 1.5744 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 142.895 ns |  8.1022 ns | 0.4441 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  58.662 ns |  7.1930 ns | 0.3943 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 240.498 ns | 38.6019 ns | 2.1159 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **54.921 ns** |  **5.1186 ns** | **0.2806 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  54.683 ns |  1.9662 ns | 0.1078 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  51.103 ns |  2.7712 ns | 0.1519 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  15.821 ns |  0.4816 ns | 0.0264 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  70.802 ns |  8.3088 ns | 0.4554 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 174.876 ns |  3.0192 ns | 0.1655 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 203.266 ns |  8.6793 ns | 0.4757 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 210.305 ns | 25.3668 ns | 1.3904 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  61.012 ns |  2.6303 ns | 0.1442 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 278.753 ns | 23.3062 ns | 1.2775 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **70742(...)85248 [33]** | **70742(...)70496 [33]** |  **76.325 ns** |  **8.3707 ns** | **0.4588 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  76.437 ns |  8.5932 ns | 0.4710 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 209.199 ns |  7.9482 ns | 0.4357 ns | 0.0124 |     208 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  41.768 ns |  3.2650 ns | 0.1790 ns | 0.0048 |      80 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 104.243 ns |  1.5196 ns | 0.0833 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 203.075 ns | 10.6247 ns | 0.5824 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 226.846 ns |  8.9264 ns | 0.4893 ns | 0.0215 |     136 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 355.108 ns | 11.5653 ns | 0.6339 ns | 0.0429 |     273 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 114.569 ns | 18.4654 ns | 1.0121 ns | 0.0126 |      80 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 334.110 ns | 11.6275 ns | 0.6373 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |  **14.917 ns** |  **1.1250 ns** | **0.0617 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  15.811 ns |  0.3974 ns | 0.0218 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.041 ns |  0.8850 ns | 0.0485 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   5.935 ns |  0.3284 ns | 0.0180 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.115 ns |  0.3739 ns | 0.0205 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.639 ns |  1.6226 ns | 0.0889 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  42.119 ns |  0.4749 ns | 0.0260 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  30.326 ns |  4.6976 ns | 0.2575 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  23.953 ns |  1.3387 ns | 0.0734 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.136 ns |  4.3265 ns | 0.2372 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |  **15.013 ns** |  **1.3984 ns** | **0.0767 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  16.594 ns |  1.8749 ns | 0.1028 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   8.876 ns |  0.4966 ns | 0.0272 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.187 ns |  0.5181 ns | 0.0284 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.290 ns |  0.7823 ns | 0.0429 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.662 ns |  5.0058 ns | 0.2744 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  45.159 ns |  2.0859 ns | 0.1143 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  31.281 ns |  3.5493 ns | 0.1945 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  23.941 ns |  0.7952 ns | 0.0436 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  27.379 ns |  0.1330 ns | 0.0073 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |  **15.017 ns** |  **1.1638 ns** | **0.0638 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  15.963 ns |  0.2306 ns | 0.0126 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  16.195 ns |  0.6376 ns | 0.0350 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  15.840 ns |  0.7078 ns | 0.0388 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   6.271 ns |  0.2030 ns | 0.0111 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.091 ns |  2.5764 ns | 0.1412 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  41.030 ns |  0.4306 ns | 0.0236 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  63.794 ns |  8.2867 ns | 0.4542 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  56.947 ns |  0.4462 ns | 0.0245 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.084 ns |  2.8365 ns | 0.1555 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97/1**                 | **89/1**                 |  **25.371 ns** |  **0.1693 ns** | **0.0093 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  27.139 ns |  1.6795 ns | 0.0921 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  16.156 ns |  0.8174 ns | 0.0448 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  15.821 ns |  0.4502 ns | 0.0247 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  15.545 ns |  2.6562 ns | 0.1456 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  54.110 ns |  7.9904 ns | 0.4380 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  73.962 ns |  1.0073 ns | 0.0552 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  65.226 ns |  4.6438 ns | 0.2545 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  56.981 ns |  1.8597 ns | 0.1019 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  57.960 ns |  2.2513 ns | 0.1234 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000/1**               | **100/1**                |  **25.618 ns** |  **1.2996 ns** | **0.0712 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  27.075 ns |  1.2566 ns | 0.0689 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  16.234 ns |  0.3746 ns | 0.0205 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  15.708 ns |  1.1652 ns | 0.0639 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  15.223 ns |  2.5632 ns | 0.1405 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  55.416 ns |  3.2565 ns | 0.1785 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  73.898 ns |  0.4516 ns | 0.0248 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  65.789 ns |  8.1235 ns | 0.4453 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  57.551 ns | 11.6047 ns | 0.6361 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  48.978 ns |  1.8775 ns | 0.1029 ns |      - |         - |
