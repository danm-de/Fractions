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
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **92.693 ns** |   **5.2715 ns** |  **0.2889 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  89.703 ns |   6.0574 ns |  0.3320 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  86.496 ns |   2.5887 ns |  0.1419 ns | 0.0043 |      72 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  28.200 ns |   2.9600 ns |  0.1623 ns | 0.0029 |      48 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  68.281 ns |  12.2510 ns |  0.6715 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 222.102 ns |  15.7739 ns |  0.8646 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 238.411 ns |  87.6837 ns |  4.8062 ns | 0.0229 |     144 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 204.314 ns |  23.1492 ns |  1.2689 ns | 0.0293 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  88.423 ns |   8.9755 ns |  0.4920 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 161.925 ns |  83.3118 ns |  4.5666 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024**                | **-1/1024**              |  **40.210 ns** |   **3.6065 ns** |  **0.1977 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  43.594 ns |   5.6744 ns |  0.3110 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  26.938 ns |   0.7131 ns |  0.0391 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  13.538 ns |   2.7418 ns |  0.1503 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  37.752 ns |   3.7067 ns |  0.2032 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 121.532 ns |  20.6433 ns |  1.1315 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 141.683 ns |  18.4935 ns |  1.0137 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 112.588 ns |   8.1343 ns |  0.4459 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  52.685 ns |  23.0352 ns |  1.2626 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 127.874 ns |   5.8197 ns |  0.3190 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45**                  | **1/6**                  |  **40.938 ns** |   **0.9831 ns** |  **0.0539 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  41.072 ns |   6.5687 ns |  0.3601 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  22.443 ns |  20.3490 ns |  1.1154 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  12.946 ns |   1.3391 ns |  0.0734 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  37.571 ns |  12.5765 ns |  0.6894 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 127.019 ns |  51.1885 ns |  2.8058 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 130.844 ns |   9.6426 ns |  0.5285 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 105.833 ns |  11.8187 ns |  0.6478 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  54.079 ns |   0.4628 ns |  0.0254 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 120.674 ns |  16.3167 ns |  0.8944 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    | **1**                    |  **14.745 ns** |   **0.3106 ns** |  **0.0170 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  16.124 ns |   1.2237 ns |  0.0671 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   7.368 ns |   3.4397 ns |  0.1885 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   8.532 ns |   4.1052 ns |  0.2250 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  11.397 ns |   3.8306 ns |  0.2100 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  27.819 ns |   2.4502 ns |  0.1343 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  42.011 ns |   1.8993 ns |  0.1041 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  28.552 ns |   0.9054 ns |  0.0496 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  27.610 ns |   2.1327 ns |  0.1169 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  30.212 ns |   0.6695 ns |  0.0367 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **53.297 ns** |   **4.2615 ns** |  **0.2336 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  45.298 ns |   4.2134 ns |  0.2309 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  34.548 ns |   3.1550 ns |  0.1729 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  36.701 ns |   2.7470 ns |  0.1506 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  37.659 ns |   5.0564 ns |  0.2772 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 133.968 ns |  12.4505 ns |  0.6825 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 156.782 ns |  97.0321 ns |  5.3187 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 116.681 ns |  69.0580 ns |  3.7853 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 146.239 ns |  10.6953 ns |  0.5862 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 132.572 ns |   1.5985 ns |  0.0876 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **71.228 ns** |  **53.5885 ns** |  **2.9374 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  70.457 ns |   3.9670 ns |  0.2174 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  34.082 ns |   0.4353 ns |  0.0239 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  39.308 ns |   5.9471 ns |  0.3260 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  64.239 ns |   5.0953 ns |  0.2793 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 213.763 ns |  39.1192 ns |  2.1443 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 261.882 ns |  26.1444 ns |  1.4331 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 108.920 ns |   4.2043 ns |  0.2305 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 157.019 ns | 114.1595 ns |  6.2575 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 247.183 ns |  52.9146 ns |  2.9004 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** | **134.620 ns** |  **17.9387 ns** |  **0.9833 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 147.726 ns |  11.1366 ns |  0.6104 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 224.225 ns | 166.3372 ns |  9.1175 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 120.195 ns |  10.7106 ns |  0.5871 ns | 0.0072 |     120 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 111.675 ns |   4.0359 ns |  0.2212 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 250.862 ns |  17.3291 ns |  0.9499 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 287.512 ns | 549.7979 ns | 30.1363 ns | 0.0215 |     136 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 171.510 ns |  10.3390 ns |  0.5667 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 303.090 ns |  53.0319 ns |  2.9069 ns | 0.0443 |     281 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 338.322 ns |  77.2623 ns |  4.2350 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |  **15.095 ns** |   **0.4484 ns** |  **0.0246 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  16.369 ns |   0.3567 ns |  0.0196 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.328 ns |   0.2111 ns |  0.0116 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.286 ns |   1.0267 ns |  0.0563 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  11.192 ns |   3.5882 ns |  0.1967 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.907 ns |   4.7094 ns |  0.2581 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  42.646 ns |   2.5337 ns |  0.1389 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  31.047 ns |   1.0029 ns |  0.0550 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  25.025 ns |   0.3997 ns |  0.0219 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  30.251 ns |   2.9873 ns |  0.1637 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |  **15.181 ns** |   **0.6831 ns** |  **0.0374 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  17.039 ns |   1.1273 ns |  0.0618 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   9.041 ns |   0.7865 ns |  0.0431 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   5.981 ns |   0.4068 ns |  0.0223 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  11.201 ns |   1.0678 ns |  0.0585 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.699 ns |   1.4576 ns |  0.0799 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  45.482 ns |   5.4505 ns |  0.2988 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  32.045 ns |   0.5326 ns |  0.0292 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  24.243 ns |   2.5626 ns |  0.1405 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  29.616 ns |   3.0109 ns |  0.1650 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |  **15.232 ns** |   **0.9014 ns** |  **0.0494 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  15.970 ns |   0.0814 ns |  0.0045 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.949 ns |   5.9677 ns |  0.3271 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   8.168 ns |   0.3481 ns |  0.0191 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  11.054 ns |   0.7325 ns |  0.0402 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.404 ns |   0.6781 ns |  0.0372 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  41.408 ns |   1.4550 ns |  0.0798 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.969 ns |   0.6638 ns |  0.0364 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  31.494 ns |   2.6354 ns |  0.1445 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  30.078 ns |   1.2759 ns |  0.0699 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97**                   | **89**                   |  **28.330 ns** |   **2.4227 ns** |  **0.1328 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  28.693 ns |   1.1787 ns |  0.0646 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  13.719 ns |   1.2334 ns |  0.0676 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  12.907 ns |   0.1142 ns |  0.0063 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  21.587 ns |  21.5347 ns |  1.1804 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  69.308 ns |   8.9040 ns |  0.4881 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  79.960 ns |   3.8613 ns |  0.2117 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  51.973 ns |   2.8364 ns |  0.1555 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  71.987 ns |   1.0810 ns |  0.0593 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  64.315 ns |   5.6489 ns |  0.3096 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000**                 | **100**                  |  **28.376 ns** |   **1.7016 ns** |  **0.0933 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  30.101 ns |   1.6135 ns |  0.0884 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  13.082 ns |   0.7161 ns |  0.0393 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  21.157 ns |   0.6629 ns |  0.0363 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  20.407 ns |   1.7696 ns |  0.0970 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  65.184 ns |   7.7377 ns |  0.4241 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  80.622 ns |   0.9851 ns |  0.0540 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  51.854 ns |   2.6134 ns |  0.1432 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  | 110.653 ns |   0.5593 ns |  0.0307 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  52.643 ns |   1.6214 ns |  0.0889 ns |      - |         - |
