```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method                    | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|-------------------------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **10.181 ns** |  **0.9018 ns** | **0.0494 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |   3.910 ns |  0.4010 ns | 0.0220 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  23.033 ns |  1.2443 ns | 0.0682 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  22.439 ns |  3.8782 ns | 0.2126 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |   8.082 ns |  0.2287 ns | 0.0125 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  21.090 ns |  2.4253 ns | 0.1329 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  11.401 ns |  2.3216 ns | 0.1273 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  39.370 ns |  0.8154 ns | 0.0447 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  19.764 ns |  1.6437 ns | 0.0901 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  15.836 ns |  1.2913 ns | 0.0708 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024**                | **-1/1024**              |  **17.265 ns** |  **1.1826 ns** | **0.0648 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |   2.517 ns |  0.3361 ns | 0.0184 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  10.868 ns |  1.0329 ns | 0.0566 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |   7.886 ns |  0.6171 ns | 0.0338 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  12.132 ns |  0.2879 ns | 0.0158 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  24.184 ns |  4.4611 ns | 0.2445 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |   8.866 ns |  0.5136 ns | 0.0282 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  35.560 ns |  1.4489 ns | 0.0794 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  18.360 ns |  1.5693 ns | 0.0860 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  28.589 ns |  2.8025 ns | 0.1536 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45**                  | **1/6**                  |   **9.851 ns** |  **1.2394 ns** | **0.0679 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |   3.974 ns |  0.4574 ns | 0.0251 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  11.234 ns |  5.7755 ns | 0.3166 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |   6.309 ns | 12.5629 ns | 0.6886 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |   7.797 ns |  1.3793 ns | 0.0756 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  20.992 ns |  5.2186 ns | 0.2861 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  11.468 ns |  3.1418 ns | 0.1722 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  35.746 ns |  4.1227 ns | 0.2260 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  18.338 ns |  1.5349 ns | 0.0841 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  15.666 ns |  1.0544 ns | 0.0578 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    | **1**                    |  **10.164 ns** |  **1.3502 ns** | **0.0740 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   3.998 ns |  0.1615 ns | 0.0089 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  11.425 ns |  0.7713 ns | 0.0423 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   8.034 ns |  0.7309 ns | 0.0401 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   8.250 ns |  0.6861 ns | 0.0376 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  21.530 ns |  1.7279 ns | 0.0947 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  10.228 ns |  1.5005 ns | 0.0822 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  35.321 ns |  3.3332 ns | 0.1827 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  18.404 ns |  2.1436 ns | 0.1175 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  16.294 ns |  1.2796 ns | 0.0701 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **10.250 ns** |  **1.0059 ns** | **0.0551 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   4.146 ns |  0.2213 ns | 0.0121 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  10.664 ns |  0.0120 ns | 0.0007 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   7.806 ns |  2.2208 ns | 0.1217 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   8.287 ns |  0.6083 ns | 0.0333 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  22.358 ns |  2.3081 ns | 0.1265 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |   8.540 ns |  0.6659 ns | 0.0365 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  43.726 ns |  3.2603 ns | 0.1787 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  18.212 ns |  0.9724 ns | 0.0533 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  17.764 ns |  0.7672 ns | 0.0421 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **17.087 ns** |  **0.6188 ns** | **0.0339 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |   4.161 ns |  0.0581 ns | 0.0032 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  10.800 ns |  0.2349 ns | 0.0129 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |   7.828 ns |  0.4222 ns | 0.0231 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  11.762 ns |  0.5794 ns | 0.0318 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  24.736 ns |  1.9062 ns | 0.1045 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |   8.712 ns |  0.4432 ns | 0.0243 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  35.435 ns |  1.8715 ns | 0.1026 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  18.441 ns |  0.3126 ns | 0.0171 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  27.584 ns |  0.6832 ns | 0.0374 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** |  **22.461 ns** |  **1.9460 ns** | **0.1067 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |   5.984 ns |  0.1624 ns | 0.0089 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  34.300 ns |  2.9850 ns | 0.1636 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  32.904 ns |  3.0667 ns | 0.1681 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  15.930 ns |  8.1109 ns | 0.4446 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  31.660 ns |  2.3813 ns | 0.1305 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  22.250 ns |  0.9761 ns | 0.0535 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  42.224 ns |  2.3680 ns | 0.1298 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  25.016 ns |  1.4800 ns | 0.0811 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  35.278 ns |  1.3580 ns | 0.0744 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **9.740 ns** |  **1.8449 ns** | **0.1011 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   3.960 ns |  0.1799 ns | 0.0099 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  10.800 ns |  0.4277 ns | 0.0234 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.014 ns |  0.3865 ns | 0.0212 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.223 ns |  0.2557 ns | 0.0140 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  20.434 ns |  0.7048 ns | 0.0386 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |   8.661 ns |  0.0725 ns | 0.0040 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  35.362 ns |  1.7086 ns | 0.0937 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  12.655 ns |  1.3653 ns | 0.0748 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  16.752 ns |  0.2390 ns | 0.0131 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **9.336 ns** |  **0.2322 ns** | **0.0127 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   3.983 ns |  0.2854 ns | 0.0156 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  10.876 ns |  0.1290 ns | 0.0071 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   7.826 ns |  0.0849 ns | 0.0047 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   8.114 ns |  0.4410 ns | 0.0242 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  20.396 ns |  0.7671 ns | 0.0420 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |   9.112 ns |  6.6791 ns | 0.3661 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  35.890 ns |  8.2806 ns | 0.4539 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  18.271 ns |  1.0827 ns | 0.0593 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  15.427 ns |  1.5295 ns | 0.0838 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **9.500 ns** |  **1.1264 ns** | **0.0617 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   3.991 ns |  0.7551 ns | 0.0414 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  10.816 ns |  0.6450 ns | 0.0354 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.867 ns |  0.2187 ns | 0.0120 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.848 ns |  0.6683 ns | 0.0366 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  21.530 ns |  2.2310 ns | 0.1223 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  10.209 ns |  0.1954 ns | 0.0107 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  35.307 ns |  2.0146 ns | 0.1104 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  18.334 ns |  1.6652 ns | 0.0913 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  15.239 ns |  0.7000 ns | 0.0384 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **12345(...)00000 [36]** | **61728(...)00000 [34]** |  **59.631 ns** |  **3.1685 ns** | **0.1737 ns** | **0.0019** |      **32 B** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |   4.104 ns |  0.3834 ns | 0.0210 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  35.082 ns |  0.2705 ns | 0.0148 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  32.984 ns |  1.1077 ns | 0.0607 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 12345(...)00000 [36] | 61728(...)00000 [34] |  53.182 ns |  3.3921 ns | 0.1859 ns | 0.0019 |      32 B |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] | 123.194 ns | 17.3174 ns | 0.9492 ns | 0.0100 |      64 B |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] |  11.338 ns |  0.7243 ns | 0.0397 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] |  41.989 ns |  6.8949 ns | 0.3779 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] |  24.727 ns |  2.3511 ns | 0.1289 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 12345(...)00000 [36] | 61728(...)00000 [34] | 109.338 ns |  4.3170 ns | 0.2366 ns | 0.0114 |      72 B |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97**                   | **89**                   |  **10.277 ns** |  **0.4571 ns** | **0.0251 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   8.193 ns |  1.7385 ns | 0.0953 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  10.674 ns |  0.2730 ns | 0.0150 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   8.092 ns |  0.9382 ns | 0.0514 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   8.432 ns |  2.4714 ns | 0.1355 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  22.417 ns |  0.5937 ns | 0.0325 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |   8.555 ns |  0.7998 ns | 0.0438 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  35.446 ns |  1.9095 ns | 0.1047 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  18.279 ns |  1.0954 ns | 0.0600 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |   3.830 ns |  1.8899 ns | 0.1036 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000**                 | **100**                  |  **10.333 ns** |  **0.9723 ns** | **0.0533 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   3.494 ns |  0.3869 ns | 0.0212 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  10.704 ns |  0.7274 ns | 0.0399 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   8.036 ns |  0.3269 ns | 0.0179 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   8.242 ns |  0.6177 ns | 0.0339 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  21.735 ns |  4.3965 ns | 0.2410 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |   8.914 ns |  3.2817 ns | 0.1799 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  35.912 ns |  4.3834 ns | 0.2403 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  18.358 ns |  1.4389 ns | 0.0789 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  16.358 ns |  0.4995 ns | 0.0274 ns |      - |         - |
