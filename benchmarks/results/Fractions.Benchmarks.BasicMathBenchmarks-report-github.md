```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4291/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]                      : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9232.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method   | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|--------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **39.188 ns** |  **1.3272 ns** | **0.0727 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  36.038 ns |  2.4410 ns | 0.1338 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  34.962 ns |  1.5616 ns | 0.0856 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  31.947 ns |  0.3829 ns | 0.0210 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  30.281 ns |  3.0317 ns | 0.1662 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 121.784 ns | 17.2314 ns | 0.9445 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 142.102 ns |  4.9125 ns | 0.2693 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 136.428 ns | 19.1289 ns | 1.0485 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 133.518 ns | 18.2479 ns | 1.0002 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 125.281 ns |  5.1105 ns | 0.2801 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **81.932 ns** |  **2.5536 ns** | **0.1400 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  76.923 ns |  5.6015 ns | 0.3070 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      | 106.916 ns |  4.4785 ns | 0.2455 ns | 0.0086 |     144 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  32.736 ns |  0.9398 ns | 0.0515 ns | 0.0029 |      48 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  63.563 ns |  1.2450 ns | 0.0682 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 205.129 ns |  1.3451 ns | 0.0737 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 222.649 ns |  6.6673 ns | 0.3655 ns | 0.0229 |     144 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 233.369 ns | 14.6624 ns | 0.8037 ns | 0.0293 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  97.089 ns |  4.7101 ns | 0.2582 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 153.658 ns |  8.1349 ns | 0.4459 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024**                | **-1/1024**              |  **30.308 ns** |  **0.7051 ns** | **0.0386 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  41.178 ns |  0.7427 ns | 0.0407 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  29.660 ns |  1.8795 ns | 0.1030 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  17.432 ns |  1.3117 ns | 0.0719 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  33.859 ns |  0.2850 ns | 0.0156 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 116.152 ns |  2.5620 ns | 0.1404 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 133.434 ns |  6.3476 ns | 0.3479 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 126.253 ns |  4.7545 ns | 0.2606 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  66.553 ns |  3.8936 ns | 0.2134 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 120.368 ns |  2.4782 ns | 0.1358 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45**                  | **1/6**                  |  **32.821 ns** |  **0.9443 ns** | **0.0518 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  32.644 ns |  0.6029 ns | 0.0330 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  30.946 ns |  0.9879 ns | 0.0542 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  16.940 ns |  0.6193 ns | 0.0339 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  33.296 ns |  0.1780 ns | 0.0098 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 111.639 ns |  1.6285 ns | 0.0893 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 124.965 ns |  1.1307 ns | 0.0620 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 131.686 ns |  4.0131 ns | 0.2200 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  65.922 ns |  5.9635 ns | 0.3269 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 120.533 ns | 44.5968 ns | 2.4445 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    | **1**                    |   **6.931 ns** |  **0.6451 ns** | **0.0354 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   9.346 ns |  0.2759 ns | 0.0151 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   8.489 ns |  1.0564 ns | 0.0579 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  10.589 ns |  0.8565 ns | 0.0469 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   6.633 ns |  3.4773 ns | 0.1906 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  23.653 ns |  0.6625 ns | 0.0363 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  35.715 ns |  1.3394 ns | 0.0734 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  26.439 ns |  2.2425 ns | 0.1229 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  27.685 ns |  0.8765 ns | 0.0480 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  26.848 ns |  1.4225 ns | 0.0780 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **45.073 ns** |  **1.0825 ns** | **0.0593 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  35.391 ns |  1.6508 ns | 0.0905 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  32.576 ns |  1.4899 ns | 0.0817 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  34.400 ns |  1.2582 ns | 0.0690 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  30.789 ns |  0.1315 ns | 0.0072 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 127.741 ns | 31.5917 ns | 1.7316 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 144.218 ns |  2.9962 ns | 0.1642 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 112.294 ns |  5.6610 ns | 0.3103 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 134.514 ns | 25.5855 ns | 1.4024 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 125.496 ns |  8.1224 ns | 0.4452 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |  **32.959 ns** |  **0.4874 ns** | **0.0267 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  34.265 ns |  2.4222 ns | 0.1328 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  41.984 ns |  1.3231 ns | 0.0725 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  37.087 ns |  0.9402 ns | 0.0515 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  28.266 ns |  0.8972 ns | 0.0492 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  90.558 ns |  1.4139 ns | 0.0775 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 105.497 ns |  4.4786 ns | 0.2455 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 143.402 ns |  7.5144 ns | 0.4119 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 136.847 ns | 40.9394 ns | 2.2440 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              |  94.228 ns |  6.9055 ns | 0.3785 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **60.355 ns** |  **2.4006 ns** | **0.1316 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  60.721 ns |  3.2773 ns | 0.1796 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  32.081 ns |  0.6353 ns | 0.0348 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  37.678 ns |  4.5627 ns | 0.2501 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  61.225 ns |  6.5440 ns | 0.3587 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 207.286 ns | 13.7998 ns | 0.7564 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 242.433 ns | 21.7429 ns | 1.1918 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 102.165 ns |  5.6521 ns | 0.3098 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 136.407 ns | 13.4366 ns | 0.7365 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 238.176 ns | 26.3848 ns | 1.4462 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **61.941 ns** |  **3.5474 ns** | **0.1944 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  70.699 ns |  2.2036 ns | 0.1208 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  34.995 ns |  2.4049 ns | 0.1318 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  37.183 ns |  0.4027 ns | 0.0221 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  69.198 ns |  2.5902 ns | 0.1420 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 256.494 ns | 34.9339 ns | 1.9148 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 280.896 ns | 48.4844 ns | 2.6576 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 134.842 ns | 21.5938 ns | 1.1836 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 137.216 ns |  2.0926 ns | 0.1147 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 281.003 ns | 13.2936 ns | 0.7287 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **47161(...)70496 [33]** | **139.688 ns** |  **9.8622 ns** | **0.5406 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 134.709 ns | 11.4480 ns | 0.6275 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 268.497 ns |  8.1633 ns | 0.4475 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] | 145.555 ns |  2.4970 ns | 0.1369 ns | 0.0105 |     176 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 47161(...)70496 [33] |  70.839 ns |  1.5121 ns | 0.0829 ns | 0.0038 |      64 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 243.811 ns |  7.9662 ns | 0.4367 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 265.774 ns | 18.8188 ns | 1.0315 ns | 0.0215 |     136 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 159.555 ns | 12.4617 ns | 0.6831 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 316.911 ns | 54.7781 ns | 3.0026 ns | 0.0482 |     305 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 47161(...)70496 [33] | 234.899 ns |  6.3579 ns | 0.3485 ns | 0.0215 |     136 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** | **123.673 ns** |  **1.4987 ns** | **0.0821 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 136.274 ns |  5.6647 ns | 0.3105 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 213.234 ns |  8.7649 ns | 0.4804 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 113.554 ns |  3.8532 ns | 0.2112 ns | 0.0072 |     120 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 103.103 ns |  0.6624 ns | 0.0363 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 243.642 ns | 16.9879 ns | 0.9312 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 264.809 ns | 27.0847 ns | 1.4846 ns | 0.0215 |     136 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 160.943 ns |  8.5406 ns | 0.4681 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 307.587 ns | 56.3424 ns | 3.0883 ns | 0.0443 |     281 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 327.455 ns |  8.8867 ns | 0.4871 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **7.155 ns** |  **0.7921 ns** | **0.0434 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.836 ns |  1.0072 ns | 0.0552 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   7.952 ns |  2.6124 ns | 0.1432 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   7.629 ns |  0.3089 ns | 0.0169 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.029 ns |  0.0960 ns | 0.0053 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  24.502 ns |  1.0445 ns | 0.0573 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  35.724 ns |  0.2398 ns | 0.0131 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  30.095 ns |  2.9700 ns | 0.1628 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  24.271 ns |  0.1426 ns | 0.0078 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.435 ns |  3.4056 ns | 0.1867 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **7.651 ns** |  **1.3643 ns** | **0.0748 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   9.286 ns |  0.4387 ns | 0.0240 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   7.961 ns |  2.3935 ns | 0.1312 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   5.483 ns |  0.5772 ns | 0.0316 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.181 ns |  0.5142 ns | 0.0282 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  27.963 ns |  0.8581 ns | 0.0470 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  40.758 ns |  1.0456 ns | 0.0573 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.946 ns |  3.5481 ns | 0.1945 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  24.287 ns |  1.1493 ns | 0.0630 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  26.434 ns |  0.3927 ns | 0.0215 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **7.267 ns** |  **0.5793 ns** | **0.0318 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   8.635 ns |  0.8495 ns | 0.0466 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.321 ns |  0.3823 ns | 0.0210 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.883 ns |  1.3901 ns | 0.0762 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   6.078 ns |  0.4801 ns | 0.0263 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  24.742 ns |  0.4984 ns | 0.0273 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  34.111 ns |  3.6028 ns | 0.1975 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.394 ns |  3.3637 ns | 0.1844 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  31.067 ns |  5.7676 ns | 0.3161 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.367 ns |  0.5341 ns | 0.0293 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **26714619/25510582**    | **137.462 ns** |  **2.0245 ns** | **0.1110 ns** | **0.0076** |     **128 B** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    | 126.352 ns | 10.6207 ns | 0.5822 ns | 0.0076 |     128 B |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    | 113.557 ns |  5.9015 ns | 0.3235 ns | 0.0076 |     128 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    |  42.879 ns |  3.2841 ns | 0.1800 ns | 0.0038 |      64 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 26714619/25510582    |  73.978 ns |  3.4401 ns | 0.1886 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 265.100 ns | 20.2166 ns | 1.1081 ns | 0.0215 |     136 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 281.825 ns | 31.8713 ns | 1.7470 ns | 0.0200 |     128 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 208.063 ns |  4.0440 ns | 0.2217 ns | 0.0203 |     128 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 111.325 ns |  2.5836 ns | 0.1416 ns | 0.0101 |      64 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 26714619/25510582    | 182.658 ns | 17.1973 ns | 0.9426 ns | 0.0203 |     128 B |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **122925461/78256779**   |  **57.909 ns** |  **3.4091 ns** | **0.1869 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  48.821 ns |  1.0393 ns | 0.0570 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  85.675 ns |  1.6200 ns | 0.0888 ns | 0.0038 |      64 B |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  73.487 ns |  5.0086 ns | 0.2745 ns | 0.0057 |      96 B |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 122925461/78256779   |  15.277 ns |  0.4934 ns | 0.0270 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 157.777 ns |  7.5415 ns | 0.4134 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 129.944 ns | 11.4446 ns | 0.6273 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 144.846 ns |  3.4083 ns | 0.1868 ns | 0.0100 |      64 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   | 213.540 ns | 15.3836 ns | 0.8432 ns | 0.0253 |     160 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 122925461/78256779   |  48.419 ns |  1.5892 ns | 0.0871 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97**                   | **89**                   |  **19.610 ns** |  **0.8909 ns** | **0.0488 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  21.306 ns |  1.2515 ns | 0.0686 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  16.383 ns |  0.3627 ns | 0.0199 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  23.731 ns |  1.0417 ns | 0.0571 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  15.267 ns |  0.4462 ns | 0.0245 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  55.639 ns |  0.4907 ns | 0.0269 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  71.894 ns |  2.2928 ns | 0.1257 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  65.308 ns |  4.9666 ns | 0.2722 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  96.895 ns |  1.1484 ns | 0.0629 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  58.993 ns |  0.8857 ns | 0.0485 ns |      - |         - |
| **Add**      | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000**                 | **100**                  |  **19.564 ns** |  **1.1980 ns** | **0.0657 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  21.219 ns |  0.2477 ns | 0.0136 ns |      - |         - |
| Multiply | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  16.366 ns |  0.1092 ns | 0.0060 ns |      - |         - |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  29.569 ns |  1.8001 ns | 0.0987 ns |      - |         - |
| Mod      | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  15.369 ns |  0.2044 ns | 0.0112 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  56.745 ns |  3.5091 ns | 0.1923 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  79.981 ns |  0.8270 ns | 0.0453 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  64.692 ns |  1.8882 ns | 0.1035 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  | 130.065 ns | 24.7568 ns | 1.3570 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  48.407 ns |  6.6733 ns | 0.3658 ns |      - |         - |
