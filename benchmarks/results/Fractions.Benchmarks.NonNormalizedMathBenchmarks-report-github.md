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
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **30.311 ns** |  **2.9319 ns** | **0.1607 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  27.672 ns |  0.8111 ns | 0.0445 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  52.512 ns |  0.6226 ns | 0.0341 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  17.230 ns |  0.7769 ns | 0.0426 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  14.804 ns |  2.3641 ns | 0.1296 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  55.379 ns |  1.9373 ns | 0.1062 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  74.641 ns |  1.4981 ns | 0.0821 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 229.605 ns | 26.3239 ns | 1.4429 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  61.845 ns |  1.3714 ns | 0.0752 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  48.179 ns |  1.8134 ns | 0.0994 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **51.338 ns** |  **5.9637 ns** | **0.3269 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  52.105 ns |  3.2519 ns | 0.1782 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  84.061 ns |  4.1052 ns | 0.2250 ns | 0.0043 |      72 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  26.494 ns |  4.0237 ns | 0.2206 ns | 0.0029 |      48 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  65.903 ns |  2.5121 ns | 0.1377 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 120.451 ns |  6.8862 ns | 0.3775 ns | 0.0153 |      96 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 134.649 ns |  4.7246 ns | 0.2590 ns | 0.0153 |      96 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 203.646 ns |  4.7909 ns | 0.2626 ns | 0.0293 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  76.231 ns |  7.8455 ns | 0.4300 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 161.390 ns | 13.5001 ns | 0.7400 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024**                | **-1/1024**              |  **31.314 ns** |  **0.5199 ns** | **0.0285 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  33.092 ns |  1.6800 ns | 0.0921 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  25.689 ns |  1.3817 ns | 0.0757 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  11.733 ns |  0.7461 ns | 0.0409 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  33.280 ns |  0.6408 ns | 0.0351 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  72.508 ns |  2.0062 ns | 0.1100 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  89.588 ns |  1.8943 ns | 0.1038 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 128.137 ns | 46.0569 ns | 2.5245 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  42.970 ns |  0.8924 ns | 0.0489 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 129.018 ns | 90.3443 ns | 4.9521 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45**                  | **1/6**                  |  **31.939 ns** |  **1.4859 ns** | **0.0814 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  33.391 ns |  1.3061 ns | 0.0716 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  22.939 ns |  0.6706 ns | 0.0368 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  11.733 ns |  0.2789 ns | 0.0153 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  33.581 ns |  1.9035 ns | 0.1043 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  71.684 ns |  3.2918 ns | 0.1804 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  89.690 ns |  1.0438 ns | 0.0572 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 104.185 ns |  3.3202 ns | 0.1820 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  42.965 ns |  1.7650 ns | 0.0967 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 119.090 ns |  2.6248 ns | 0.1439 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    | **1**                    |  **14.913 ns** |  **1.3050 ns** | **0.0715 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  15.703 ns |  2.4890 ns | 0.1364 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   7.690 ns |  5.0875 ns | 0.2789 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   9.021 ns |  8.4059 ns | 0.4608 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  11.852 ns |  1.2243 ns | 0.0671 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  27.719 ns |  4.3646 ns | 0.2392 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  42.089 ns |  0.6009 ns | 0.0329 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  28.019 ns |  2.4773 ns | 0.1358 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  28.569 ns |  2.2366 ns | 0.1226 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  30.235 ns |  0.2907 ns | 0.0159 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **25.595 ns** |  **0.7334 ns** | **0.0402 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  27.160 ns |  0.7701 ns | 0.0422 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  36.082 ns |  9.4734 ns | 0.5193 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  17.382 ns |  1.2254 ns | 0.0672 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  14.890 ns |  2.4928 ns | 0.1366 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  54.208 ns |  0.9254 ns | 0.0507 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  75.070 ns | 10.9718 ns | 0.6014 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 158.422 ns | 15.5389 ns | 0.8517 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  62.056 ns |  0.6236 ns | 0.0342 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  47.796 ns |  1.5739 ns | 0.0863 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |  **25.641 ns** |  **0.8381 ns** | **0.0459 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  27.309 ns |  0.9964 ns | 0.0546 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  54.644 ns |  3.7657 ns | 0.2064 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  17.350 ns |  0.4171 ns | 0.0229 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  14.893 ns |  0.6525 ns | 0.0358 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  55.741 ns |  0.4818 ns | 0.0264 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  73.910 ns |  2.2588 ns | 0.1238 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 230.681 ns |  8.0627 ns | 0.4419 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  61.378 ns |  3.2834 ns | 0.1800 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  48.388 ns |  0.8802 ns | 0.0482 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **54.116 ns** |  **1.2080 ns** | **0.0662 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  54.966 ns |  2.2733 ns | 0.1246 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  34.795 ns |  2.6445 ns | 0.1450 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  17.232 ns |  0.7353 ns | 0.0403 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  45.152 ns |  2.3142 ns | 0.1268 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 177.682 ns | 10.5554 ns | 0.5786 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 205.497 ns |  6.2312 ns | 0.3416 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 143.847 ns |  5.0502 ns | 0.2768 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  61.336 ns |  0.7300 ns | 0.0400 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 194.349 ns | 10.5988 ns | 0.5810 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **54.756 ns** |  **1.4582 ns** | **0.0799 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  55.304 ns |  2.0360 ns | 0.1116 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  53.600 ns |  1.4413 ns | 0.0790 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  17.386 ns |  0.5587 ns | 0.0306 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  47.646 ns |  2.3430 ns | 0.1284 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 176.445 ns | 13.9808 ns | 0.7663 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 200.826 ns |  7.8605 ns | 0.4309 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 225.661 ns | 17.8349 ns | 0.9776 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  62.151 ns |  4.8632 ns | 0.2666 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 194.915 ns |  5.6977 ns | 0.3123 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **70742(...)85248 [33]** | **70742(...)70496 [33]** |  **75.273 ns** | **16.4924 ns** | **0.9040 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  76.068 ns | 11.2630 ns | 0.6174 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 210.921 ns | 45.2185 ns | 2.4786 ns | 0.0124 |     208 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  43.488 ns |  2.2607 ns | 0.1239 ns | 0.0048 |      80 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  74.847 ns |  2.6629 ns | 0.1460 ns | 0.0038 |      64 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 200.521 ns | 32.3043 ns | 1.7707 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 246.205 ns | 39.9293 ns | 2.1887 ns | 0.0215 |     136 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 358.747 ns | 12.7323 ns | 0.6979 ns | 0.0429 |     273 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 114.672 ns |  4.4129 ns | 0.2419 ns | 0.0126 |      80 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 230.117 ns |  4.5085 ns | 0.2471 ns | 0.0215 |     136 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |  **15.043 ns** |  **0.5319 ns** | **0.0292 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  15.961 ns |  0.3771 ns | 0.0207 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.429 ns |  0.3374 ns | 0.0185 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.013 ns |  0.8106 ns | 0.0444 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  11.115 ns |  0.2592 ns | 0.0142 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.827 ns |  0.1912 ns | 0.0105 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  42.639 ns |  0.4524 ns | 0.0248 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  33.645 ns |  0.5989 ns | 0.0328 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  24.126 ns |  0.7642 ns | 0.0419 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  42.395 ns |  2.2587 ns | 0.1238 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |  **15.202 ns** |  **1.5368 ns** | **0.0842 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  16.716 ns |  1.4153 ns | 0.0776 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   8.607 ns |  6.1207 ns | 0.3355 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   5.969 ns |  0.1369 ns | 0.0075 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  10.997 ns |  0.6773 ns | 0.0371 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.342 ns |  0.4078 ns | 0.0224 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  45.503 ns |  0.2728 ns | 0.0150 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  31.043 ns |  1.4931 ns | 0.0818 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  25.072 ns |  1.3825 ns | 0.0758 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  29.604 ns |  0.4382 ns | 0.0240 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |  **15.198 ns** |  **2.9814 ns** | **0.1634 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  16.098 ns |  0.4821 ns | 0.0264 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.293 ns |  0.8694 ns | 0.0477 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   9.012 ns |  0.7699 ns | 0.0422 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  11.065 ns |  0.1825 ns | 0.0100 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.561 ns |  1.3363 ns | 0.0732 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  59.648 ns |  1.8549 ns | 0.1017 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.893 ns |  1.0127 ns | 0.0555 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  28.158 ns |  0.7687 ns | 0.0421 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  30.106 ns |  1.0001 ns | 0.0548 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97**                   | **89**                   |  **25.554 ns** |  **0.3769 ns** | **0.0207 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  27.396 ns |  2.2058 ns | 0.1209 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  12.027 ns |  0.1045 ns | 0.0057 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   9.107 ns |  4.1168 ns | 0.2257 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  14.805 ns |  1.0148 ns | 0.0556 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  54.098 ns |  1.6463 ns | 0.0902 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  79.588 ns |  2.5675 ns | 0.1407 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  58.087 ns |  2.0044 ns | 0.1099 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  28.892 ns |  0.6877 ns | 0.0377 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  48.398 ns |  2.5528 ns | 0.1399 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000**                 | **100**                  |  **25.457 ns** |  **0.3874 ns** | **0.0212 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  27.166 ns |  0.7806 ns | 0.0428 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  12.034 ns |  0.5862 ns | 0.0321 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   9.049 ns |  0.1990 ns | 0.0109 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  14.903 ns |  0.1600 ns | 0.0088 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  54.277 ns |  5.3222 ns | 0.2917 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  77.488 ns |  0.2769 ns | 0.0152 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  51.645 ns |  5.9433 ns | 0.3258 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  28.147 ns |  0.6637 ns | 0.0364 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  47.528 ns |  1.4210 ns | 0.0779 ns |      - |         - |
