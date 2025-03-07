```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5487/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]   : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                          | StringFormat | fraction             | Mean      | Error      | StdDev    | Gen0   | Allocated |
|-------------------------------- |------------- |--------------------- |----------:|-----------:|----------:|-------:|----------:|
| **DecimalNotationFormatter_Format** | **?**            | **-123456789**           | **119.00 ns** | **127.811 ns** |  **7.006 ns** | **0.0119** |     **200 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-1234567/1000**        | **273.31 ns** | **324.682 ns** | **17.797 ns** | **0.0224** |     **376 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-42**                  |  **84.34 ns** |   **6.705 ns** |  **0.368 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-8842(...)10656 [32]** | **487.80 ns** |  **46.351 ns** |  **2.541 ns** | **0.0334** |     **568 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-5/2**                 | **179.01 ns** |  **10.977 ns** |  **0.602 ns** | **0.0176** |     **296 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-2/3**                 | **461.74 ns** | **108.858 ns** |  **5.967 ns** | **0.0310** |     **520 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-1/123456789**         | **411.99 ns** |  **55.784 ns** |  **3.058 ns** | **0.0296** |     **496 B** |
| **DecimalNotationFormatter_Format** | **?**            | **1/123456789**          | **412.03 ns** |  **30.462 ns** |  **1.670 ns** | **0.0291** |     **488 B** |
| **DecimalNotationFormatter_Format** | **?**            | **2/3**                  | **463.44 ns** | **165.532 ns** |  **9.073 ns** | **0.0310** |     **520 B** |
| **DecimalNotationFormatter_Format** | **?**            | **269/200**              | **236.67 ns** |  **17.209 ns** |  **0.943 ns** | **0.0215** |     **360 B** |
| **DecimalNotationFormatter_Format** | **?**            | **5/2**                  | **170.42 ns** |  **32.123 ns** |  **1.761 ns** | **0.0176** |     **296 B** |
| **DecimalNotationFormatter_Format** | **?**            | **8/3**                  | **424.04 ns** |  **30.769 ns** |  **1.687 ns** | **0.0286** |     **480 B** |
| **DecimalNotationFormatter_Format** | **?**            | **88427(...)10656 [31]** | **474.55 ns** |   **8.638 ns** |  **0.473 ns** | **0.0334** |     **560 B** |
| **DecimalNotationFormatter_Format** | **?**            | **42**                   |  **75.83 ns** |   **6.443 ns** |  **0.353 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **?**            | **400/3**                | **382.37 ns** |  **45.464 ns** |  **2.492 ns** | **0.0253** |     **424 B** |
| **DecimalNotationFormatter_Format** | **?**            | **1234567/1000**         | **244.26 ns** | **113.868 ns** |  **6.241 ns** | **0.0224** |     **376 B** |
| **DecimalNotationFormatter_Format** | **?**            | **123456789**            |  **88.14 ns** |  **21.849 ns** |  **1.198 ns** | **0.0114** |     **192 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-123456789**           |  **54.72 ns** |   **1.288 ns** |  **0.071 ns** | **0.0033** |      **56 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-1234567/1000**        | **313.56 ns** |  **83.621 ns** |  **4.584 ns** | **0.0563** |     **944 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-42**                  |  **43.00 ns** |   **1.010 ns** |  **0.055 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-8842(...)10656 [32]** | **323.47 ns** |  **26.861 ns** |  **1.472 ns** | **0.0486** |     **816 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-5/2**                 | **284.14 ns** |  **42.383 ns** |  **2.323 ns** | **0.0429** |     **720 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-2/3**                 | **281.76 ns** |  **16.437 ns** |  **0.901 ns** | **0.0429** |     **720 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-1/123456789**         | **200.56 ns** |  **17.025 ns** |  **0.933 ns** | **0.0358** |     **600 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **1/123456789**          | **187.84 ns** |  **36.961 ns** |  **2.026 ns** | **0.0358** |     **600 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **2/3**                  | **256.15 ns** |  **95.207 ns** |  **5.219 ns** | **0.0372** |     **624 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **269/200**              | **254.39 ns** |   **7.090 ns** |  **0.389 ns** | **0.0372** |     **624 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **5/2**                  | **267.02 ns** |  **90.310 ns** |  **4.950 ns** | **0.0372** |     **624 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **8/3**                  | **249.87 ns** |  **47.239 ns** |  **2.589 ns** | **0.0372** |     **624 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **88427(...)10656 [31]** | **285.54 ns** |  **76.893 ns** |  **4.215 ns** | **0.0429** |     **720 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **42**                   |  **42.50 ns** |   **3.065 ns** |  **0.168 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **400/3**                | **264.48 ns** |  **20.514 ns** |  **1.124 ns** | **0.0443** |     **744 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **1234567/1000**         | **287.51 ns** | **123.000 ns** |  **6.742 ns** | **0.0496** |     **832 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **123456789**            |  **54.84 ns** |   **0.941 ns** |  **0.052 ns** | **0.0033** |      **56 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-123456789**           |  **54.38 ns** |   **4.038 ns** |  **0.221 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-1234567/1000**        | **219.94 ns** |  **22.102 ns** |  **1.211 ns** | **0.0167** |     **280 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-42**                  |  **49.76 ns** |   **1.986 ns** |  **0.109 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-8842(...)10656 [32]** | **225.05 ns** |  **31.339 ns** |  **1.718 ns** | **0.0243** |     **408 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-5/2**                 | **169.36 ns** |  **20.196 ns** |  **1.107 ns** | **0.0167** |     **280 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-2/3**                 | **198.26 ns** |   **7.770 ns** |  **0.426 ns** | **0.0167** |     **280 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-1/123456789**         | **222.06 ns** |  **15.082 ns** |  **0.827 ns** | **0.0205** |     **344 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **1/123456789**          | **215.10 ns** |  **41.886 ns** |  **2.296 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **2/3**                  | **209.32 ns** |  **85.405 ns** |  **4.681 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **269/200**              | **185.97 ns** |  **19.779 ns** |  **1.084 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **5/2**                  | **170.66 ns** |   **6.147 ns** |  **0.337 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **8/3**                  | **172.02 ns** |  **25.187 ns** |  **1.381 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **88427(...)10656 [31]** | **233.46 ns** |   **8.989 ns** |  **0.493 ns** | **0.0238** |     **400 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **42**                   |  **49.66 ns** |   **4.114 ns** |  **0.226 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **400/3**                | **224.17 ns** |  **19.679 ns** |  **1.079 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **1234567/1000**         | **232.77 ns** |  **44.926 ns** |  **2.463 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **123456789**            |  **57.15 ns** |   **5.416 ns** |  **0.297 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-123456789**           |  **48.80 ns** |   **4.385 ns** |  **0.240 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-1234567/1000**        | **162.94 ns** |  **18.023 ns** |  **0.988 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-42**                  |  **38.44 ns** |   **1.810 ns** |  **0.099 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-8842(...)10656 [32]** | **176.47 ns** |  **27.889 ns** |  **1.529 ns** | **0.0153** |     **256 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-5/2**                 | **138.63 ns** |   **6.813 ns** |  **0.373 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-2/3**                 | **142.36 ns** |   **3.841 ns** |  **0.211 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-1/123456789**         |  **89.67 ns** |  **11.494 ns** |  **0.630 ns** | **0.0100** |     **168 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **1/123456789**          |  **88.59 ns** |  **22.389 ns** |  **1.227 ns** | **0.0100** |     **168 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **2/3**                  | **151.57 ns** |  **37.644 ns** |  **2.063 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **269/200**              | **135.22 ns** |  **12.349 ns** |  **0.677 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **5/2**                  | **120.68 ns** |  **10.839 ns** |  **0.594 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **8/3**                  | **134.99 ns** |  **25.658 ns** |  **1.406 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **88427(...)10656 [31]** | **168.01 ns** |  **19.464 ns** |  **1.067 ns** | **0.0153** |     **256 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **42**                   |  **37.47 ns** |   **1.714 ns** |  **0.094 ns** | **0.0019** |      **32 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **400/3**                | **137.96 ns** |   **3.202 ns** |  **0.175 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **1234567/1000**         | **144.66 ns** |  **20.125 ns** |  **1.103 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **123456789**            |  **48.06 ns** |   **2.679 ns** |  **0.147 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-123456789**           | **162.19 ns** |   **6.694 ns** |  **0.367 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-1234567/1000**        | **177.41 ns** |  **10.699 ns** |  **0.586 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-42**                  |  **55.97 ns** |   **0.665 ns** |  **0.036 ns** | **0.0072** |     **120 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-8842(...)10656 [32]** | **196.17 ns** | **233.152 ns** | **12.780 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-5/2**                 | **138.92 ns** |  **41.567 ns** |  **2.278 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-2/3**                 | **144.13 ns** |  **18.728 ns** |  **1.027 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-1/123456789**         | **212.49 ns** |  **54.198 ns** |  **2.971 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **1/123456789**          | **199.55 ns** |   **7.354 ns** |  **0.403 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **2/3**                  | **145.22 ns** |   **4.605 ns** |  **0.252 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **269/200**              | **127.90 ns** |   **8.792 ns** |  **0.482 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **5/2**                  | **130.50 ns** |   **9.359 ns** |  **0.513 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **8/3**                  | **128.60 ns** |  **13.217 ns** |  **0.724 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **88427(...)10656 [31]** | **176.57 ns** |   **2.938 ns** |  **0.161 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **42**                   |  **49.63 ns** |   **1.725 ns** |  **0.095 ns** | **0.0072** |     **120 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **400/3**                | **154.13 ns** |  **10.637 ns** |  **0.583 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **1234567/1000**         | **153.21 ns** |  **14.671 ns** |  **0.804 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **123456789**            | **152.96 ns** |   **2.340 ns** |  **0.128 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-123456789**           |  **49.77 ns** |   **0.404 ns** |  **0.022 ns** | **0.0033** |      **56 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-1234567/1000**        | **187.96 ns** |  **24.466 ns** |  **1.341 ns** | **0.0210** |     **352 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-42**                  |  **39.37 ns** |  **11.257 ns** |  **0.617 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-8842(...)10656 [32]** | **181.17 ns** |  **48.979 ns** |  **2.685 ns** | **0.0143** |     **240 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-5/2**                 | **141.43 ns** |  **94.998 ns** |  **5.207 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-2/3**                 | **154.57 ns** |   **7.761 ns** |  **0.425 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-1/123456789**         |  **89.67 ns** |   **3.456 ns** |  **0.189 ns** | **0.0072** |     **120 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **1/123456789**          |  **81.20 ns** |   **3.065 ns** |  **0.168 ns** | **0.0072** |     **120 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **2/3**                  | **124.16 ns** |   **7.411 ns** |  **0.406 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **269/200**              | **124.89 ns** |  **10.539 ns** |  **0.578 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **5/2**                  | **117.11 ns** |  **17.815 ns** |  **0.977 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **8/3**                  | **122.44 ns** |   **5.115 ns** |  **0.280 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **88427(...)10656 [31]** | **157.68 ns** |  **15.557 ns** |  **0.853 ns** | **0.0143** |     **240 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **42**                   |  **36.67 ns** |   **2.432 ns** |  **0.133 ns** | **0.0019** |      **32 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **400/3**                | **148.28 ns** | **109.215 ns** |  **5.986 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **1234567/1000**         | **146.16 ns** |  **16.200 ns** |  **0.888 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **123456789**            |  **50.11 ns** |   **4.595 ns** |  **0.252 ns** | **0.0033** |      **56 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-123456789**           |  **60.17 ns** |   **8.704 ns** |  **0.477 ns** | **0.0038** |      **64 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-1234567/1000**        | **345.22 ns** |  **27.491 ns** |  **1.507 ns** | **0.0505** |     **848 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-42**                  |  **48.97 ns** |   **1.355 ns** |  **0.074 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-8842(...)10656 [32]** | **483.66 ns** |  **29.861 ns** |  **1.637 ns** | **0.0610** |    **1024 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-5/2**                 | **281.11 ns** |  **11.803 ns** |  **0.647 ns** | **0.0520** |     **872 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-2/3**                 | **323.51 ns** |  **49.659 ns** |  **2.722 ns** | **0.0434** |     **728 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-1/123456789**         | **260.45 ns** |  **35.125 ns** |  **1.925 ns** | **0.0362** |     **608 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **1/123456789**          | **227.34 ns** |  **26.913 ns** |  **1.475 ns** | **0.0362** |     **608 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **2/3**                  | **298.95 ns** | **142.649 ns** |  **7.819 ns** | **0.0434** |     **728 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **269/200**              | **306.94 ns** |  **90.501 ns** |  **4.961 ns** | **0.0434** |     **728 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **5/2**                  | **241.98 ns** |  **40.872 ns** |  **2.240 ns** | **0.0458** |     **768 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **8/3**                  | **303.62 ns** |  **45.807 ns** |  **2.511 ns** | **0.0434** |     **728 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **88427(...)10656 [31]** | **468.43 ns** | **129.322 ns** |  **7.089 ns** | **0.0548** |     **920 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **42**                   |  **49.56 ns** |   **2.053 ns** |  **0.113 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **400/3**                | **305.50 ns** |  **53.570 ns** |  **2.936 ns** | **0.0443** |     **744 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **1234567/1000**         | **320.55 ns** |  **79.589 ns** |  **4.363 ns** | **0.0443** |     **744 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **123456789**            |  **63.92 ns** |  **34.930 ns** |  **1.915 ns** | **0.0038** |      **64 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-123456789**           | **194.60 ns** |  **25.902 ns** |  **1.420 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-1234567/1000**        | **168.42 ns** |  **10.610 ns** |  **0.582 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-42**                  |  **87.40 ns** |   **1.224 ns** |  **0.067 ns** | **0.0091** |     **152 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-8842(...)10656 [32]** | **202.71 ns** |   **9.259 ns** |  **0.508 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-5/2**                 | **135.55 ns** |   **5.702 ns** |  **0.313 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-2/3**                 | **144.67 ns** |   **0.464 ns** |  **0.025 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-1/123456789**         | **177.25 ns** |   **4.392 ns** |  **0.241 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **1/123456789**          | **176.29 ns** |  **18.434 ns** |  **1.010 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **2/3**                  | **132.90 ns** |  **17.180 ns** |  **0.942 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **269/200**              | **140.13 ns** |   **9.010 ns** |  **0.494 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **5/2**                  | **128.59 ns** |  **66.129 ns** |  **3.625 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **8/3**                  | **141.20 ns** |  **10.003 ns** |  **0.548 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **88427(...)10656 [31]** | **186.49 ns** |  **16.341 ns** |  **0.896 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **42**                   |  **79.01 ns** |  **10.461 ns** |  **0.573 ns** | **0.0091** |     **152 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **400/3**                | **157.02 ns** |   **6.778 ns** |  **0.372 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **1234567/1000**         | **161.18 ns** |   **7.257 ns** |  **0.398 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **123456789**            | **185.58 ns** |   **0.395 ns** |  **0.022 ns** | **0.0200** |     **336 B** |
