```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                                      | value                | Mean       | Error      | StdDev     | Gen0   | Allocated |
|-------------------------------------------- |--------------------- |-----------:|-----------:|-----------:|-------:|----------:|
| **Construct_FromDouble**                        | **NaN**                  |   **8.381 ns** |  **0.0597 ns** |  **0.0558 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | NaN                  |   6.981 ns |  0.0384 ns |  0.0359 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | NaN                  |   7.707 ns |  0.0518 ns |  0.0484 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | NaN                  |   7.697 ns |  0.0626 ns |  0.0586 ns |      - |         - |
| **Construct_FromDouble**                        | **-Infinity**            |   **8.399 ns** |  **0.0588 ns** |  **0.0550 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | -Infinity            |   6.941 ns |  0.0387 ns |  0.0362 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | -Infinity            |   8.063 ns |  0.0442 ns |  0.0413 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | -Infinity            |   8.080 ns |  0.0437 ns |  0.0408 ns |      - |         - |
| **Construct_FromDouble**                        | **-7.92(...)4E+28 [22]** | **129.805 ns** |  **1.2395 ns** |  **1.1594 ns** | **0.0105** |     **176 B** |
| Construct_FromDoubleRounded                 | -7.92(...)4E+28 [22] |  21.166 ns |  0.1416 ns |  0.1324 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToFifteenDigits  | -7.92(...)4E+28 [22] | 126.813 ns |  0.9539 ns |  0.8456 ns | 0.0062 |     104 B |
| Construct_FromDoubleRoundedToEighteenDigits | -7.92(...)4E+28 [22] | 119.256 ns |  0.7875 ns |  0.6981 ns | 0.0062 |     104 B |
| **Construct_FromDouble**                        | **-0.02702702702702703** | **142.208 ns** |  **1.3240 ns** |  **1.2385 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | -0.02702702702702703 |  20.145 ns |  0.4113 ns |  0.5051 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | -0.02702702702702703 | 165.791 ns |  0.8773 ns |  0.8206 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | -0.02702702702702703 | 176.689 ns |  1.2235 ns |  1.1445 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **-3.69(...)7E-06 [23]** | **158.954 ns** |  **0.7100 ns** |  **0.6641 ns** | **0.0081** |     **136 B** |
| Construct_FromDoubleRounded                 | -3.69(...)7E-06 [23] |  81.987 ns |  0.4051 ns |  0.3591 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | -3.69(...)7E-06 [23] | 188.329 ns |  1.3635 ns |  1.2754 ns | 0.0081 |     136 B |
| Construct_FromDoubleRoundedToEighteenDigits | -3.69(...)7E-06 [23] | 203.500 ns |  1.3094 ns |  1.2248 ns | 0.0081 |     136 B |
| **Construct_FromDouble**                        | **0**                    |   **7.975 ns** |  **0.0449 ns** |  **0.0420 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | 0                    |   7.317 ns |  0.0455 ns |  0.0426 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0                    |   7.310 ns |  0.0455 ns |  0.0404 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | 0                    |   7.323 ns |  0.0393 ns |  0.0348 ns |      - |         - |
| **Construct_FromDouble**                        | **0.022046226218487758** | **233.104 ns** |  **0.9541 ns** |  **0.8457 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 0.022046226218487758 | 214.339 ns |  0.8105 ns |  0.7581 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.022046226218487758 | 204.963 ns |  1.3935 ns |  1.3035 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.022046226218487758 | 231.901 ns |  1.2852 ns |  1.2022 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **0.09999999999999999**  | **113.169 ns** |  **0.7783 ns** |  **0.7280 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 0.09999999999999999  |  23.182 ns |  0.1320 ns |  0.1235 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.09999999999999999  | 185.452 ns |  0.7693 ns |  0.7196 ns | 0.0076 |     128 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.09999999999999999  | 184.663 ns |  1.5667 ns |  1.4655 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **0.3333333333333333**   | **118.222 ns** |  **0.8499 ns** |  **0.7534 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 0.3333333333333333   |  23.103 ns |  0.1009 ns |  0.0944 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 0.3333333333333333   | 153.353 ns |  1.1191 ns |  1.0468 ns | 0.0057 |      96 B |
| Construct_FromDoubleRoundedToEighteenDigits | 0.3333333333333333   | 166.299 ns |  0.9816 ns |  0.8701 ns | 0.0095 |     160 B |
| **Construct_FromDouble**                        | **1.345**                | **123.921 ns** |  **0.6137 ns** |  **0.5441 ns** | **0.0076** |     **128 B** |
| Construct_FromDoubleRounded                 | 1.345                |  66.999 ns |  0.2545 ns |  0.2380 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 1.345                | 185.682 ns |  0.7600 ns |  0.7109 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1.345                | 189.569 ns |  1.5315 ns |  1.4326 ns | 0.0114 |     192 B |
| **Construct_FromDouble**                        | **3.141592653589793**    | **235.911 ns** |  **0.8411 ns** |  **0.7456 ns** | **0.0153** |     **256 B** |
| Construct_FromDoubleRounded                 | 3.141592653589793    | 152.289 ns |  0.6220 ns |  0.5818 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 3.141592653589793    | 194.398 ns |  1.4376 ns |  1.3448 ns | 0.0076 |     128 B |
| Construct_FromDoubleRoundedToEighteenDigits | 3.141592653589793    | 208.037 ns |  1.3150 ns |  1.2301 ns | 0.0114 |     192 B |
| **Construct_FromDouble**                        | **42**                   | **118.938 ns** |  **1.0274 ns** |  **0.9611 ns** | **0.0057** |      **96 B** |
| Construct_FromDoubleRounded                 | 42                   |  17.372 ns |  0.0685 ns |  0.0640 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | 42                   |  40.168 ns |  0.1353 ns |  0.1266 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | 42                   |  40.095 ns |  0.1009 ns |  0.0842 ns |      - |         - |
| **Construct_FromDouble**                        | **2110.11170524**        | **183.860 ns** |  **0.9717 ns** |  **0.9089 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 2110.11170524        | 166.126 ns |  0.2413 ns |  0.1884 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 2110.11170524        | 185.095 ns |  1.3864 ns |  1.2969 ns | 0.0095 |     160 B |
| Construct_FromDoubleRoundedToEighteenDigits | 2110.11170524        | 200.376 ns |  1.2332 ns |  1.1535 ns | 0.0076 |     128 B |
| **Construct_FromDouble**                        | **1024000000000**        | **157.300 ns** |  **1.2685 ns** |  **1.1866 ns** | **0.0114** |     **192 B** |
| Construct_FromDoubleRounded                 | 1024000000000        |  24.067 ns |  0.1242 ns |  0.1162 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 1024000000000        |  45.356 ns |  0.2548 ns |  0.2383 ns | 0.0019 |      32 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1024000000000        |  45.727 ns |  0.1742 ns |  0.1630 ns | 0.0019 |      32 B |
| **Construct_FromDouble**                        | **5.9722E+24**           | **222.129 ns** |  **1.6255 ns** |  **1.5205 ns** | **0.0153** |     **256 B** |
| Construct_FromDoubleRounded                 | 5.9722E+24           |  27.822 ns |  0.1782 ns |  0.1580 ns | 0.0024 |      40 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 5.9722E+24           | 108.333 ns |  0.6975 ns |  0.6524 ns | 0.0043 |      72 B |
| Construct_FromDoubleRoundedToEighteenDigits | 5.9722E+24           |  96.052 ns |  0.6264 ns |  0.5860 ns | 0.0043 |      72 B |
| **Construct_FromDouble**                        | **1.797(...)E+308 [23]** | **362.049 ns** |  **2.4876 ns** |  **2.3269 ns** | **0.0353** |     **592 B** |
| Construct_FromDoubleRounded                 | 1.797(...)E+308 [23] |  91.855 ns |  0.4265 ns |  0.3990 ns | 0.0091 |     152 B |
| Construct_FromDoubleRoundedToFifteenDigits  | 1.797(...)E+308 [23] | 665.498 ns | 12.7927 ns | 14.2191 ns | 0.0200 |     336 B |
| Construct_FromDoubleRoundedToEighteenDigits | 1.797(...)E+308 [23] | 657.372 ns | 13.1736 ns | 18.0322 ns | 0.0200 |     336 B |
| **Construct_FromDouble**                        | **Infinity**             |   **8.377 ns** |  **0.0611 ns** |  **0.0572 ns** |      **-** |         **-** |
| Construct_FromDoubleRounded                 | Infinity             |   6.759 ns |  0.0400 ns |  0.0374 ns |      - |         - |
| Construct_FromDoubleRoundedToFifteenDigits  | Infinity             |   7.878 ns |  0.0551 ns |  0.0516 ns |      - |         - |
| Construct_FromDoubleRoundedToEighteenDigits | Infinity             |   7.879 ns |  0.0495 ns |  0.0463 ns |      - |         - |
