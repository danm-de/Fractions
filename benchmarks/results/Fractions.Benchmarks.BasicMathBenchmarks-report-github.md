```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]                      : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9232.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method   | Job                         | Runtime            | a                    | b                    | Mean       | Error       | StdDev     | Gen0   | Allocated |
|--------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|------------:|-----------:|-------:|----------:|
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **31.017 ns** |   **0.7358 ns** |  **0.0403 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  29.988 ns |   0.9883 ns |  0.0542 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  35.176 ns |   0.4940 ns |  0.0271 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  32.002 ns |   0.9930 ns |  0.0544 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  56.452 ns |  10.8543 ns |  0.5950 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 115.984 ns |   6.8251 ns |  0.3741 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 137.489 ns |   7.8941 ns |  0.4327 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 145.582 ns |  41.3267 ns |  2.2653 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 140.115 ns | 115.2926 ns |  6.3196 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 283.314 ns |  85.2938 ns |  4.6752 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **95.125 ns** |  **11.5045 ns** |  **0.6306 ns** | **0.0076** |     **128 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  90.583 ns |   4.6566 ns |  0.2552 ns | 0.0076 |     128 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      | 104.996 ns |   7.8963 ns |  0.4328 ns | 0.0086 |     144 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  48.550 ns |   2.1223 ns |  0.1163 ns | 0.0029 |      48 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  62.099 ns |  12.4717 ns |  0.6836 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 258.742 ns |   7.7874 ns |  0.4269 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 265.737 ns |  35.7137 ns |  1.9576 ns | 0.0229 |     144 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 222.409 ns |  23.4409 ns |  1.2849 ns | 0.0293 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 139.956 ns |  13.0163 ns |  0.7135 ns | 0.0153 |      96 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 162.653 ns |   6.0178 ns |  0.3299 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024**                | **-1/1024**              |  **39.822 ns** |   **0.9912 ns** |  **0.0543 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  42.969 ns |   0.9741 ns |  0.0534 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  28.642 ns |   3.0397 ns |  0.1666 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  21.054 ns |   6.2133 ns |  0.3406 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  28.900 ns |   0.6902 ns |  0.0378 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 174.975 ns |   6.2386 ns |  0.3420 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 193.501 ns |   7.9909 ns |  0.4380 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 125.419 ns |  29.8708 ns |  1.6373 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 101.735 ns |  14.0143 ns |  0.7682 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 120.512 ns |   5.3187 ns |  0.2915 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45**                  | **1/6**                  |  **40.785 ns** |   **2.8007 ns** |  **0.1535 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  40.510 ns |   1.3158 ns |  0.0721 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  31.392 ns |   3.7824 ns |  0.2073 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  19.683 ns |   0.2862 ns |  0.0157 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  28.435 ns |   5.4581 ns |  0.2992 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 171.493 ns |   9.0034 ns |  0.4935 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 179.977 ns |  18.8823 ns |  1.0350 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 124.787 ns |  17.7712 ns |  0.9741 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  99.195 ns |   2.0830 ns |  0.1142 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 117.900 ns |  53.1273 ns |  2.9121 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    | **1**                    |   **6.033 ns** |   **0.3368 ns** |  **0.0185 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   8.428 ns |   1.1827 ns |  0.0648 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   7.358 ns |   2.2039 ns |  0.1208 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   8.126 ns |   0.9422 ns |  0.0516 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   5.590 ns |   0.0902 ns |  0.0049 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  23.503 ns |   0.4834 ns |  0.0265 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  34.708 ns |   0.5195 ns |  0.0285 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  26.744 ns |   3.5304 ns |  0.1935 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  28.128 ns |   1.7300 ns |  0.0948 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  27.584 ns |   0.6504 ns |  0.0357 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **57.335 ns** |  **10.3454 ns** |  **0.5671 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  56.491 ns |  12.7089 ns |  0.6966 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  31.714 ns |   1.5954 ns |  0.0874 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  36.659 ns |   0.2012 ns |  0.0110 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  54.477 ns |   7.9886 ns |  0.4379 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 230.200 ns |  33.4819 ns |  1.8353 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 230.266 ns |  58.4852 ns |  3.2058 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 101.229 ns |  10.6455 ns |  0.5835 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 142.277 ns | 118.5358 ns |  6.4973 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 234.805 ns |  26.1707 ns |  1.4345 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **60.230 ns** |  **61.3454 ns** |  **3.3626 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  66.067 ns |  22.4577 ns |  1.2310 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  35.101 ns |   5.0603 ns |  0.2774 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  37.139 ns |   5.2317 ns |  0.2868 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  69.936 ns |  33.3710 ns |  1.8292 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 267.731 ns |  90.6379 ns |  4.9682 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 274.703 ns |  36.2682 ns |  1.9880 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 138.299 ns |  30.9047 ns |  1.6940 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 140.804 ns |  28.6482 ns |  1.5703 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 283.028 ns | 232.5598 ns | 12.7474 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **47161(...)70496 [33]** | **171.990 ns** |  **18.7223 ns** |  **1.0262 ns** | **0.0095** |     **160 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 168.041 ns |   8.7757 ns |  0.4810 ns | 0.0095 |     160 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 272.716 ns |  42.4874 ns |  2.3289 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 156.066 ns |  51.3617 ns |  2.8153 ns | 0.0105 |     176 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 119.617 ns |  18.3588 ns |  1.0063 ns | 0.0076 |     128 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 304.821 ns |  44.3093 ns |  2.4287 ns | 0.0277 |     177 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 354.854 ns |  50.1433 ns |  2.7485 ns | 0.0267 |     168 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 159.729 ns |  19.8501 ns |  1.0880 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 313.811 ns |  37.0886 ns |  2.0329 ns | 0.0482 |     305 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 365.414 ns |  25.2207 ns |  1.3824 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** | **154.863 ns** |   **2.8119 ns** |  **0.1541 ns** | **0.0095** |     **160 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 166.475 ns |  15.0070 ns |  0.8226 ns | 0.0095 |     160 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 213.422 ns |  11.6776 ns |  0.6401 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 112.040 ns |   2.4414 ns |  0.1338 ns | 0.0072 |     120 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 108.012 ns |   7.6213 ns |  0.4178 ns | 0.0076 |     128 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 306.389 ns |  28.1251 ns |  1.5416 ns | 0.0277 |     177 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 318.183 ns |   3.0448 ns |  0.1669 ns | 0.0267 |     168 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 161.847 ns |   2.6492 ns |  0.1452 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 291.165 ns |  11.2720 ns |  0.6179 ns | 0.0443 |     281 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 323.224 ns |  21.5532 ns |  1.1814 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **6.156 ns** |   **0.4853 ns** |  **0.0266 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   9.219 ns |   6.3637 ns |  0.3488 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.001 ns |   3.1076 ns |  0.1703 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   5.360 ns |   1.1677 ns |  0.0640 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.443 ns |   0.3631 ns |  0.0199 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  23.389 ns |   1.5482 ns |  0.0849 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  35.074 ns |   1.2161 ns |  0.0667 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  31.042 ns |   8.6603 ns |  0.4747 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  24.498 ns |   1.3851 ns |  0.0759 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.602 ns |   4.2110 ns |  0.2308 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **7.050 ns** |   **1.1385 ns** |  **0.0624 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   9.906 ns |   6.5867 ns |  0.3610 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   7.889 ns |   3.1057 ns |  0.1702 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   5.548 ns |   5.2341 ns |  0.2869 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.535 ns |   0.3927 ns |  0.0215 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  27.234 ns |   2.4259 ns |  0.1330 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  38.321 ns |   0.0784 ns |  0.0043 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.230 ns |   0.6095 ns |  0.0334 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  24.705 ns |   2.2934 ns |  0.1257 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  25.966 ns |   2.4605 ns |  0.1349 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **6.222 ns** |   **0.1861 ns** |  **0.0102 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.995 ns |   0.9655 ns |  0.0529 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.295 ns |   0.9820 ns |  0.0538 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   8.136 ns |   0.6550 ns |  0.0359 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   5.894 ns |   5.2164 ns |  0.2859 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  24.191 ns |   0.1401 ns |  0.0077 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  35.023 ns |  20.3820 ns |  1.1172 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.555 ns |   7.7288 ns |  0.4236 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  31.740 ns |   3.0042 ns |  0.1647 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.662 ns |   6.2118 ns |  0.3405 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **26714619/25510582**    | **134.367 ns** |   **9.7171 ns** |  **0.5326 ns** | **0.0076** |     **128 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    | 126.783 ns |   9.7645 ns |  0.5352 ns | 0.0076 |     128 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    | 113.947 ns |   2.4109 ns |  0.1321 ns | 0.0076 |     128 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    |  38.420 ns |   5.0431 ns |  0.2764 ns | 0.0038 |      64 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    |  68.864 ns |   9.5322 ns |  0.5225 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 267.413 ns | 165.1211 ns |  9.0508 ns | 0.0215 |     136 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 268.897 ns |  14.1283 ns |  0.7744 ns | 0.0200 |     128 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 217.313 ns | 176.0046 ns |  9.6474 ns | 0.0203 |     128 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 113.036 ns | 128.4444 ns |  7.0405 ns | 0.0100 |      64 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 211.664 ns |  49.9236 ns |  2.7365 ns | 0.0203 |     128 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **122925461/78256779**   |  **56.581 ns** |   **0.9009 ns** |  **0.0494 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  47.287 ns |   5.7837 ns |  0.3170 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  87.667 ns |  41.0323 ns |  2.2491 ns | 0.0038 |      64 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  75.435 ns |  74.8310 ns |  4.1017 ns | 0.0057 |      96 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  42.018 ns |  15.1846 ns |  0.8323 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 148.841 ns |  16.8174 ns |  0.9218 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 126.072 ns |   8.9020 ns |  0.4879 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 139.187 ns |  11.7769 ns |  0.6455 ns | 0.0100 |      64 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 223.359 ns |  35.4521 ns |  1.9433 ns | 0.0253 |     160 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 186.499 ns |   7.9663 ns |  0.4367 ns |      - |         - |
