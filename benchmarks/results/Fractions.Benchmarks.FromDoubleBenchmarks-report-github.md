```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                                      | value                | Mean       | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------- |--------------------- |-----------:|----------:|----------:|-------:|----------:|
| **Construct_FromDouble**                        | **NaN**                  |   **8.069 ns** | **0.0118 ns** | **0.0105 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | NaN                  |   6.003 ns | 0.0056 ns | 0.0047 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | NaN                  |   6.924 ns | 0.0172 ns | 0.0161 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | NaN                  |   6.925 ns | 0.0168 ns | 0.0149 ns |      - |         - |
| **Construct_FromDouble**                        | **-Infinity**            |   **8.064 ns** | **0.0099 ns** | **0.0082 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | -Infinity            |   5.991 ns | 0.0117 ns | 0.0110 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | -Infinity            |   7.281 ns | 0.0091 ns | 0.0071 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | -Infinity            |   7.296 ns | 0.0191 ns | 0.0179 ns |      - |         - |
| **Construct_FromDouble**                        | **-7.92(...)4E+28 [22]** | **108.360 ns** | **0.1938 ns** | **0.1812 ns** | **0.0105** |     **176 B** |
| Construct_FromDoubleRounded                 | -7.92(...)4E+28 [22] |  31.240 ns | 0.1188 ns | 0.0992 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToFifteenDigits  | -7.92(...)4E+28 [22] | 124.425 ns | 0.7155 ns | 0.6692 ns | 0.0062 |     104 B |
| Construct_FromDoubleRoundedToEighteenDigits | -7.92(...)4E+28 [22] | 131.184 ns | 0.4202 ns | 0.3930 ns | 0.0062 |     104 B |
| **Construct_FromDouble**                        | **-0.02702702702702703** | **119.189 ns** | **0.4495 ns** | **0.3754 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | -0.02702702702702703 |  19.864 ns | 0.0458 ns | 0.0429 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | -0.02702702702702703 | 160.572 ns | 0.4095 ns | 0.3419 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | -0.02702702702702703 | 175.362 ns | 0.3800 ns | 0.3173 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **-3.69(...)7E-06 [23]** | **140.360 ns** | **0.6646 ns** | **0.6216 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                 | -3.69(...)7E-06 [23] |  90.551 ns | 0.2966 ns | 0.2774 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | -3.69(...)7E-06 [23] | 191.595 ns | 0.8929 ns | 0.7457 ns | 0.0081 |     136 B |
| Construct_FromDoubleRoundedToEighteenDigits | -3.69(...)7E-06 [23] | 211.056 ns | 1.1456 ns | 1.0156 ns | 0.0081 |     136 B |
| **Construct_FromDouble**                        | **0**                    |   **7.719 ns** | **0.0325 ns** | **0.0288 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | 0                    |   6.370 ns | 0.0068 ns | 0.0060 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0                    |   6.558 ns | 0.0157 ns | 0.0140 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | 0                    |   6.546 ns | 0.0114 ns | 0.0107 ns |      - |         - |
| **Construct_FromDouble**                        | **0.022046226218487758** | **209.222 ns** | **0.5792 ns** | **0.5418 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 0.022046226218487758 | 206.370 ns | 0.3593 ns | 0.3185 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.022046226218487758 | 205.328 ns | 1.1315 ns | 1.0584 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.022046226218487758 | 225.828 ns | 0.7171 ns | 0.6708 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **0.09999999999999999**  |  **95.988 ns** | **0.2692 ns** | **0.2518 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 0.09999999999999999  |  23.995 ns | 0.0786 ns | 0.0613 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.09999999999999999  | 188.344 ns | 0.8840 ns | 0.6902 ns | 0.0076 |     128 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.09999999999999999  | 175.477 ns | 0.4088 ns | 0.3824 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **0.3333333333333333**   |  **87.967 ns** | **0.0914 ns** | **0.0810 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 0.3333333333333333   |  23.727 ns | 0.0669 ns | 0.0559 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.3333333333333333   | 158.404 ns | 0.3093 ns | 0.2742 ns | 0.0057 |      96 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.3333333333333333   | 169.885 ns | 0.5058 ns | 0.4732 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **1.345**                | **104.452 ns** | **0.1632 ns** | **0.1527 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 1.345                |  61.426 ns | 0.1093 ns | 0.1022 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 1.345                | 190.375 ns | 0.2736 ns | 0.2425 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1.345                | 185.942 ns | 0.3546 ns | 0.3317 ns | 0.0114 |     192 B |
| **Construct_FromDouble**                        | **3.141592653589793**    | **210.530 ns** | **0.6686 ns** | **0.6254 ns** | **0.0153** |     **256 B** |
| Construct_FromDoubleRounded                 | 3.141592653589793    | 144.538 ns | 0.2860 ns | 0.2675 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 3.141592653589793    | 192.368 ns | 0.5376 ns | 0.5028 ns | 0.0076 |     128 B |
| Construct_FromDoubleRoundedToEighteenDigits | 3.141592653589793    | 209.061 ns | 0.6906 ns | 0.5767 ns | 0.0114 |     192 B |
| **Construct_FromDouble**                        | **42**                   |  **99.502 ns** | **0.1229 ns** | **0.0959 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                 | 42                   |  20.438 ns | 0.0535 ns | 0.0475 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 42                   |  34.391 ns | 0.0518 ns | 0.0432 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | 42                   |  33.922 ns | 0.0820 ns | 0.0727 ns |      - |         - |
| **Construct_FromDouble**                        | **2110.11170524**        | **166.701 ns** | **0.8668 ns** | **0.6767 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 2110.11170524        | 161.069 ns | 0.2302 ns | 0.1922 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 2110.11170524        | 193.847 ns | 0.9632 ns | 0.9009 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 2110.11170524        | 199.811 ns | 1.0754 ns | 0.9533 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                        | **1024000000000**        | **138.064 ns** | **1.2194 ns** | **0.9521 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 1024000000000        |  25.173 ns | 0.3798 ns | 0.3367 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 1024000000000        |  36.914 ns | 0.0842 ns | 0.0703 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1024000000000        |  36.859 ns | 0.1677 ns | 0.1569 ns | 0.0019 |      32 B |
| **Construct_FromDouble**                        | **5.9722E+24**           | **203.901 ns** | **0.8691 ns** | **0.8129 ns** | **0.0153** |     **256 B** |
| Construct_FromDoubleRounded                 | 5.9722E+24           |  29.659 ns | 0.1748 ns | 0.1635 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 5.9722E+24           | 105.878 ns | 0.1421 ns | 0.1186 ns | 0.0043 |      72 B |
| Construct_FromDoubleRoundedToEighteenDigits | 5.9722E+24           |  95.140 ns | 0.2079 ns | 0.1945 ns | 0.0043 |      72 B |
| **Construct_FromDouble**                        | **1.797(...)E+308 [23]** | **344.490 ns** | **1.1828 ns** | **0.9877 ns** | **0.0353** |     **592 B** |
| Construct_FromDoubleRounded                 | 1.797(...)E+308 [23] |  94.932 ns | 1.4078 ns | 1.1756 ns | 0.0091 |     152 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 1.797(...)E+308 [23] | 657.717 ns | 0.9930 ns | 0.8803 ns | 0.0200 |     336 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1.797(...)E+308 [23] | 635.022 ns | 3.2789 ns | 3.0671 ns | 0.0200 |     336 B |
| **Construct_FromDouble**                        | **Infinity**             |   **8.064 ns** | **0.0260 ns** | **0.0203 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | Infinity             |   5.818 ns | 0.0255 ns | 0.0199 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | Infinity             |   7.154 ns | 0.0532 ns | 0.0444 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | Infinity             |   7.113 ns | 0.0145 ns | 0.0129 ns |      - |         - |
