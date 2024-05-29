```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method                    | Job                         | Runtime            | a                    | b                    | Mean        | Error      | StdDev    | Gen0   | Allocated |
|-------------------------- |---------------------------- |------------------- |--------------------- |--------------------- |------------:|-----------:|----------:|-------:|----------:|
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **25.9307 ns** |  **2.0808 ns** | **0.1141 ns** | **0.0029** |      **48 B** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |   4.1434 ns |  0.2349 ns | 0.0129 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  23.1432 ns |  1.1777 ns | 0.0646 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  22.4952 ns |  1.1108 ns | 0.0609 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)00000 [39] | 1/1000000000000      |  26.4647 ns |  4.9430 ns | 0.2709 ns | 0.0029 |      48 B |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  78.9724 ns |  1.0456 ns | 0.0573 ns | 0.0076 |      48 B |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |   8.6384 ns |  0.4644 ns | 0.0255 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  38.4268 ns |  0.8549 ns | 0.0469 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  19.6672 ns |  1.2033 ns | 0.0660 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  76.6361 ns |  6.8069 ns | 0.3731 ns | 0.0076 |      48 B |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024**                | **-1/1024**              |  **10.2409 ns** |  **0.5879 ns** | **0.0322 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |   4.1173 ns |  0.1736 ns | 0.0095 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  10.8435 ns |  1.7616 ns | 0.0966 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |   7.7597 ns |  0.7293 ns | 0.0400 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -1024                | -1/1024              |  11.4499 ns |  0.5534 ns | 0.0303 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  43.9467 ns |  8.1405 ns | 0.4462 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  10.0413 ns |  2.7929 ns | 0.1531 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  35.0760 ns |  0.2347 ns | 0.0129 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  18.6478 ns |  1.6652 ns | 0.0913 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  40.5268 ns |  0.4142 ns | 0.0227 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45**                  | **1/6**                  |   **9.6279 ns** |  **0.1768 ns** | **0.0097 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |   3.9599 ns |  0.1842 ns | 0.0101 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  11.2861 ns |  0.1618 ns | 0.0089 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |   7.5838 ns |  0.0559 ns | 0.0031 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | -45                  | 1/6                  |  10.9554 ns |  0.8365 ns | 0.0459 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  42.2684 ns |  1.9250 ns | 0.1055 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |   0.0983 ns |  0.1764 ns | 0.0097 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  35.0873 ns |  0.2472 ns | 0.0135 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  18.1556 ns |  1.1330 ns | 0.0621 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  48.1374 ns |  1.6874 ns | 0.0925 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0**                    | **1**                    |   **8.4555 ns** |  **1.6107 ns** | **0.0883 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   3.9888 ns |  0.0818 ns | 0.0045 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  10.8258 ns |  0.8911 ns | 0.0488 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |   7.7915 ns |  0.5168 ns | 0.0283 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 0                    | 1                    |  12.2302 ns |  0.6932 ns | 0.0380 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  20.8711 ns |  0.7637 ns | 0.0419 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  10.0831 ns |  0.2156 ns | 0.0118 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  36.6802 ns | 21.5859 ns | 1.1832 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  18.1967 ns |  0.8106 ns | 0.0444 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  19.0354 ns |  1.7059 ns | 0.0935 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |   **8.3071 ns** |  **0.2902 ns** | **0.0159 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   4.1131 ns |  0.3720 ns | 0.0204 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  10.6093 ns |  1.4916 ns | 0.0818 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |   7.5600 ns |  0.3015 ns | 0.0165 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  12.2901 ns |  0.7834 ns | 0.0429 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  20.9045 ns |  0.1768 ns | 0.0097 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |   8.6338 ns |  1.2172 ns | 0.0667 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  35.0819 ns |  0.5219 ns | 0.0286 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  18.1965 ns |  0.4458 ns | 0.0244 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              |  18.2171 ns |  0.3493 ns | 0.0191 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **16.1522 ns** |  **0.5096 ns** | **0.0279 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |   3.9955 ns |  0.3439 ns | 0.0188 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  10.7283 ns |  0.2901 ns | 0.0159 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |   7.6096 ns |  0.3509 ns | 0.0192 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  17.0437 ns |  3.9058 ns | 0.2141 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  59.7929 ns |  5.0408 ns | 0.2763 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  10.3289 ns |  3.0919 ns | 0.1695 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  35.8168 ns | 19.9975 ns | 1.0961 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  18.7064 ns |  0.2550 ns | 0.0140 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               |  55.8550 ns |  3.3657 ns | 0.1845 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** |  **42.5380 ns** |  **0.1596 ns** | **0.0087 ns** | **0.0048** |      **80 B** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |   5.9396 ns |  0.1633 ns | 0.0089 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  62.3351 ns | 12.8325 ns | 0.7034 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  32.9847 ns |  4.1312 ns | 0.2264 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 88427(...)10656 [31] | 88427(...)21312 [31] |  46.7428 ns | 17.6025 ns | 0.9649 ns | 0.0048 |      80 B |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 124.5664 ns |  4.3992 ns | 0.2411 ns | 0.0126 |      80 B |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  21.8676 ns |  0.7438 ns | 0.0408 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  41.7827 ns | 14.9739 ns | 0.8208 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] |  24.7133 ns |  3.3290 ns | 0.1825 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 119.6512 ns |  5.0064 ns | 0.2744 ns | 0.0126 |      80 B |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **7.2223 ns** |  **0.1617 ns** | **0.0089 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   3.9597 ns |  0.2814 ns | 0.0154 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |  10.8117 ns |  5.0375 ns | 0.2761 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   8.0077 ns |  0.3220 ns | 0.0176 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   9.2551 ns |  0.0645 ns | 0.0035 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  19.6779 ns |  0.3588 ns | 0.0197 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |   8.4708 ns |  1.0281 ns | 0.0564 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  29.7023 ns |  1.0054 ns | 0.0551 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  18.7782 ns |  0.3277 ns | 0.0180 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  16.2557 ns |  1.2514 ns | 0.0686 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **7.7889 ns** |  **2.1903 ns** | **0.1201 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   4.1099 ns |  0.0360 ns | 0.0020 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  11.4351 ns |  2.6529 ns | 0.1454 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   7.6080 ns |  0.6590 ns | 0.0361 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |  11.7524 ns |  0.2787 ns | 0.0153 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  19.6512 ns |  1.1298 ns | 0.0619 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |   8.7839 ns |  0.1900 ns | 0.0104 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  35.5199 ns |  6.8176 ns | 0.3737 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  18.2101 ns |  0.2192 ns | 0.0120 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  17.8031 ns |  0.3559 ns | 0.0195 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **8.1919 ns** |  **0.3035 ns** | **0.0166 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   3.9600 ns |  0.1915 ns | 0.0105 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  11.3756 ns |  2.0537 ns | 0.1126 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   7.9658 ns |  0.0899 ns | 0.0049 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |  11.6887 ns |  2.6693 ns | 0.1463 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  19.6517 ns |  0.2937 ns | 0.0161 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |   8.4539 ns |  0.5900 ns | 0.0323 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  35.2684 ns |  0.6948 ns | 0.0381 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  18.5218 ns |  0.2898 ns | 0.0159 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  24.5102 ns |  2.1059 ns | 0.1154 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97**                   | **89**                   |   **8.2909 ns** |  **2.8212 ns** | **0.1546 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   4.0985 ns |  0.0580 ns | 0.0032 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  10.6623 ns |  1.1736 ns | 0.0643 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |   7.7721 ns |  0.4086 ns | 0.0224 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 97                   | 89                   |  12.1407 ns |  0.5377 ns | 0.0295 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  20.6392 ns |  0.6838 ns | 0.0375 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  10.0072 ns |  1.6316 ns | 0.0894 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  15.1461 ns |  2.4549 ns | 0.1346 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  18.0904 ns |  1.7389 ns | 0.0953 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  18.8601 ns |  0.3448 ns | 0.0189 ns |      - |         - |
| **Equals**                    | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000**                 | **100**                  |   **8.1903 ns** |  **0.8252 ns** | **0.0452 ns** |      **-** |         **-** |
| StrictEqualityEquals      | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   3.9370 ns |  0.1987 ns | 0.0109 ns |      - |         - |
| GetHashCode               | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  11.3439 ns |  0.3192 ns | 0.0175 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |   7.8935 ns |  1.8804 ns | 0.1031 ns |      - |         - |
| CompareTo                 | ShortRun-.NET 8.0           | .NET 8.0           | 1000                 | 100                  |  12.0511 ns |  0.7923 ns | 0.0434 ns |      - |         - |
| Equals                    | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  20.7390 ns |  0.1166 ns | 0.0064 ns |      - |         - |
| StrictEqualityEquals      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |   2.1761 ns |  1.2987 ns | 0.0712 ns |      - |         - |
| GetHashCode               | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  35.8274 ns | 11.3816 ns | 0.6239 ns |      - |         - |
| StrictEqualityGetHashCode | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  18.6090 ns |  8.5141 ns | 0.4667 ns |      - |         - |
| CompareTo                 | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  18.7209 ns |  0.6563 ns | 0.0360 ns |      - |         - |
