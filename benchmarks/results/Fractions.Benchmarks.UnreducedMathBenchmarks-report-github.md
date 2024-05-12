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
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **26.543 ns** |  **1.3666 ns** | **0.0749 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  31.449 ns |  7.9015 ns | 0.4331 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  55.094 ns |  1.0617 ns | 0.0582 ns |      - |         - |
| **Mod**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |   **6.278 ns** |  **0.4264 ns** | **0.0234 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **30.563 ns** | **80.9506 ns** | **4.4372 ns** |      **-** |         **-** |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  44.494 ns |  5.8602 ns | 0.3212 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |  **14.985 ns** |  **0.7019 ns** | **0.0385 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1/0                  | 1/1                  |  16.689 ns |  3.2035 ns | 0.1756 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/0                  | 1/1                  |  32.755 ns |  5.2274 ns | 0.2865 ns |      - |         - |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **15.962 ns** |  **2.0889 ns** | **0.1145 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **46.838 ns** |  **5.4078 ns** | **0.2964 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               |  **74.453 ns** |  **3.7511 ns** | **0.2056 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |  **15.863 ns** |  **2.5904 ns** | **0.1420 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1/0                  | 1/1                  |  27.346 ns |  1.1780 ns | 0.0646 ns |      - |         - |
| **Multiply** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               | **199.805 ns** | **38.6031 ns** | **2.1160 ns** |      **-** |         **-** |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 125.281 ns |  6.8582 ns | 0.3759 ns |      - |         - |
| **Multiply** | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **28.801 ns** |  **0.3429 ns** | **0.0188 ns** |      **-** |         **-** |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **50.592 ns** | **12.7511 ns** | **0.6989 ns** | **0.0057** |      **96 B** |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1/0**                  | **1/1**                  |   **6.807 ns** |  **0.2191 ns** | **0.0120 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **42/-96**               | **36/-96**               |  **60.970 ns** |  **5.2944 ns** | **0.2902 ns** |      **-** |         **-** |
| **Subtract** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **52.574 ns** |  **4.4185 ns** | **0.2422 ns** | **0.0057** |      **96 B** |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  97.611 ns |  8.6559 ns | 0.4745 ns | 0.0067 |     112 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 252.747 ns | 28.8086 ns | 1.5791 ns | 0.0291 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  89.883 ns | 11.1993 ns | 0.6139 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 153.695 ns |  4.3321 ns | 0.2375 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024/1**              | **-1/1024**              |  **31.385 ns** |  **0.8283 ns** | **0.0454 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  32.834 ns |  1.3662 ns | 0.0749 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  26.751 ns |  0.3641 ns | 0.0200 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  15.903 ns |  0.4142 ns | 0.0227 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  33.011 ns |  0.3438 ns | 0.0188 ns |      - |         - |
| **Divide**   | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **1/0**                  | **1/1**                  |  **64.766 ns** |  **2.1856 ns** | **0.1198 ns** |      **-** |         **-** |
| **Divide**   | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **31.403 ns** |  **0.5208 ns** | **0.0285 ns** | **0.0029** |      **48 B** |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  69.365 ns |  9.1933 ns | 0.5039 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 121.297 ns |  5.5592 ns | 0.3047 ns | 0.0153 |      96 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 135.403 ns |  9.3199 ns | 0.5109 ns | 0.0153 |      96 B |
| **Add**      | **ShortRun-.NET Framework 4.8** | **.NET Framework 4.8** | **-1024/1**              | **-1/1024**              |  **68.842 ns** |  **1.9126 ns** | **0.1048 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  95.820 ns |  3.9723 ns | 0.2177 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              | 145.758 ns | 12.3095 ns | 0.6747 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  58.571 ns |  0.6355 ns | 0.0348 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              | 125.199 ns |  8.8674 ns | 0.4861 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45/1**                | **1/6**                  |  **31.894 ns** |  **1.9670 ns** | **0.1078 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  32.748 ns |  1.5663 ns | 0.0859 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  27.888 ns |  0.9997 ns | 0.0548 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  15.880 ns |  0.7819 ns | 0.0429 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  32.929 ns |  0.7182 ns | 0.0394 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  68.643 ns |  7.0432 ns | 0.3861 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  89.846 ns |  2.7537 ns | 0.1509 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 135.718 ns | 18.5004 ns | 1.0141 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  58.890 ns |  0.7072 ns | 0.0388 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 120.484 ns |  7.9839 ns | 0.4376 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **25.562 ns** |  **2.2274 ns** | **0.1221 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  35.307 ns |  0.9569 ns | 0.0525 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  29.018 ns |  2.1920 ns | 0.1202 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  15.805 ns |  1.0755 ns | 0.0589 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  29.880 ns |  2.4744 ns | 0.1356 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  54.976 ns |  1.1170 ns | 0.0612 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  74.613 ns |  1.3951 ns | 0.0765 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 143.733 ns | 16.0714 ns | 0.8809 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  59.125 ns |  4.9621 ns | 0.2720 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 129.874 ns |  8.5827 ns | 0.4704 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |  **25.676 ns** |  **2.0378 ns** | **0.1117 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  27.381 ns |  1.4008 ns | 0.0768 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  47.095 ns |  6.8089 ns | 0.3732 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  15.818 ns |  1.7155 ns | 0.0940 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  28.917 ns |  2.7598 ns | 0.1513 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  54.223 ns |  7.7835 ns | 0.4266 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  83.992 ns |  3.2446 ns | 0.1778 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 204.464 ns | 55.7360 ns | 3.0551 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  59.563 ns |  0.1455 ns | 0.0080 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  98.355 ns | 22.6704 ns | 1.2426 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **54.981 ns** |  **3.6581 ns** | **0.2005 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  55.108 ns |  2.0182 ns | 0.1106 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  27.786 ns |  1.3694 ns | 0.0751 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  15.893 ns |  0.3497 ns | 0.0192 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  59.437 ns |  4.0264 ns | 0.2207 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 175.899 ns |  3.7376 ns | 0.2049 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 200.118 ns | 10.4996 ns | 0.5755 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 129.159 ns | 32.2901 ns | 1.7699 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  59.297 ns |  7.5614 ns | 0.4145 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 241.730 ns | 37.2730 ns | 2.0431 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **54.985 ns** |  **0.6099 ns** | **0.0334 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  56.023 ns |  0.4044 ns | 0.0222 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  45.189 ns |  0.4233 ns | 0.0232 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  15.743 ns |  0.0495 ns | 0.0027 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  70.578 ns |  0.7388 ns | 0.0405 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 174.500 ns |  1.6613 ns | 0.0911 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 202.481 ns | 13.4040 ns | 0.7347 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 197.634 ns | 17.3457 ns | 0.9508 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  61.123 ns |  2.2326 ns | 0.1224 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 287.112 ns | 40.9755 ns | 2.2460 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **70742(...)85248 [33]** | **70742(...)70496 [33]** |  **74.612 ns** |  **4.9822 ns** | **0.2731 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  76.114 ns |  3.3199 ns | 0.1820 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 205.645 ns |  5.0927 ns | 0.2791 ns | 0.0124 |     208 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  42.235 ns |  8.9349 ns | 0.4898 ns | 0.0048 |      80 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] | 105.800 ns | 29.4694 ns | 1.6153 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 205.181 ns |  4.7836 ns | 0.2622 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 229.190 ns | 14.5096 ns | 0.7953 ns | 0.0215 |     136 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 348.717 ns | 55.8194 ns | 3.0597 ns | 0.0429 |     273 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 116.211 ns | 21.1967 ns | 1.1619 ns | 0.0126 |      80 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 335.397 ns | 12.2700 ns | 0.6726 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |  **15.018 ns** |  **0.1075 ns** | **0.0059 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  15.846 ns |  0.4679 ns | 0.0256 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.290 ns |  0.3270 ns | 0.0179 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.108 ns |  0.5319 ns | 0.0292 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.164 ns |  0.6596 ns | 0.0362 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.769 ns |  2.4052 ns | 0.1318 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  42.461 ns |  0.2379 ns | 0.0130 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  30.601 ns |  0.6486 ns | 0.0356 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  24.951 ns |  0.8939 ns | 0.0490 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.047 ns |  1.7330 ns | 0.0950 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |  **15.047 ns** |  **0.3616 ns** | **0.0198 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  16.841 ns |  0.5501 ns | 0.0302 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   8.291 ns |  0.5304 ns | 0.0291 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.110 ns |  0.2677 ns | 0.0147 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.223 ns |  0.3093 ns | 0.0170 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.506 ns |  4.7482 ns | 0.2603 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  48.508 ns |  3.5005 ns | 0.1919 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.654 ns |  3.9653 ns | 0.2174 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  24.018 ns |  0.9060 ns | 0.0497 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  26.871 ns |  0.3367 ns | 0.0185 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |  **15.168 ns** |  **2.2903 ns** | **0.1255 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  16.092 ns |  1.3508 ns | 0.0740 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  36.167 ns |  0.3926 ns | 0.0215 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  15.855 ns |  1.0908 ns | 0.0598 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   6.059 ns |  0.8463 ns | 0.0464 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  30.563 ns |  4.9444 ns | 0.2710 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  41.815 ns |  1.1008 ns | 0.0603 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    | 120.476 ns | 35.4811 ns | 1.9448 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  57.220 ns |  6.3982 ns | 0.3507 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.319 ns |  3.7613 ns | 0.2062 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97/1**                 | **89/1**                 |  **25.746 ns** |  **1.0751 ns** | **0.0589 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  27.304 ns |  1.2489 ns | 0.0685 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  15.799 ns |  2.8019 ns | 0.1536 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  15.894 ns |  1.6835 ns | 0.0923 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  15.582 ns |  0.1797 ns | 0.0099 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  54.554 ns | 10.1348 ns | 0.5555 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  74.436 ns |  1.5767 ns | 0.0864 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  66.350 ns |  4.9238 ns | 0.2699 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  57.445 ns |  5.4166 ns | 0.2969 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  58.557 ns |  6.7973 ns | 0.3726 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000/1**               | **100/1**                |  **25.855 ns** |  **0.8104 ns** | **0.0444 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  27.360 ns |  0.4710 ns | 0.0258 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  15.745 ns |  0.5701 ns | 0.0312 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  15.666 ns |  0.6782 ns | 0.0372 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  15.574 ns |  2.4089 ns | 0.1320 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  53.651 ns |  1.1481 ns | 0.0629 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  74.068 ns |  1.3659 ns | 0.0749 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  64.704 ns |  2.6206 ns | 0.1436 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  59.242 ns |  8.3046 ns | 0.4552 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  49.163 ns |  0.5980 ns | 0.0328 ns |      - |         - |
