```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4529/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method   | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|--------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **50.347 ns** |  **2.0741 ns** | **0.1137 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  52.650 ns |  3.1067 ns | 0.1703 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |   9.680 ns |  0.5845 ns | 0.0320 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  37.935 ns |  0.3255 ns | 0.0178 ns | 0.0029 |      48 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  66.600 ns |  2.6955 ns | 0.1478 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 121.931 ns | 13.3578 ns | 0.7322 ns | 0.0153 |      96 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 133.795 ns |  7.6294 ns | 0.4182 ns | 0.0153 |      96 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  37.964 ns |  1.7277 ns | 0.0947 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      |  89.065 ns | 12.7607 ns | 0.6995 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 157.781 ns | 17.2612 ns | 0.9461 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024/1**              | **-1/1024**              |  **32.089 ns** |  **4.4466 ns** | **0.2437 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  33.793 ns |  2.1104 ns | 0.1157 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  12.492 ns |  1.1892 ns | 0.0652 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  20.990 ns |  1.9645 ns | 0.1077 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  34.212 ns |  1.1612 ns | 0.0637 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  71.895 ns |  1.6376 ns | 0.0898 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  95.808 ns |  5.8011 ns | 0.3180 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  48.786 ns |  0.6996 ns | 0.0383 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  54.684 ns |  0.2886 ns | 0.0158 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              | 126.193 ns | 22.5796 ns | 1.2377 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45/1**                | **1/6**                  |  **32.083 ns** |  **2.1647 ns** | **0.1187 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  33.805 ns |  1.1418 ns | 0.0626 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |   9.630 ns |  1.0285 ns | 0.0564 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  20.822 ns |  0.5276 ns | 0.0289 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  33.994 ns |  1.3212 ns | 0.0724 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  71.764 ns |  1.4730 ns | 0.0807 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  92.883 ns |  6.0379 ns | 0.3310 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  38.074 ns |  4.6685 ns | 0.2559 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  54.636 ns |  2.9933 ns | 0.1641 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 119.981 ns |  0.7305 ns | 0.0400 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **26.979 ns** |  **0.7378 ns** | **0.0404 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  28.052 ns |  4.4860 ns | 0.2459 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  17.626 ns |  0.5124 ns | 0.0281 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  13.735 ns |  0.5024 ns | 0.0275 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  14.926 ns |  0.1968 ns | 0.0108 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  61.668 ns |  1.8571 ns | 0.1018 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  74.849 ns |  0.7405 ns | 0.0406 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  66.822 ns |  2.2991 ns | 0.1260 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  35.381 ns |  0.7190 ns | 0.0394 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               |  47.932 ns |  0.5718 ns | 0.0313 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0/1**                  | **1/1**                  |  **15.002 ns** |  **1.3619 ns** | **0.0746 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |  15.897 ns |  2.2354 ns | 0.1225 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |   7.375 ns |  0.4905 ns | 0.0269 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |  12.389 ns |  1.0993 ns | 0.0603 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |  11.185 ns |  1.6234 ns | 0.0890 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  27.537 ns |  0.9245 ns | 0.0507 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  42.723 ns |  1.3468 ns | 0.0738 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  27.742 ns |  2.3404 ns | 0.1283 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  31.845 ns |  0.3297 ns | 0.0181 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  30.619 ns |  3.3093 ns | 0.1814 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **24.908 ns** |  **3.2663 ns** | **0.1790 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  27.670 ns |  0.6485 ns | 0.0355 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  17.857 ns |  0.1716 ns | 0.0094 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  12.468 ns |  1.8301 ns | 0.1003 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  14.986 ns |  0.6629 ns | 0.0363 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  55.118 ns |  2.4406 ns | 0.1338 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  75.586 ns |  4.7449 ns | 0.2601 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  75.501 ns |  1.8787 ns | 0.1030 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  34.312 ns |  0.7731 ns | 0.0424 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  47.772 ns |  3.2670 ns | 0.1791 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |  **25.795 ns** |  **3.5538 ns** | **0.1948 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  31.726 ns | 65.9781 ns | 3.6165 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  17.981 ns |  0.5177 ns | 0.0284 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  12.692 ns |  1.1424 ns | 0.0626 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  14.935 ns |  0.7991 ns | 0.0438 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  54.662 ns |  1.6295 ns | 0.0893 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  75.297 ns | 11.8887 ns | 0.6517 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  67.331 ns |  7.2095 ns | 0.3952 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  34.094 ns |  3.9447 ns | 0.2162 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  48.490 ns |  1.4282 ns | 0.0783 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **54.731 ns** |  **2.1091 ns** | **0.1156 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  55.426 ns |  2.8887 ns | 0.1583 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  17.856 ns |  0.6602 ns | 0.0362 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  38.633 ns |  1.2962 ns | 0.0710 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  45.669 ns |  1.9968 ns | 0.1095 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 175.978 ns |  4.0116 ns | 0.2199 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 213.535 ns |  9.8113 ns | 0.5378 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  67.443 ns | 13.7972 ns | 0.7563 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 151.607 ns | 60.3995 ns | 3.3107 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 196.233 ns | 26.3958 ns | 1.4468 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **55.112 ns** |  **6.5914 ns** | **0.3613 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  57.071 ns |  1.5215 ns | 0.0834 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  17.411 ns |  2.4363 ns | 0.1335 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  43.531 ns |  4.1463 ns | 0.2273 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  47.185 ns |  2.4957 ns | 0.1368 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 175.138 ns |  2.9643 ns | 0.1625 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 207.414 ns |  3.8447 ns | 0.2107 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                |  67.190 ns |  3.3425 ns | 0.1832 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 157.439 ns |  6.7523 ns | 0.3701 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 199.641 ns | 10.6266 ns | 0.5825 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **14148(...)70496 [34]** | **70742(...)70496 [33]** |  **31.855 ns** |  **3.4570 ns** | **0.1895 ns** | **0.0019** |      **32 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |  33.722 ns |  1.0533 ns | 0.0577 ns | 0.0019 |      32 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |  45.822 ns |  1.7046 ns | 0.0934 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |  13.240 ns |  0.9896 ns | 0.0542 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 14148(...)70496 [34] | 70742(...)70496 [33] |  26.735 ns |  2.5742 ns | 0.1411 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  74.185 ns |  0.8376 ns | 0.0459 ns | 0.0063 |      40 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  94.187 ns |  3.5504 ns | 0.1946 ns | 0.0050 |      32 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] | 124.568 ns | 19.4815 ns | 1.0678 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  37.194 ns |  0.3782 ns | 0.0207 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 14148(...)70496 [34] | 70742(...)70496 [33] |  74.549 ns |  2.8339 ns | 0.1553 ns | 0.0050 |      32 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |  **15.181 ns** |  **0.4933 ns** | **0.0270 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  16.115 ns |  2.6481 ns | 0.1452 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.352 ns |  0.4861 ns | 0.0266 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  11.838 ns |  1.0401 ns | 0.0570 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  11.452 ns |  3.2280 ns | 0.1769 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.927 ns |  0.1794 ns | 0.0098 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  42.824 ns |  3.2121 ns | 0.1761 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  30.830 ns |  1.3964 ns | 0.0765 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  28.495 ns |  3.7135 ns | 0.2036 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  29.584 ns |  2.2453 ns | 0.1231 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |  **15.190 ns** |  **1.3652 ns** | **0.0748 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  16.866 ns |  1.2260 ns | 0.0672 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   8.679 ns |  8.5308 ns | 0.4676 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  11.859 ns |  0.4502 ns | 0.0247 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  11.097 ns |  0.2171 ns | 0.0119 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  31.573 ns |  9.3029 ns | 0.5099 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  45.411 ns |  3.4338 ns | 0.1882 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.790 ns |  1.0208 ns | 0.0560 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  28.316 ns |  0.7063 ns | 0.0387 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  29.750 ns |  1.2787 ns | 0.0701 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |  **15.318 ns** |  **1.9767 ns** | **0.1083 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  16.223 ns |  0.9187 ns | 0.0504 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.496 ns |  2.3397 ns | 0.1282 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  12.127 ns |  2.5321 ns | 0.1388 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  11.329 ns |  0.5410 ns | 0.0297 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.571 ns |  0.0674 ns | 0.0037 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  42.671 ns |  0.8410 ns | 0.0461 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  28.120 ns |  2.9131 ns | 0.1597 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  36.834 ns |  0.4666 ns | 0.0256 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  30.291 ns |  0.7893 ns | 0.0433 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97/1**                 | **89/1**                 |  **25.635 ns** |  **1.9253 ns** | **0.1055 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  27.308 ns |  1.5837 ns | 0.0868 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  12.839 ns |  8.5396 ns | 0.4681 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  12.464 ns |  2.5117 ns | 0.1377 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  14.984 ns |  0.9491 ns | 0.0520 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  55.315 ns |  2.8513 ns | 0.1563 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  74.886 ns |  2.4670 ns | 0.1352 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  50.724 ns |  1.9329 ns | 0.1059 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  35.055 ns |  1.9150 ns | 0.1050 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  54.804 ns |  1.3315 ns | 0.0730 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000/1**               | **100/1**                |  **25.788 ns** |  **0.5409 ns** | **0.0296 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  27.357 ns |  0.2622 ns | 0.0144 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  12.436 ns |  1.7510 ns | 0.0960 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  12.449 ns |  2.8950 ns | 0.1587 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  14.943 ns |  1.3779 ns | 0.0755 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  54.846 ns |  4.4864 ns | 0.2459 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  75.362 ns |  8.2670 ns | 0.4531 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  50.908 ns |  1.5318 ns | 0.0840 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  34.867 ns |  0.6515 ns | 0.0357 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  48.709 ns |  1.6529 ns | 0.0906 ns |      - |         - |
