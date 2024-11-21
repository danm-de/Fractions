```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
  [Host]                      : .NET Framework 4.8.1 (4.8.9282.0), X64 RyuJIT VectorSize=256
  ShortRun-.NET 9.0           : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9282.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method   | Job                         | Runtime            | a                    | b                    | Mean       | Error       | StdDev    | Gen0   | Allocated |
|--------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|------------:|----------:|-------:|----------:|
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1000(...)00000 [39]** | **1/1000000000000**      |  **96.519 ns** |  **13.6066 ns** | **0.7458 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] | 1/1000000000000      |  91.885 ns |   0.9735 ns | 0.0534 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] | 1/1000000000000      |  96.690 ns |   5.0750 ns | 0.2782 ns | 0.0043 |      72 B |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] | 1/1000000000000      |  35.940 ns |   1.3203 ns | 0.0724 ns | 0.0029 |      48 B |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | -1000(...)00000 [39] | 1/1000000000000      |  68.560 ns |   9.4214 ns | 0.5164 ns | 0.0048 |      80 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 214.856 ns |   4.6836 ns | 0.2567 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 225.531 ns |  12.5199 ns | 0.6863 ns | 0.0229 |     144 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 208.739 ns |  10.3526 ns | 0.5675 ns | 0.0293 |     185 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      |  96.967 ns |   2.8407 ns | 0.1557 ns | 0.0076 |      48 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)00000 [39] | 1/1000000000000      | 186.919 ns |  11.3861 ns | 0.6241 ns | 0.0076 |      48 B |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-1024**                | **-1/1024**              |  **24.632 ns** |   **0.6120 ns** | **0.0335 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | -1024                | -1/1024              |  28.021 ns |   4.2011 ns | 0.2303 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | -1024                | -1/1024              |  32.221 ns |   0.4583 ns | 0.0251 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | -1024                | -1/1024              |  16.423 ns |   0.5222 ns | 0.0286 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | -1024                | -1/1024              |  32.808 ns |   0.3421 ns | 0.0188 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 123.880 ns |  13.9749 ns | 0.7660 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 142.583 ns |   1.8195 ns | 0.0997 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 155.320 ns |   3.9334 ns | 0.2156 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              |  67.075 ns |   0.3781 ns | 0.0207 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024                | -1/1024              | 143.922 ns |   0.7167 ns | 0.0393 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **-45**                  | **1/6**                  |  **25.002 ns** |   **0.0877 ns** | **0.0048 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | -45                  | 1/6                  |  26.243 ns |   1.8208 ns | 0.0998 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | -45                  | 1/6                  |  30.919 ns |   0.4582 ns | 0.0251 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | -45                  | 1/6                  |  16.026 ns |   0.1683 ns | 0.0092 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | -45                  | 1/6                  |  31.528 ns |   0.6057 ns | 0.0332 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 116.304 ns |   1.2869 ns | 0.0705 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 155.875 ns |  12.5246 ns | 0.6865 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 113.228 ns |   5.9724 ns | 0.3274 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  |  65.307 ns |   3.5766 ns | 0.1960 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45                  | 1/6                  | 153.167 ns |   8.2051 ns | 0.4498 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **0**                    | **1**                    |  **15.295 ns** |   **0.4199 ns** | **0.0230 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 0                    | 1                    |  15.716 ns |   1.8915 ns | 0.1037 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 0                    | 1                    |   7.534 ns |   8.5543 ns | 0.4689 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 0                    | 1                    |  13.005 ns |   0.3611 ns | 0.0198 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 0                    | 1                    |  11.351 ns |   1.1898 ns | 0.0652 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  27.541 ns |   0.3395 ns | 0.0186 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  42.958 ns |   1.7173 ns | 0.0941 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  28.385 ns |   0.1502 ns | 0.0082 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  31.973 ns |   1.7253 ns | 0.0946 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0                    | 1                    |  30.167 ns |   0.4844 ns | 0.0266 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **77/3600**              | **37/3600**              |  **52.081 ns** |   **1.9676 ns** | **0.1079 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |  46.412 ns |   0.1097 ns | 0.0060 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |  23.820 ns |   0.5187 ns | 0.0284 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |  44.321 ns |   2.9572 ns | 0.1621 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 77/3600              | 37/3600              |  49.666 ns |   1.2587 ns | 0.0690 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 137.154 ns |  12.8896 ns | 0.7065 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 151.167 ns |   1.2901 ns | 0.0707 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 123.261 ns |  32.6388 ns | 1.7890 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 177.431 ns |   2.7178 ns | 0.1490 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 160.939 ns |  11.2697 ns | 0.6177 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **27/200**               | **19/250**               |  **46.214 ns** |   **4.8879 ns** | **0.2679 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |  45.793 ns |   1.7085 ns | 0.0936 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |  23.999 ns |   1.2972 ns | 0.0711 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |  48.663 ns |  32.2283 ns | 1.7665 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 27/200               | 19/250               |  64.450 ns |   2.2779 ns | 0.1249 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 268.728 ns |  11.5180 ns | 0.6313 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 285.489 ns |   6.7607 ns | 0.3706 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 112.831 ns |   1.7166 ns | 0.0941 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 192.043 ns |  17.4329 ns | 0.9556 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 262.740 ns |  33.2492 ns | 1.8225 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **88427(...)10656 [31]** | **88427(...)21312 [31]** | **125.574 ns** |  **10.1929 ns** | **0.5587 ns** | **0.0057** |      **96 B** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 137.244 ns |   5.2223 ns | 0.2863 ns | 0.0057 |      96 B |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 229.984 ns |  15.4768 ns | 0.8483 ns | 0.0048 |      80 B |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 142.512 ns | 117.2768 ns | 6.4283 ns | 0.0072 |     120 B |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 88427(...)10656 [31] | 88427(...)21312 [31] | 113.217 ns |   9.4392 ns | 0.5174 ns | 0.0057 |      96 B |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 286.546 ns |   8.0539 ns | 0.4415 ns | 0.0229 |     144 B |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 304.712 ns |   7.8508 ns | 0.4303 ns | 0.0215 |     136 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 171.531 ns |  12.0912 ns | 0.6628 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 353.145 ns |   5.1156 ns | 0.2804 ns | 0.0443 |     281 B |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 88427(...)10656 [31] | 88427(...)21312 [31] | 344.495 ns |   0.6451 ns | 0.0354 ns | 0.0267 |     168 B |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **NaN**                  |  **15.452 ns** |   **0.2710 ns** | **0.0149 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |  16.051 ns |   0.1326 ns | 0.0073 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |   8.837 ns |   0.1355 ns | 0.0074 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |  12.570 ns |   0.2205 ns | 0.0121 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | NaN                  |  11.363 ns |   0.0774 ns | 0.0042 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.529 ns |   0.6141 ns | 0.0337 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  42.535 ns |   0.2081 ns | 0.0114 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  31.162 ns |   0.3470 ns | 0.0190 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  27.330 ns |   1.3312 ns | 0.0730 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  29.736 ns |   0.5745 ns | 0.0315 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **-∞**                   |  **15.649 ns** |   **0.2193 ns** | **0.0120 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |  16.235 ns |   0.1744 ns | 0.0096 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |   7.905 ns |   0.1466 ns | 0.0080 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |  11.721 ns |   0.3586 ns | 0.0197 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | -∞                   |  11.387 ns |   0.1389 ns | 0.0076 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.402 ns |   3.4205 ns | 0.1875 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  44.534 ns |   0.5726 ns | 0.0314 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.489 ns |   3.3664 ns | 0.1845 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  29.961 ns |   3.0592 ns | 0.1677 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  29.795 ns |   0.6092 ns | 0.0334 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **245850922/78256779**   | **0**                    |  **15.374 ns** |   **1.6678 ns** | **0.0914 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |  15.956 ns |   0.8005 ns | 0.0439 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |   7.014 ns |   2.2875 ns | 0.1254 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |  13.324 ns |   0.1301 ns | 0.0071 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 245850922/78256779   | 0                    |  11.208 ns |   0.6327 ns | 0.0347 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.391 ns |   3.4399 ns | 0.1886 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  46.317 ns |   0.4363 ns | 0.0239 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  27.921 ns |   1.9952 ns | 0.1094 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  35.039 ns |   5.1896 ns | 0.2845 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  29.696 ns |   1.9647 ns | 0.1077 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **97**                   | **89**                   |  **19.702 ns** |   **3.5281 ns** | **0.1934 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 97                   | 89                   |  25.777 ns |   2.2308 ns | 0.1223 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 97                   | 89                   |  10.298 ns |   2.9790 ns | 0.1633 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 97                   | 89                   |  19.777 ns |   6.6386 ns | 0.3639 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 97                   | 89                   |  20.835 ns |   0.1206 ns | 0.0066 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  63.028 ns |   7.4909 ns | 0.4106 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  88.406 ns |   2.0176 ns | 0.1106 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  60.039 ns |   3.4762 ns | 0.1905 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  82.959 ns |   9.5563 ns | 0.5238 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97                   | 89                   |  65.462 ns |  51.4872 ns | 2.8222 ns |      - |         - |
| **Add**      | **ShortRun-.NET 9.0**           | **.NET 9.0**           | **1000**                 | **100**                  |  **20.015 ns** |  **13.8866 ns** | **0.7612 ns** |      **-** |         **-** |
| Subtract | ShortRun-.NET 9.0           | .NET 9.0           | 1000                 | 100                  |  20.439 ns |   1.2445 ns | 0.0682 ns |      - |         - |
| Multiply | ShortRun-.NET 9.0           | .NET 9.0           | 1000                 | 100                  |  10.188 ns |   0.8772 ns | 0.0481 ns |      - |         - |
| Divide   | ShortRun-.NET 9.0           | .NET 9.0           | 1000                 | 100                  |  37.720 ns |   0.5734 ns | 0.0314 ns |      - |         - |
| Mod      | ShortRun-.NET 9.0           | .NET 9.0           | 1000                 | 100                  |  20.690 ns |   1.1031 ns | 0.0605 ns |      - |         - |
| Add      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  63.434 ns |   4.1829 ns | 0.2293 ns |      - |         - |
| Subtract | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  80.334 ns |   6.2145 ns | 0.3406 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  59.851 ns |   0.8790 ns | 0.0482 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  | 118.444 ns |   9.1764 ns | 0.5030 ns |      - |         - |
| Mod      | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000                 | 100                  |  52.093 ns |   1.6210 ns | 0.0888 ns |      - |         - |
