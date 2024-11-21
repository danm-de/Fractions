```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                     | ReduceTerms | value                | Mean       | Error       | StdDev     | Gen0   | Allocated |
|------------------------------------------- |------------ |--------------------- |-----------:|------------:|-----------:|-------:|----------:|
| **Construct_FromDouble**                       | **False**       | **NaN**                  |   **6.780 ns** |   **0.0918 ns** |  **0.0050 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | False       | NaN                  |   3.500 ns |   0.0254 ns |  0.0014 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | NaN                  |   3.755 ns |   0.3568 ns |  0.0196 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | NaN                  |   3.753 ns |   0.0511 ns |  0.0028 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **-Infinity**            |   **7.128 ns** |   **6.0023 ns** |  **0.3290 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | False       | -Infinity            |   3.376 ns |   0.0226 ns |  0.0012 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | -Infinity            |   3.955 ns |   0.2609 ns |  0.0143 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | -Infinity            |   3.949 ns |   0.0729 ns |  0.0040 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **-7.92(...)4E+28 [22]** |  **74.902 ns** |  **38.2231 ns** |  **2.0951 ns** | **0.0091** |     **152 B** |
| Construct_FromDoubleRounded                | False       | -7.92(...)4E+28 [22] |   9.181 ns |   1.4608 ns |  0.0801 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | -7.92(...)4E+28 [22] | 125.280 ns |   5.6737 ns |  0.3110 ns | 0.0048 |      80 B |
| Construct_FromDoubleRoundedToFifteenDigits | False       | -7.92(...)4E+28 [22] | 112.951 ns |   1.2395 ns |  0.0679 ns | 0.0062 |     104 B |
| **Construct_FromDouble**                       | **False**       | **-0.02702702702702703** |  **59.454 ns** |   **2.5522 ns** |  **0.1399 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                | False       | -0.02702702702702703 |   8.716 ns |   0.1741 ns |  0.0095 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | -0.02702702702702703 |  86.072 ns |   1.0010 ns |  0.0549 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | -0.02702702702702703 | 105.542 ns |   1.4680 ns |  0.0805 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **False**       | **-3.69(...)7E-06 [23]** |  **59.984 ns** |   **4.7912 ns** |  **0.2626 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                | False       | -3.69(...)7E-06 [23] |  55.775 ns |   2.9668 ns |  0.1626 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | -3.69(...)7E-06 [23] |  90.816 ns |   3.9827 ns |  0.2183 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | -3.69(...)7E-06 [23] |  98.576 ns |   3.9081 ns |  0.2142 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **0**                    |   **6.751 ns** |   **0.0739 ns** |  **0.0040 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | False       | 0                    |   3.717 ns |   4.1841 ns |  0.2293 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 0                    |   3.572 ns |   0.1441 ns |  0.0079 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 0                    |   3.586 ns |   0.0285 ns |  0.0016 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **0.022046226218487758** |  **47.982 ns** |   **2.6982 ns** |  **0.1479 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 0.022046226218487758 | 177.229 ns |   5.8307 ns |  0.3196 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 0.022046226218487758 |  86.999 ns |   1.9235 ns |  0.1054 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 0.022046226218487758 | 113.962 ns |  34.9349 ns |  1.9149 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **False**       | **0.09999999999999999**  |  **46.736 ns** |   **1.0831 ns** |  **0.0594 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 0.09999999999999999  |   9.054 ns |   4.1751 ns |  0.2289 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 0.09999999999999999  |  49.091 ns |   1.9930 ns |  0.1092 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 0.09999999999999999  |  56.133 ns |   3.8644 ns |  0.2118 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **0.3333333333333333**   |  **48.663 ns** |   **2.1968 ns** |  **0.1204 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 0.3333333333333333   |   8.731 ns |   0.5014 ns |  0.0275 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 0.3333333333333333   |  82.614 ns |   8.2139 ns |  0.4502 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 0.3333333333333333   | 106.800 ns |  27.7344 ns |  1.5202 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **False**       | **1.345**                |  **32.541 ns** |   **4.3544 ns** |  **0.2387 ns** | **0.0038** |      **64 B** |
| Construct_FromDoubleRounded                | False       | 1.345                |  44.374 ns |   1.2895 ns |  0.0707 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 1.345                |  80.987 ns |   4.4865 ns |  0.2459 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 1.345                |  91.187 ns |  63.2759 ns |  3.4684 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **3.141592653589793**    |  **48.414 ns** |   **3.9185 ns** |  **0.2148 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 3.141592653589793    | 121.386 ns |  31.0894 ns |  1.7041 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 3.141592653589793    |  87.256 ns |   0.5220 ns |  0.0286 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 3.141592653589793    | 132.519 ns | 247.9593 ns | 13.5915 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                       | **False**       | **42**                   |  **48.722 ns** |   **7.4818 ns** |  **0.4101 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 42                   |   6.215 ns |   5.3043 ns |  0.2907 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | 42                   |  31.027 ns |   1.4495 ns |  0.0795 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 42                   |  31.618 ns |   1.3608 ns |  0.0746 ns |      - |         - |
| **Construct_FromDouble**                       | **False**       | **2110.11170524**        |  **47.970 ns** |   **2.4830 ns** |  **0.1361 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | False       | 2110.11170524        | 139.198 ns |  26.5325 ns |  1.4543 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | 2110.11170524        |  78.146 ns |   2.0022 ns |  0.1097 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 2110.11170524        | 100.363 ns |   6.0348 ns |  0.3308 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **False**       | **1024000000000**        |  **66.646 ns** |   **2.8472 ns** |  **0.1561 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                | False       | 1024000000000        |   8.277 ns |   9.0911 ns |  0.4983 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | 1024000000000        |  90.848 ns |   8.4447 ns |  0.4629 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 1024000000000        |  40.801 ns |   2.5511 ns |  0.1398 ns | 0.0019 |      32 B |
| **Construct_FromDouble**                       | **False**       | **5.9722E+24**           |  **68.663 ns** |   **4.8954 ns** |  **0.2683 ns** | **0.0091** |     **152 B** |
| Construct_FromDoubleRounded                | False       | 5.9722E+24           |   8.989 ns |   1.6179 ns |  0.0887 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | 5.9722E+24           | 104.937 ns |   0.8581 ns |  0.0470 ns | 0.0043 |      72 B |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 5.9722E+24           |  96.385 ns |   6.2326 ns |  0.3416 ns | 0.0043 |      72 B |
| **Construct_FromDouble**                       | **False**       | **1.797(...)E+308 [23]** | **108.037 ns** |  **10.3334 ns** |  **0.5664 ns** | **0.0224** |     **376 B** |
| Construct_FromDoubleRounded                | False       | 1.797(...)E+308 [23] |  10.115 ns |   1.1014 ns |  0.0604 ns | 0.0091 |     152 B |
| Construct_FromDoubleRoundedToEightDigits   | False       | 1.797(...)E+308 [23] | 578.463 ns |  16.7175 ns |  0.9163 ns | 0.0181 |     304 B |
| Construct_FromDoubleRoundedToFifteenDigits | False       | 1.797(...)E+308 [23] | 675.969 ns |  31.7261 ns |  1.7390 ns | 0.0200 |     336 B |
| **Construct_FromDouble**                       | **False**       | **Infinity**             |   **6.815 ns** |   **0.2448 ns** |  **0.0134 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | False       | Infinity             |   3.234 ns |   0.7037 ns |  0.0386 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | False       | Infinity             |   3.960 ns |   0.3253 ns |  0.0178 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | False       | Infinity             |   3.956 ns |   0.2954 ns |  0.0162 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **NaN**                  |   **6.756 ns** |   **0.1359 ns** |  **0.0075 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | True        | NaN                  |   3.500 ns |   0.1476 ns |  0.0081 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | NaN                  |   3.783 ns |   0.5587 ns |  0.0306 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | NaN                  |   3.775 ns |   0.4929 ns |  0.0270 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **-Infinity**            |   **6.772 ns** |   **0.4255 ns** |  **0.0233 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | True        | -Infinity            |   3.367 ns |   0.1889 ns |  0.0104 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | -Infinity            |   3.977 ns |   0.5198 ns |  0.0285 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | -Infinity            |   3.945 ns |   0.3227 ns |  0.0177 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **-7.92(...)4E+28 [22]** |  **99.766 ns** |   **2.5240 ns** |  **0.1384 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                | True        | -7.92(...)4E+28 [22] |   9.783 ns |   1.6420 ns |  0.0900 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | -7.92(...)4E+28 [22] | 122.126 ns |  17.8257 ns |  0.9771 ns | 0.0048 |      80 B |
| Construct_FromDoubleRoundedToFifteenDigits | True        | -7.92(...)4E+28 [22] | 113.202 ns |   1.1536 ns |  0.0632 ns | 0.0062 |     104 B |
| **Construct_FromDouble**                       | **True**        | **-0.02702702702702703** | **116.347 ns** |  **10.9401 ns** |  **0.5997 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                | True        | -0.02702702702702703 |  10.457 ns |   0.2608 ns |  0.0143 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | -0.02702702702702703 |  90.552 ns |   1.2731 ns |  0.0698 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | -0.02702702702702703 | 140.814 ns | 172.8383 ns |  9.4738 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **True**        | **-3.69(...)7E-06 [23]** | **137.070 ns** |   **5.7960 ns** |  **0.3177 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                | True        | -3.69(...)7E-06 [23] |  61.680 ns |   4.2862 ns |  0.2349 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | -3.69(...)7E-06 [23] |  93.233 ns |   5.7250 ns |  0.3138 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | -3.69(...)7E-06 [23] | 101.235 ns |  22.3952 ns |  1.2276 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **0**                    |   **6.754 ns** |   **0.1274 ns** |  **0.0070 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | True        | 0                    |   3.578 ns |   0.2296 ns |  0.0126 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 0                    |   3.577 ns |   0.6320 ns |  0.0346 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 0                    |   3.572 ns |   0.1130 ns |  0.0062 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **0.022046226218487758** | **199.791 ns** |   **5.6910 ns** |  **0.3119 ns** | **0.0095** |     **160 B** |
| Construct_FromDoubleRounded                | True        | 0.022046226218487758 | 192.649 ns |  13.9746 ns |  0.7660 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 0.022046226218487758 | 141.711 ns |  13.5276 ns |  0.7415 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 0.022046226218487758 | 208.219 ns |  69.3015 ns |  3.7987 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                       | **True**        | **0.09999999999999999**  |  **79.897 ns** |   **7.5793 ns** |  **0.4154 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | True        | 0.09999999999999999  |  10.552 ns |   1.5185 ns |  0.0832 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 0.09999999999999999  |  54.010 ns |   6.0302 ns |  0.3305 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 0.09999999999999999  |  60.488 ns |   9.3094 ns |  0.5103 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **0.3333333333333333**   |  **77.428 ns** |  **35.8732 ns** |  **1.9663 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | True        | 0.3333333333333333   |  10.606 ns |   2.4239 ns |  0.1329 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 0.3333333333333333   |  89.199 ns |  32.6903 ns |  1.7919 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 0.3333333333333333   | 131.889 ns |  72.6992 ns |  3.9849 ns | 0.0038 |      64 B |
| **Construct_FromDouble**                       | **True**        | **1.345**                | **100.998 ns** |   **2.5871 ns** |  **0.1418 ns** | **0.0038** |      **64 B** |
| Construct_FromDoubleRounded                | True        | 1.345                |  55.486 ns |   4.8294 ns |  0.2647 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 1.345                | 117.611 ns |  24.2941 ns |  1.3316 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 1.345                | 124.955 ns |  54.1972 ns |  2.9707 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **3.141592653589793**    | **259.996 ns** |  **19.3140 ns** |  **1.0587 ns** | **0.0134** |     **224 B** |
| Construct_FromDoubleRounded                | True        | 3.141592653589793    | 133.799 ns |   9.1599 ns |  0.5021 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 3.141592653589793    | 100.235 ns |   4.5525 ns |  0.2495 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 3.141592653589793    | 184.208 ns |   6.5588 ns |  0.3595 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                       | **True**        | **42**                   | **139.109 ns** |   **8.8195 ns** |  **0.4834 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                | True        | 42                   |   6.696 ns |   0.9478 ns |  0.0520 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | 42                   |  31.235 ns |   4.5950 ns |  0.2519 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 42                   |  32.657 ns |  21.7727 ns |  1.1934 ns |      - |         - |
| **Construct_FromDouble**                       | **True**        | **2110.11170524**        | **184.524 ns** |  **23.0471 ns** |  **1.2633 ns** | **0.0095** |     **160 B** |
| Construct_FromDoubleRounded                | True        | 2110.11170524        | 148.687 ns |  53.1363 ns |  2.9126 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | 2110.11170524        |  81.764 ns |   3.5901 ns |  0.1968 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 2110.11170524        | 161.886 ns |   6.6357 ns |  0.3637 ns | 0.0057 |      96 B |
| **Construct_FromDouble**                       | **True**        | **1024000000000**        | **181.767 ns** |  **10.9050 ns** |  **0.5977 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                | True        | 1024000000000        |   8.721 ns |   1.6320 ns |  0.0895 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | 1024000000000        |  78.639 ns |  33.9183 ns |  1.8592 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 1024000000000        |  39.348 ns |  13.1661 ns |  0.7217 ns | 0.0019 |      32 B |
| **Construct_FromDouble**                       | **True**        | **5.9722E+24**           | **224.358 ns** |  **95.1256 ns** |  **5.2142 ns** | **0.0134** |     **224 B** |
| Construct_FromDoubleRounded                | True        | 5.9722E+24           |   9.922 ns |   4.5143 ns |  0.2474 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | 5.9722E+24           | 116.556 ns | 105.6250 ns |  5.7897 ns | 0.0043 |      72 B |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 5.9722E+24           |  97.539 ns |  23.6714 ns |  1.2975 ns | 0.0043 |      72 B |
| **Construct_FromDouble**                       | **True**        | **1.797(...)E+308 [23]** | **357.030 ns** |  **10.1420 ns** |  **0.5559 ns** | **0.0334** |     **560 B** |
| Construct_FromDoubleRounded                | True        | 1.797(...)E+308 [23] |  10.890 ns |   2.6931 ns |  0.1476 ns | 0.0091 |     152 B |
| Construct_FromDoubleRoundedToEightDigits   | True        | 1.797(...)E+308 [23] | 587.104 ns | 274.6804 ns | 15.0562 ns | 0.0181 |     304 B |
| Construct_FromDoubleRoundedToFifteenDigits | True        | 1.797(...)E+308 [23] | 558.232 ns | 114.1376 ns |  6.2563 ns | 0.0200 |     336 B |
| **Construct_FromDouble**                       | **True**        | **Infinity**             |   **7.047 ns** |   **5.5248 ns** |  **0.3028 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                | True        | Infinity             |   3.206 ns |   0.0512 ns |  0.0028 ns |      - |         - |
| Construct_FromDoubleRoundedToEightDigits   | True        | Infinity             |   4.005 ns |   0.0358 ns |  0.0020 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits | True        | Infinity             |   3.986 ns |   0.6633 ns |  0.0364 ns |      - |         - |
