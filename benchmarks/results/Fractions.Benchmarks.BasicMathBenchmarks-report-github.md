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
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **32.221 ns** |   **4.4264 ns** |  **0.2426 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  30.234 ns |   4.7448 ns |  0.2601 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  35.853 ns |   3.1696 ns |  0.1737 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  33.018 ns |   4.9305 ns |  0.2703 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  57.152 ns |   8.7656 ns |  0.4805 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 120.196 ns |   1.4500 ns |  0.0795 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 139.468 ns |   4.3937 ns |  0.2408 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 136.208 ns |  15.1051 ns |  0.8280 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 131.158 ns |   5.4989 ns |  0.3014 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 280.560 ns |  42.7063 ns |  2.3409 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **97.264 ns** |   **6.6017 ns** |  **0.3619 ns** | **0.0076** |     **128 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  93.998 ns |   3.6365 ns |  0.1993 ns | 0.0076 |     128 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      | 105.842 ns |   2.5882 ns |  0.1419 ns | 0.0086 |     144 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  32.518 ns |   0.9646 ns |  0.0529 ns | 0.0029 |      48 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  63.507 ns |   4.5978 ns |  0.2520 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 260.597 ns |   8.3548 ns |  0.4580 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 270.084 ns |   8.3007 ns |  0.4550 ns | 0.0229 |     144 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 234.624 ns |  16.3284 ns |  0.8950 ns | 0.0293 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  98.287 ns |   5.1086 ns |  0.2800 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 159.307 ns |  18.6739 ns |  1.0236 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024**                | **-1/1024**              |  **39.965 ns** |   **1.1685 ns** |  **0.0641 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  43.242 ns |   0.5358 ns |  0.0294 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  30.046 ns |   5.5456 ns |  0.3040 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  17.650 ns |   0.7880 ns |  0.0432 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  29.234 ns |   1.8187 ns |  0.0997 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 177.181 ns |   1.0194 ns |  0.0559 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 197.504 ns |   3.9494 ns |  0.2165 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 126.695 ns |   8.1977 ns |  0.4493 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  66.655 ns |   0.9797 ns |  0.0537 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 120.545 ns |   1.8247 ns |  0.1000 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45**                  | **1/6**                  |  **42.535 ns** |   **0.3065 ns** |  **0.0168 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  41.565 ns |   1.4490 ns |  0.0794 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  31.915 ns |   1.9343 ns |  0.1060 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  17.181 ns |   5.8847 ns |  0.3226 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  28.717 ns |   4.4854 ns |  0.2459 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 167.845 ns |   4.6137 ns |  0.2529 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 184.051 ns |   1.4431 ns |  0.0791 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 129.952 ns |   6.3835 ns |  0.3499 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  67.676 ns |   1.8424 ns |  0.1010 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 116.341 ns |   5.2237 ns |  0.2863 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    | **1**                    |   **5.874 ns** |   **0.3979 ns** |  **0.0218 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   8.499 ns |   0.2005 ns |  0.0110 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   7.197 ns |   1.1642 ns |  0.0638 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   8.376 ns |   0.6553 ns |  0.0359 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   5.498 ns |   0.7536 ns |  0.0413 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  24.288 ns |   0.0276 ns |  0.0015 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  34.991 ns |   0.2453 ns |  0.0134 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  27.693 ns |   1.0942 ns |  0.0600 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  28.130 ns |   0.8306 ns |  0.0455 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  26.752 ns |   0.2270 ns |  0.0124 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **57.119 ns** |   **0.7334 ns** |  **0.0402 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  54.850 ns |   4.2856 ns |  0.2349 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  32.303 ns |   1.2171 ns |  0.0667 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  37.137 ns |   0.4439 ns |  0.0243 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  54.562 ns |   1.0007 ns |  0.0549 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 214.072 ns |  24.3785 ns |  1.3363 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 230.909 ns |  45.9529 ns |  2.5188 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 103.024 ns |   2.6558 ns |  0.1456 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 136.849 ns |  27.0548 ns |  1.4830 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 239.785 ns |  18.5850 ns |  1.0187 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **60.609 ns** |  **18.6617 ns** |  **1.0229 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  67.639 ns |   1.1046 ns |  0.0605 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  35.232 ns |   0.6102 ns |  0.0334 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  37.192 ns |   1.1218 ns |  0.0615 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  68.390 ns |   1.6186 ns |  0.0887 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 250.158 ns |  26.1395 ns |  1.4328 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 292.064 ns | 156.2835 ns |  8.5664 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 135.548 ns |  10.7965 ns |  0.5918 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 137.636 ns |  27.9443 ns |  1.5317 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 273.814 ns |  10.4222 ns |  0.5713 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **47161(...)70496 [33]** | **172.844 ns** |  **11.9295 ns** |  **0.6539 ns** | **0.0095** |     **160 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 166.659 ns |   5.7404 ns |  0.3146 ns | 0.0095 |     160 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 267.979 ns |   6.5688 ns |  0.3601 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 149.098 ns |   2.9733 ns |  0.1630 ns | 0.0105 |     176 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 113.950 ns |   6.0328 ns |  0.3307 ns | 0.0076 |     128 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 321.739 ns |  38.0743 ns |  2.0870 ns | 0.0277 |     177 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 359.172 ns | 311.7855 ns | 17.0900 ns | 0.0267 |     168 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 167.825 ns |  81.4398 ns |  4.4640 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 326.539 ns | 201.7568 ns | 11.0590 ns | 0.0482 |     305 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 347.275 ns |  46.8122 ns |  2.5659 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** | **158.155 ns** |   **2.7043 ns** |  **0.1482 ns** | **0.0095** |     **160 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 170.087 ns |   6.6802 ns |  0.3662 ns | 0.0095 |     160 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 217.529 ns |  71.6571 ns |  3.9278 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 113.612 ns |   9.8393 ns |  0.5393 ns | 0.0072 |     120 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 108.651 ns |   2.8699 ns |  0.1573 ns | 0.0076 |     128 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 331.651 ns |  18.2209 ns |  0.9988 ns | 0.0277 |     177 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 347.327 ns | 238.1865 ns | 13.0558 ns | 0.0267 |     168 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 162.688 ns |  18.0668 ns |  0.9903 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 303.349 ns |  25.6181 ns |  1.4042 ns | 0.0443 |     281 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 325.774 ns |   9.0072 ns |  0.4937 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **6.183 ns** |   **1.5388 ns** |  **0.0843 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   9.432 ns |   7.1998 ns |  0.3946 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.189 ns |   0.9986 ns |  0.0547 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   5.480 ns |   2.5446 ns |  0.1395 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   5.640 ns |   1.0817 ns |  0.0593 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  24.415 ns |   4.5758 ns |  0.2508 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  34.620 ns |   0.5556 ns |  0.0305 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  30.726 ns |   2.9446 ns |  0.1614 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  24.607 ns |   3.4228 ns |  0.1876 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  26.539 ns |   0.5366 ns |  0.0294 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **8.033 ns** |   **8.1281 ns** |  **0.4455 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  11.055 ns |  17.5652 ns |  0.9628 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   8.226 ns |   5.1698 ns |  0.2834 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   5.301 ns |   1.2992 ns |  0.0712 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.055 ns |   0.5187 ns |  0.0284 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  26.780 ns |   1.0298 ns |  0.0564 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  38.694 ns |   4.1201 ns |  0.2258 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  31.868 ns |   0.9365 ns |  0.0513 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  24.793 ns |   0.4147 ns |  0.0227 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  26.586 ns |   3.5578 ns |  0.1950 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **6.411 ns** |   **2.3045 ns** |  **0.1263 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   8.669 ns |   0.2994 ns |  0.0164 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.728 ns |   0.7505 ns |  0.0411 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   8.344 ns |   2.8679 ns |  0.1572 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   5.715 ns |   0.7094 ns |  0.0389 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  24.475 ns |   2.4638 ns |  0.1350 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  34.785 ns |   2.8816 ns |  0.1580 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.087 ns |   4.2720 ns |  0.2342 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  31.899 ns |   1.7612 ns |  0.0965 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.616 ns |   4.1721 ns |  0.2287 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **26714619/25510582**    | **135.594 ns** |  **14.0196 ns** |  **0.7685 ns** | **0.0076** |     **128 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    | 129.059 ns |  45.8706 ns |  2.5143 ns | 0.0076 |     128 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    | 115.176 ns |   6.7521 ns |  0.3701 ns | 0.0076 |     128 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    |  41.910 ns |  18.4816 ns |  1.0130 ns | 0.0038 |      64 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    |  69.956 ns |  10.4774 ns |  0.5743 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 267.055 ns |  25.2895 ns |  1.3862 ns | 0.0215 |     136 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 276.880 ns |  38.9186 ns |  2.1333 ns | 0.0200 |     128 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 231.952 ns |  92.1183 ns |  5.0493 ns | 0.0203 |     128 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 111.285 ns |   1.8133 ns |  0.0994 ns | 0.0101 |      64 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 192.272 ns |  38.8526 ns |  2.1296 ns | 0.0203 |     128 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **122925461/78256779**   |  **58.584 ns** |  **25.1700 ns** |  **1.3797 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  49.656 ns |   1.7595 ns |  0.0964 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  86.324 ns |   4.2726 ns |  0.2342 ns | 0.0038 |      64 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  74.646 ns |  10.5766 ns |  0.5797 ns | 0.0057 |      96 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  41.571 ns |   1.1679 ns |  0.0640 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 151.489 ns |   8.3482 ns |  0.4576 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 129.518 ns |   3.0526 ns |  0.1673 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 168.484 ns | 362.4982 ns | 19.8698 ns | 0.0100 |      64 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 234.815 ns |  62.5252 ns |  3.4272 ns | 0.0253 |     160 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 200.254 ns |  46.7680 ns |  2.5635 ns |      - |         - |
