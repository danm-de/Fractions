```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.100
  [Host]                      : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 9.0           : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9282.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method   | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|--------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **55.020 ns** |  **2.0968 ns** | **0.1149 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)000/1 [41] | 1/1000000000000      |  56.429 ns |  3.3509 ns | 0.1837 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)000/1 [41] | 1/1000000000000      |   8.291 ns |  0.5904 ns | 0.0324 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)000/1 [41] | 1/1000000000000      |  41.286 ns |  1.7261 ns | 0.0946 ns | 0.0029 |      48 B |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)000/1 [41] | 1/1000000000000      |  71.441 ns | 51.2605 ns | 2.8098 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 121.078 ns |  6.0844 ns | 0.3335 ns | 0.0153 |      96 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 133.977 ns |  3.8662 ns | 0.2119 ns | 0.0153 |      96 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  38.549 ns |  0.5963 ns | 0.0327 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  86.808 ns |  1.6604 ns | 0.0910 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 174.844 ns |  7.6897 ns | 0.4215 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1024/1**              | **-1/1024**              |  **18.376 ns** |  **1.2889 ns** | **0.0707 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | -1024/1              | -1/1024              |  19.575 ns |  1.8734 ns | 0.1027 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | -1024/1              | -1/1024              |   8.856 ns |  0.8967 ns | 0.0492 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | -1024/1              | -1/1024              |  14.617 ns |  0.7783 ns | 0.0427 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | -1024/1              | -1/1024              |  31.398 ns |  0.5927 ns | 0.0325 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  71.554 ns |  3.8153 ns | 0.2091 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  90.017 ns |  4.0783 ns | 0.2235 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  49.365 ns |  1.9629 ns | 0.1076 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  54.535 ns |  3.3285 ns | 0.1824 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              | 149.386 ns |  7.1416 ns | 0.3915 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-45/1**                | **1/6**                  |  **18.249 ns** |  **0.8244 ns** | **0.0452 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | -45/1                | 1/6                  |  19.998 ns |  0.4626 ns | 0.0254 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | -45/1                | 1/6                  |   7.818 ns |  0.1193 ns | 0.0065 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | -45/1                | 1/6                  |  14.657 ns | 12.7398 ns | 0.6983 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | -45/1                | 1/6                  |  30.627 ns |  4.8502 ns | 0.2659 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  68.891 ns |  2.0086 ns | 0.1101 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  91.107 ns |  2.6148 ns | 0.1433 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  37.666 ns |  3.5773 ns | 0.1961 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  60.254 ns |  2.3266 ns | 0.1275 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 137.053 ns |  1.9574 ns | 0.1073 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **42/-96**               | **36/-96**               |  **18.536 ns** |  **0.5029 ns** | **0.0276 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 42/-96               | 36/-96               |  19.739 ns |  3.5795 ns | 0.1962 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 42/-96               | 36/-96               |   9.835 ns |  2.1100 ns | 0.1157 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 42/-96               | 36/-96               |  14.137 ns |  1.2053 ns | 0.0661 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 42/-96               | 36/-96               |  18.099 ns |  0.2602 ns | 0.0143 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  54.747 ns |  0.3588 ns | 0.0197 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  74.226 ns |  4.2861 ns | 0.2349 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  66.824 ns |  2.8623 ns | 0.1569 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  37.449 ns |  0.8257 ns | 0.0453 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  48.382 ns |  1.7045 ns | 0.0934 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **0/1**                  | **1/1**                  |  **15.504 ns** |  **0.8503 ns** | **0.0466 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 0/1                  | 1/1                  |  15.916 ns |  0.6710 ns | 0.0368 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 0/1                  | 1/1                  |   6.983 ns |  0.1086 ns | 0.0060 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 0/1                  | 1/1                  |  13.010 ns |  1.0203 ns | 0.0559 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 0/1                  | 1/1                  |  11.464 ns |  1.2620 ns | 0.0692 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  27.792 ns |  1.4963 ns | 0.0820 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  42.819 ns |  1.5069 ns | 0.0826 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  28.475 ns |  4.4269 ns | 0.2427 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  31.599 ns |  0.4150 ns | 0.0227 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  30.216 ns |  0.4774 ns | 0.0262 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **77/3600**              | **37/3600**              |  **17.609 ns** |  **3.7515 ns** | **0.2056 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |  19.049 ns |  0.4098 ns | 0.0225 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |   9.902 ns |  1.5037 ns | 0.0824 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |  12.691 ns |  1.0214 ns | 0.0560 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |  18.541 ns |  0.7951 ns | 0.0436 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  55.299 ns |  2.2085 ns | 0.1211 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  74.999 ns |  1.5001 ns | 0.0822 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  66.882 ns |  3.3086 ns | 0.1814 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  33.213 ns |  1.6454 ns | 0.0902 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  48.125 ns |  1.2577 ns | 0.0689 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **135/1000**             | **76/1000**              |  **17.561 ns** |  **0.7525 ns** | **0.0412 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 135/1000             | 76/1000              |  18.961 ns |  1.1737 ns | 0.0643 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 135/1000             | 76/1000              |  11.277 ns |  1.1142 ns | 0.0611 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 135/1000             | 76/1000              |  13.031 ns |  3.4310 ns | 0.1881 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 135/1000             | 76/1000              |  18.239 ns |  0.2820 ns | 0.0155 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  54.964 ns |  2.0908 ns | 0.1146 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  74.683 ns |  0.7565 ns | 0.0415 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  66.322 ns |  1.1171 ns | 0.0612 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  34.298 ns |  1.3623 ns | 0.0747 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  48.243 ns |  0.4834 ns | 0.0265 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **27/200**               | **19/250**               |  **32.659 ns** |  **1.9950 ns** | **0.1094 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |  34.136 ns |  2.5299 ns | 0.1387 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |   9.907 ns |  1.7282 ns | 0.0947 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |  26.841 ns |  4.4291 ns | 0.2428 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |  39.847 ns |  0.8812 ns | 0.0483 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 217.025 ns |  5.4690 ns | 0.2998 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 231.210 ns |  3.7547 ns | 0.2058 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  66.494 ns |  5.2423 ns | 0.2873 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 166.155 ns |  4.7583 ns | 0.2608 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 213.733 ns | 50.5775 ns | 2.7723 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **42/66**                | **36/96**                |  **32.970 ns** |  **0.4852 ns** | **0.0266 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 42/66                | 36/96                |  33.216 ns |  1.0329 ns | 0.0566 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 42/66                | 36/96                |   9.847 ns |  2.0178 ns | 0.1106 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 42/66                | 36/96                |  27.008 ns |  3.6182 ns | 0.1983 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 42/66                | 36/96                |  42.604 ns |  0.0880 ns | 0.0048 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 216.719 ns |  3.3242 ns | 0.1822 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 229.861 ns |  2.3970 ns | 0.1314 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  66.715 ns |  2.1708 ns | 0.1190 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 166.806 ns |  9.3556 ns | 0.5128 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 203.229 ns |  3.1734 ns | 0.1739 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **14148(...)70496 [34]** | **70742(...)70496 [33]** |  **26.495 ns** |  **2.1180 ns** | **0.1161 ns** | **0.0019** |      **32 B** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |  28.038 ns |  1.8495 ns | 0.1014 ns | 0.0019 |      32 B |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |  46.517 ns |  0.9944 ns | 0.0545 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |  13.473 ns |  1.0514 ns | 0.0576 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |  33.131 ns |  5.1899 ns | 0.2845 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  77.454 ns |  3.0208 ns | 0.1656 ns | 0.0063 |      40 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  94.022 ns |  2.9921 ns | 0.1640 ns | 0.0050 |      32 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] | 126.436 ns |  3.9061 ns | 0.2141 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  36.705 ns |  3.0403 ns | 0.1666 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  75.140 ns |  1.0610 ns | 0.0582 ns | 0.0050 |      32 B |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **NaN**                  |  **15.666 ns** |  **0.2001 ns** | **0.0110 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |  16.175 ns |  0.1821 ns | 0.0100 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |   8.884 ns |  0.0865 ns | 0.0047 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |  12.679 ns |  2.0483 ns | 0.1123 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |  11.457 ns |  1.5449 ns | 0.0847 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.868 ns |  2.1958 ns | 0.1204 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  41.724 ns |  0.8050 ns | 0.0441 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  31.231 ns |  0.3273 ns | 0.0179 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  28.522 ns |  2.9078 ns | 0.1594 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  30.018 ns |  1.4963 ns | 0.0820 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **-∞**                   |  **15.689 ns** |  **0.4286 ns** | **0.0235 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |  16.164 ns |  0.2224 ns | 0.0122 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |   7.951 ns |  0.4947 ns | 0.0271 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |  12.420 ns |  1.7185 ns | 0.0942 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |  11.487 ns |  1.5415 ns | 0.0845 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.538 ns |  0.4314 ns | 0.0236 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  45.014 ns |  3.1001 ns | 0.1699 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  31.377 ns |  0.0214 ns | 0.0012 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  31.055 ns |  0.7413 ns | 0.0406 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  29.710 ns |  0.2331 ns | 0.0128 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **0**                    |  **15.631 ns** |  **1.7841 ns** | **0.0978 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |  15.988 ns |  0.0144 ns | 0.0008 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |   7.720 ns |  0.0354 ns | 0.0019 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |  12.641 ns |  1.4753 ns | 0.0809 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |  11.477 ns |  1.3473 ns | 0.0739 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.684 ns |  3.1467 ns | 0.1725 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  41.996 ns |  1.2355 ns | 0.0677 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  28.255 ns |  3.1728 ns | 0.1739 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  35.763 ns |  0.6539 ns | 0.0358 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  30.281 ns |  0.8897 ns | 0.0488 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **97/1**                 | **89/1**                 |  **17.520 ns** |  **0.1251 ns** | **0.0069 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 97/1                 | 89/1                 |  19.241 ns |  0.6025 ns | 0.0330 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 97/1                 | 89/1                 |  10.500 ns |  2.4826 ns | 0.1361 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 97/1                 | 89/1                 |  13.607 ns | 10.3158 ns | 0.5654 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 97/1                 | 89/1                 |  18.355 ns |  0.1409 ns | 0.0077 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  55.630 ns |  2.2914 ns | 0.1256 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  75.147 ns |  2.6344 ns | 0.1444 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  51.266 ns |  9.8896 ns | 0.5421 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  34.788 ns |  1.7958 ns | 0.0984 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  49.954 ns |  5.4339 ns | 0.2978 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **1000/1**               | **100/1**                |  **17.611 ns** |  **0.1568 ns** | **0.0086 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 1000/1               | 100/1                |  19.265 ns |  1.5320 ns | 0.0840 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 1000/1               | 100/1                |   8.937 ns |  2.4664 ns | 0.1352 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 1000/1               | 100/1                |  13.160 ns |  2.8164 ns | 0.1544 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 1000/1               | 100/1                |  18.414 ns |  0.3159 ns | 0.0173 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  54.450 ns |  2.8503 ns | 0.1562 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  74.994 ns |  3.5655 ns | 0.1954 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  49.926 ns |  5.7506 ns | 0.3152 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  34.620 ns |  4.6446 ns | 0.2546 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  48.742 ns |  5.4471 ns | 0.2986 ns |      - |         - |
