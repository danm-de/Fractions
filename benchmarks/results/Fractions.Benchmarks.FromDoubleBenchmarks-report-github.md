```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4170/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                                      | value                | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------------------------- |--------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| **Construct_FromDouble**                        | **NaN**                  | **3,390.941 ns** | **14.8469 ns** | **12.3979 ns** | **0.0191** |     **344 B** |
| Construct_FromDoubleRounded                 | NaN                  | 3,432.153 ns | 28.6204 ns | 25.3712 ns | 0.0191 |     344 B |
| Construct_FromDoubleRoundedToFifteenDigits  | NaN                  | 3,416.248 ns | 45.0572 ns | 42.1465 ns | 0.0191 |     344 B |
| Construct_FromDoubleRoundedToEighteenDigits | NaN                  | 3,441.401 ns | 50.0763 ns | 46.8414 ns | 0.0191 |     344 B |
| **Construct_FromDouble**                        | **-Infinity**            | **3,259.095 ns** | **36.4204 ns** | **34.0677 ns** | **0.0191** |     **344 B** |
| Construct_FromDoubleRounded                 | -Infinity            | 3,434.863 ns | 49.6650 ns | 46.4567 ns | 0.0191 |     344 B |
| Construct_FromDoubleRoundedToFifteenDigits  | -Infinity            | 3,487.865 ns | 42.4430 ns | 39.7012 ns | 0.0191 |     344 B |
| Construct_FromDoubleRoundedToEighteenDigits | -Infinity            | 3,407.167 ns | 34.7192 ns | 32.4764 ns | 0.0191 |     344 B |
| **Construct_FromDouble**                        | **-7.92(...)4E+28 [22]** |   **109.871 ns** |  **1.6122 ns** |  **1.5081 ns** | **0.0105** |     **176 B** |
| Construct_FromDoubleRounded                 | -7.92(...)4E+28 [22] |    27.826 ns |  0.3930 ns |  0.3676 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToFifteenDigits  | -7.92(...)4E+28 [22] |   129.486 ns |  1.2696 ns |  1.1254 ns | 0.0062 |     104 B |
| Construct_FromDoubleRoundedToEighteenDigits | -7.92(...)4E+28 [22] |   119.677 ns |  1.3912 ns |  1.3013 ns | 0.0062 |     104 B |
| **Construct_FromDouble**                        | **-0.02702702702702703** |   **118.799 ns** |  **1.7269 ns** |  **1.6153 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | -0.02702702702702703 |    25.561 ns |  0.1775 ns |  0.1660 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | -0.02702702702702703 |   162.190 ns |  2.0687 ns |  1.9351 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | -0.02702702702702703 |   178.236 ns |  2.5077 ns |  2.3457 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **-3.69(...)7E-06 [23]** |   **140.763 ns** |  **1.0945 ns** |  **0.9139 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                 | -3.69(...)7E-06 [23] |    96.450 ns |  1.1546 ns |  1.0801 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | -3.69(...)7E-06 [23] |   189.451 ns |  0.9663 ns |  0.7544 ns | 0.0081 |     136 B |
| Construct_FromDoubleRoundedToEighteenDigits | -3.69(...)7E-06 [23] |   210.059 ns |  3.0703 ns |  2.8720 ns | 0.0081 |     136 B |
| **Construct_FromDouble**                        | **0**                    |     **7.738 ns** |  **0.0976 ns** |  **0.0913 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | 0                    |     6.609 ns |  0.0575 ns |  0.0538 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0                    |     6.976 ns |  0.0652 ns |  0.0610 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | 0                    |     6.825 ns |  0.0861 ns |  0.0763 ns |      - |         - |
| **Construct_FromDouble**                        | **0.022046226218487758** |   **210.493 ns** |  **2.6769 ns** |  **2.5040 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 0.022046226218487758 |   221.782 ns |  2.8017 ns |  2.6207 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.022046226218487758 |   206.612 ns |  2.3565 ns |  2.2043 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.022046226218487758 |   227.165 ns |  2.1244 ns |  1.8832 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **0.09999999999999999**  |    **98.679 ns** |  **1.5052 ns** |  **1.4080 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 0.09999999999999999  |    27.997 ns |  0.2224 ns |  0.1972 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.09999999999999999  |   187.046 ns |  2.1630 ns |  2.0233 ns | 0.0076 |     128 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.09999999999999999  |   173.090 ns |  1.7538 ns |  1.6405 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **0.3333333333333333**   |    **89.644 ns** |  **0.3633 ns** |  **0.3220 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 0.3333333333333333   |    27.724 ns |  0.3045 ns |  0.2848 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.3333333333333333   |   152.027 ns |  0.5205 ns |  0.4346 ns | 0.0057 |      96 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.3333333333333333   |   167.016 ns |  0.4696 ns |  0.4393 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **1.345**                |   **104.734 ns** |  **0.3830 ns** |  **0.2990 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 1.345                |    72.089 ns |  0.1481 ns |  0.1313 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 1.345                |   190.526 ns |  2.4503 ns |  2.2920 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1.345                |   194.480 ns |  2.7314 ns |  2.5550 ns | 0.0114 |     192 B |
| **Construct_FromDouble**                        | **3.141592653589793**    |   **213.897 ns** |  **2.2500 ns** |  **2.1046 ns** | **0.0153** |     **256 B** |
| Construct_FromDoubleRounded                 | 3.141592653589793    |   159.550 ns |  1.8010 ns |  1.6847 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 3.141592653589793    |   198.422 ns |  2.0424 ns |  1.9105 ns | 0.0076 |     128 B |
| Construct_FromDoubleRoundedToEighteenDigits | 3.141592653589793    |   213.165 ns |  2.7350 ns |  2.5583 ns | 0.0114 |     192 B |
| **Construct_FromDouble**                        | **42**                   |   **102.271 ns** |  **0.2903 ns** |  **0.2267 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                 | 42                   |    22.753 ns |  0.2251 ns |  0.2105 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 42                   |    39.639 ns |  0.3141 ns |  0.2938 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | 42                   |    39.647 ns |  0.4029 ns |  0.3768 ns |      - |         - |
| **Construct_FromDouble**                        | **2110.11170524**        |   **166.182 ns** |  **1.7685 ns** |  **1.6543 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 2110.11170524        |   175.254 ns |  2.0784 ns |  1.9441 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 2110.11170524        |   189.421 ns |  2.4924 ns |  2.3314 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 2110.11170524        |   202.736 ns |  0.3354 ns |  0.2618 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                        | **1024000000000**        |   **143.982 ns** |  **1.6571 ns** |  **1.5501 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 1024000000000        |    26.510 ns |  0.3122 ns |  0.2921 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 1024000000000        |    41.724 ns |  0.5321 ns |  0.4977 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1024000000000        |    41.274 ns |  0.2804 ns |  0.2623 ns | 0.0019 |      32 B |
| **Construct_FromDouble**                        | **5.9722E+24**           |   **215.369 ns** |  **2.5864 ns** |  **2.4193 ns** | **0.0153** |     **256 B** |
| Construct_FromDoubleRounded                 | 5.9722E+24           |    28.858 ns |  0.2216 ns |  0.2073 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 5.9722E+24           |   121.085 ns |  1.5669 ns |  1.4657 ns | 0.0043 |      72 B |
| Construct_FromDoubleRoundedToEighteenDigits | 5.9722E+24           |    96.862 ns |  0.9549 ns |  0.8932 ns | 0.0043 |      72 B |
| **Construct_FromDouble**                        | **1.797(...)E+308 [23]** |   **344.800 ns** |  **4.0943 ns** |  **3.8299 ns** | **0.0353** |     **592 B** |
| Construct_FromDoubleRounded                 | 1.797(...)E+308 [23] |    95.692 ns |  1.2841 ns |  1.2011 ns | 0.0091 |     152 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 1.797(...)E+308 [23] |   685.179 ns |  1.9596 ns |  1.5299 ns | 0.0200 |     336 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1.797(...)E+308 [23] |   685.418 ns |  7.5580 ns |  7.0697 ns | 0.0200 |     336 B |
| **Construct_FromDouble**                        | **Infinity**             | **3,299.610 ns** | **40.0411 ns** | **37.4545 ns** | **0.0191** |     **344 B** |
| Construct_FromDoubleRounded                 | Infinity             | 3,440.151 ns | 44.5664 ns | 41.6875 ns | 0.0191 |     344 B |
| Construct_FromDoubleRoundedToFifteenDigits  | Infinity             | 3,471.536 ns |  6.5051 ns |  6.0849 ns | 0.0191 |     344 B |
| Construct_FromDoubleRoundedToEighteenDigits | Infinity             | 3,401.239 ns | 37.9413 ns | 35.4904 ns | 0.0191 |     344 B |
