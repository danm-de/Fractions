```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4529/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.302
  [Host]   : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                     | ReduceTerms | value                | Mean       | Error       | StdDev     | Gen0   | Allocated |
|------------------------------------------- |------------ |--------------------- |-----------:|------------:|-----------:|-------:|----------:|
| **Construct_FromDouble**                       | **False**       | **NaN**                  |  **11.039 ns** |   **0.9945 ns** |  **0.0545 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | False       | NaN                  |   3.960 ns |   0.2487 ns |  0.0136 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | NaN                  |   4.731 ns |   0.3155 ns |  0.0173 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | NaN                  |   4.719 ns |   0.4605 ns |  0.0252 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **-Infinity**            |  **11.006 ns** |   **1.3336 ns** |  **0.0731 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | False       | -Infinity            |   3.808 ns |   0.0774 ns |  0.0042 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | -Infinity            |   4.994 ns |   0.8210 ns |  0.0450 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | -Infinity            |   4.914 ns |   0.2096 ns |  0.0115 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **-7.92(...)4E+28 [22]** |  **68.291 ns** |  **22.3690 ns** |  **1.2261 ns** | **0.0091** |     **152 B** |
| Construct_FromDoubleRounded                | False       | -7.92(...)4E+28 [22] |  10.191 ns |   1.2552 ns |  0.0688 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | -7.92(...)4E+28 [22] | 130.307 ns |  23.0188 ns |  1.2617 ns | 0.0048 |      80 B |
| Construct_FromDoubleRoundedToFifteenDigits | False       | -7.92(...)4E+28 [22] | 124.487 ns |  13.7018 ns |  0.7510 ns | 0.0062 |     104 B |
| **Construct_FromDouble**                       | **False**       | **-0.02702702702702703** |  **49.533 ns** |   **4.2151 ns** |  **0.2310 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                | False       | -0.02702702702702703 |   9.754 ns |   1.0502 ns |  0.0576 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | -0.02702702702702703 |  91.909 ns |   7.2086 ns |  0.3951 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | -0.02702702702702703 | 115.456 ns |   8.2672 ns |  0.4532 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **False**       | **-3.69(...)7E-06 [23]** |  **49.857 ns** |   **0.8887 ns** |  **0.0487 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                | False       | -3.69(...)7E-06 [23] |  62.215 ns |   1.8867 ns |  0.1034 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | -3.69(...)7E-06 [23] |  91.004 ns |  11.9486 ns |  0.6549 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | -3.69(...)7E-06 [23] | 101.314 ns |   3.9194 ns |  0.2148 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **0**                    |  **10.876 ns** |   **1.0251 ns** |  **0.0562 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | False       | 0                    |   4.136 ns |   0.2811 ns |  0.0154 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 0                    |   4.408 ns |   0.4593 ns |  0.0252 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 0                    |   4.377 ns |   0.4775 ns |  0.0262 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **0.022046226218487758** |  **37.736 ns** |   **3.2565 ns** |  **0.1785 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 0.022046226218487758 | 167.243 ns |  16.1363 ns |  0.8845 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 0.022046226218487758 |  92.050 ns |  20.7091 ns |  1.1351 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 0.022046226218487758 | 100.667 ns |   9.5603 ns |  0.5240 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **False**       | **0.09999999999999999**  |  **38.369 ns** |   **0.9821 ns** |  **0.0538 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 0.09999999999999999  |   9.709 ns |   0.8487 ns |  0.0465 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 0.09999999999999999  |  46.287 ns |   2.7300 ns |  0.1496 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 0.09999999999999999  |  53.413 ns |   1.5931 ns |  0.0873 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **0.3333333333333333**   |  **37.196 ns** |   **2.8534 ns** |  **0.1564 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 0.3333333333333333   |   9.552 ns |   0.1119 ns |  0.0061 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 0.3333333333333333   |  85.045 ns |   7.7540 ns |  0.4250 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 0.3333333333333333   | 121.788 ns |  18.9315 ns |  1.0377 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **False**       | **1.345**                |  **35.259 ns** |   **2.6987 ns** |  **0.1479 ns** | **0.0038** |      **64 B** |
| Construct_FromDoubleRounded                | False       | 1.345                |  41.494 ns |   1.3521 ns |  0.0741 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 1.345                |  81.250 ns |   2.8159 ns |  0.1543 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 1.345                |  89.905 ns |   2.6632 ns |  0.1460 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **3.141592653589793**    |  **50.768 ns** |   **6.5910 ns** |  **0.3613 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 3.141592653589793    | 113.411 ns |   3.2945 ns |  0.1806 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 3.141592653589793    |  89.361 ns |   7.8277 ns |  0.4291 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 3.141592653589793    | 131.827 ns |   8.0933 ns |  0.4436 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                       | **False**       | **42**                   |  **50.918 ns** |   **2.8765 ns** |  **0.1577 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 42                   |   6.502 ns |   0.8178 ns |  0.0448 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 42                   |  33.300 ns |   0.6527 ns |  0.0358 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 42                   |  33.195 ns |   2.5218 ns |  0.1382 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **2110.11170524**        |  **51.168 ns** |   **8.8853 ns** |  **0.4870 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 2110.11170524        | 131.473 ns |   6.9116 ns |  0.3789 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | 2110.11170524        |  78.427 ns |  11.2495 ns |  0.6166 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 2110.11170524        | 108.567 ns |   3.6905 ns |  0.2023 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **False**       | **1024000000000**        |  **63.511 ns** |  **21.1784 ns** |  **1.1609 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                | False       | 1024000000000        |   8.522 ns |   0.9506 ns |  0.0521 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | 1024000000000        |  86.646 ns |  28.2179 ns |  1.5467 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 1024000000000        |  38.601 ns |   4.3756 ns |  0.2398 ns | 0.0019 |      32 B |
| **Construct_FromDouble**                       | **False**       | **5.9722E+24**           |  **65.173 ns** |   **7.8373 ns** |  **0.4296 ns** | **0.0091** |     **152 B** |
| Construct_FromDoubleRounded                | False       | 5.9722E+24           |   9.910 ns |   0.2508 ns |  0.0137 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | 5.9722E+24           | 110.220 ns |   1.0921 ns |  0.0599 ns | 0.0043 |      72 B |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 5.9722E+24           | 105.749 ns |   8.8746 ns |  0.4864 ns | 0.0043 |      72 B |
| **Construct_FromDouble**                       | **False**       | **1.797(...)E+308 [23]** | **103.842 ns** |  **27.0670 ns** |  **1.4836 ns** | **0.0224** |     **376 B** |
| Construct_FromDoubleRounded                | False       | 1.797(...)E+308 [23] |  10.899 ns |   3.9420 ns |  0.2161 ns | 0.0091 |     152 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | 1.797(...)E+308 [23] | 686.804 ns | 366.3354 ns | 20.0801 ns | 0.0181 |     304 B |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 1.797(...)E+308 [23] | 711.889 ns | 501.6938 ns | 27.4995 ns | 0.0200 |     336 B |
| **Construct_FromDouble**                       | **False**       | **Infinity**             |  **11.121 ns** |   **2.8776 ns** |  **0.1577 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | False       | Infinity             |   3.681 ns |   0.7684 ns |  0.0421 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | Infinity             |   5.269 ns |  12.2797 ns |  0.6731 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | Infinity             |   5.148 ns |   7.6119 ns |  0.4172 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **NaN**                  |  **11.021 ns** |   **0.3432 ns** |  **0.0188 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | True        | NaN                  |   4.014 ns |   0.0983 ns |  0.0054 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | NaN                  |   4.837 ns |   1.5692 ns |  0.0860 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | NaN                  |   4.693 ns |   0.1218 ns |  0.0067 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **-Infinity**            |  **10.926 ns** |   **1.2091 ns** |  **0.0663 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | True        | -Infinity            |   3.778 ns |   0.4835 ns |  0.0265 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | -Infinity            |   4.915 ns |   0.6273 ns |  0.0344 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | -Infinity            |   4.909 ns |   0.6648 ns |  0.0364 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **-7.92(...)4E+28 [22]** |  **99.874 ns** |   **6.3642 ns** |  **0.3488 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                | True        | -7.92(...)4E+28 [22] |  12.392 ns |   3.3517 ns |  0.1837 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | -7.92(...)4E+28 [22] | 118.043 ns |   3.1296 ns |  0.1715 ns | 0.0048 |      80 B |
| Construct_FromDoubleRoundedToFifteenDigits | True        | -7.92(...)4E+28 [22] | 125.181 ns |  18.1090 ns |  0.9926 ns | 0.0062 |     104 B |
| **Construct_FromDouble**                       | **True**        | **-0.02702702702702703** | **117.074 ns** |  **13.9250 ns** |  **0.7633 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                | True        | -0.02702702702702703 |  13.217 ns |   1.3698 ns |  0.0751 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | -0.02702702702702703 | 103.377 ns |  14.9742 ns |  0.8208 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | -0.02702702702702703 | 149.822 ns |  18.2927 ns |  1.0027 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **True**        | **-3.69(...)7E-06 [23]** | **142.521 ns** |   **5.8304 ns** |  **0.3196 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                | True        | -3.69(...)7E-06 [23] |  79.931 ns |   6.9924 ns |  0.3833 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | -3.69(...)7E-06 [23] | 107.807 ns |  12.6950 ns |  0.6959 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | -3.69(...)7E-06 [23] | 116.182 ns |  16.4465 ns |  0.9015 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **0**                    |  **11.149 ns** |   **0.1358 ns** |  **0.0074 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | True        | 0                    |   4.174 ns |   0.7106 ns |  0.0390 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 0                    |   4.384 ns |   0.2976 ns |  0.0163 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 0                    |   4.357 ns |   0.5986 ns |  0.0328 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **0.022046226218487758** | **210.895 ns** |   **6.9236 ns** |  **0.3795 ns** | **0.0095** |     **160 B** |
| Construct_FromDoubleRounded                | True        | 0.022046226218487758 | 190.993 ns |   9.0919 ns |  0.4984 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 0.022046226218487758 | 144.508 ns |  21.0082 ns |  1.1515 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 0.022046226218487758 | 197.112 ns |  26.1490 ns |  1.4333 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                       | **True**        | **0.09999999999999999**  |  **83.477 ns** |   **0.6314 ns** |  **0.0346 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | True        | 0.09999999999999999  |  12.734 ns |   3.8391 ns |  0.2104 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 0.09999999999999999  |  53.287 ns |   1.9300 ns |  0.1058 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 0.09999999999999999  |  57.919 ns |   4.7757 ns |  0.2618 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **0.3333333333333333**   |  **75.709 ns** |   **2.6908 ns** |  **0.1475 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | True        | 0.3333333333333333   |  12.210 ns |   0.6933 ns |  0.0380 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 0.3333333333333333   |  95.932 ns |   4.6179 ns |  0.2531 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 0.3333333333333333   | 133.310 ns |  14.7550 ns |  0.8088 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **True**        | **1.345**                | **105.032 ns** |   **9.3199 ns** |  **0.5109 ns** | **0.0038** |      **64 B** |
| Construct_FromDoubleRounded                | True        | 1.345                |  55.110 ns |   2.7766 ns |  0.1522 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 1.345                | 114.019 ns |   6.0092 ns |  0.3294 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 1.345                | 121.056 ns |   6.6724 ns |  0.3657 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **3.141592653589793**    | **223.481 ns** |   **4.4057 ns** |  **0.2415 ns** | **0.0134** |     **224 B** |
| Construct_FromDoubleRounded                | True        | 3.141592653589793    | 131.427 ns |  15.9316 ns |  0.8733 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 3.141592653589793    | 119.680 ns |   5.4861 ns |  0.3007 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 3.141592653589793    | 201.358 ns |  16.7724 ns |  0.9194 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                       | **True**        | **42**                   | **113.790 ns** |   **4.2476 ns** |  **0.2328 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | True        | 42                   |   7.716 ns |   0.9819 ns |  0.0538 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 42                   |  33.672 ns |   1.0068 ns |  0.0552 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 42                   |  33.891 ns |   7.3011 ns |  0.4002 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **2110.11170524**        | **175.691 ns** |  **16.6625 ns** |  **0.9133 ns** | **0.0095** |     **160 B** |
| Construct_FromDoubleRounded                | True        | 2110.11170524        | 143.830 ns |  18.2601 ns |  1.0009 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | 2110.11170524        |  99.134 ns |   8.8925 ns |  0.4874 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 2110.11170524        | 171.464 ns | 185.3595 ns | 10.1602 ns | 0.0057 |      96 B |
| **Construct_FromDouble**                       | **True**        | **1024000000000**        | **151.023 ns** |  **12.1799 ns** |  **0.6676 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                | True        | 1024000000000        |   9.787 ns |   3.4604 ns |  0.1897 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | 1024000000000        |  87.719 ns |  13.8990 ns |  0.7619 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 1024000000000        |  37.702 ns |   3.7138 ns |  0.2036 ns | 0.0019 |      32 B |
| **Construct_FromDouble**                       | **True**        | **5.9722E+24**           | **220.440 ns** |  **14.7852 ns** |  **0.8104 ns** | **0.0134** |     **224 B** |
| Construct_FromDoubleRounded                | True        | 5.9722E+24           |  11.477 ns |   1.3058 ns |  0.0716 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | 5.9722E+24           | 110.200 ns |  13.7255 ns |  0.7523 ns | 0.0043 |      72 B |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 5.9722E+24           | 106.414 ns |   8.0010 ns |  0.4386 ns | 0.0043 |      72 B |
| **Construct_FromDouble**                       | **True**        | **1.797(...)E+308 [23]** | **359.894 ns** |  **57.0684 ns** |  **3.1281 ns** | **0.0334** |     **560 B** |
| Construct_FromDoubleRounded                | True        | 1.797(...)E+308 [23] |  12.904 ns |   3.1300 ns |  0.1716 ns | 0.0091 |     152 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | 1.797(...)E+308 [23] | 672.669 ns | 296.0528 ns | 16.2277 ns | 0.0181 |     304 B |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 1.797(...)E+308 [23] | 694.907 ns | 121.8652 ns |  6.6798 ns | 0.0200 |     336 B |
| **Construct_FromDouble**                       | **True**        | **Infinity**             |  **10.963 ns** |   **0.9419 ns** |  **0.0516 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | True        | Infinity             |   3.622 ns |   0.2430 ns |  0.0133 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | Infinity             |   4.715 ns |   0.5641 ns |  0.0309 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | Infinity             |   4.757 ns |   0.6608 ns |  0.0362 ns |      - |         - |
