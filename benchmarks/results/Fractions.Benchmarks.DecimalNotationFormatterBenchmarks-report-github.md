```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5487/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]   : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                          | StringFormat | fraction             | Mean        | Error      | StdDev    | Gen0   | Allocated |
|-------------------------------- |------------- |--------------------- |------------:|-----------:|----------:|-------:|----------:|
| **DecimalNotationFormatter_Format** | **?**            | **-123456789**           |   **131.01 ns** |   **5.684 ns** |  **0.312 ns** | **0.0119** |     **200 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-1234567/1000**        |   **366.10 ns** |   **4.932 ns** |  **0.270 ns** | **0.0186** |     **312 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-42**                  |   **122.60 ns** |   **5.848 ns** |  **0.321 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-8842(...)10656 [32]** | **1,057.26 ns** | **115.175 ns** |  **6.313 ns** | **0.0839** |    **1432 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-5/2**                 |   **305.47 ns** | **125.550 ns** |  **6.882 ns** | **0.0196** |     **328 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-2/3**                 |   **980.54 ns** |  **80.837 ns** |  **4.431 ns** | **0.0839** |    **1416 B** |
| **DecimalNotationFormatter_Format** | **?**            | **-1/123456789**         | **1,079.90 ns** |  **65.257 ns** |  **3.577 ns** | **0.0877** |    **1488 B** |
| **DecimalNotationFormatter_Format** | **?**            | **1/123456789**          | **1,078.79 ns** |  **98.650 ns** |  **5.407 ns** | **0.0877** |    **1480 B** |
| **DecimalNotationFormatter_Format** | **?**            | **2/3**                  |   **998.63 ns** |  **68.879 ns** |  **3.776 ns** | **0.0839** |    **1416 B** |
| **DecimalNotationFormatter_Format** | **?**            | **269/200**              |   **348.99 ns** |   **6.245 ns** |  **0.342 ns** | **0.0196** |     **328 B** |
| **DecimalNotationFormatter_Format** | **?**            | **5/2**                  |   **292.18 ns** |  **70.597 ns** |  **3.870 ns** | **0.0196** |     **328 B** |
| **DecimalNotationFormatter_Format** | **?**            | **8/3**                  |   **964.03 ns** |  **36.423 ns** |  **1.996 ns** | **0.0801** |    **1344 B** |
| **DecimalNotationFormatter_Format** | **?**            | **88427(...)10656 [31]** | **1,070.70 ns** |  **50.809 ns** |  **2.785 ns** | **0.0839** |    **1424 B** |
| **DecimalNotationFormatter_Format** | **?**            | **42**                   |   **109.35 ns** |   **9.226 ns** |  **0.506 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **?**            | **400/3**                |   **895.01 ns** |  **32.336 ns** |  **1.772 ns** | **0.0725** |    **1224 B** |
| **DecimalNotationFormatter_Format** | **?**            | **1234567/1000**         |   **374.61 ns** |  **30.594 ns** |  **1.677 ns** | **0.0186** |     **312 B** |
| **DecimalNotationFormatter_Format** | **?**            | **123456789**            |   **123.22 ns** |   **7.398 ns** |  **0.405 ns** | **0.0114** |     **192 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-123456789**           |    **55.36 ns** |   **2.348 ns** |  **0.129 ns** | **0.0033** |      **56 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-1234567/1000**        |   **396.82 ns** | **104.399 ns** |  **5.722 ns** | **0.0563** |     **944 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-42**                  |    **43.44 ns** |   **0.173 ns** |  **0.009 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-8842(...)10656 [32]** |   **432.23 ns** | **138.025 ns** |  **7.566 ns** | **0.0486** |     **816 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-5/2**                 |   **362.86 ns** |  **38.002 ns** |  **2.083 ns** | **0.0429** |     **720 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-2/3**                 |   **379.17 ns** | **104.294 ns** |  **5.717 ns** | **0.0429** |     **720 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **-1/123456789**         |   **264.53 ns** |  **20.854 ns** |  **1.143 ns** | **0.0358** |     **600 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **1/123456789**          |   **235.09 ns** |  **32.515 ns** |  **1.782 ns** | **0.0358** |     **600 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **2/3**                  |   **323.43 ns** |  **40.934 ns** |  **2.244 ns** | **0.0372** |     **624 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **269/200**              |   **364.19 ns** |  **60.115 ns** |  **3.295 ns** | **0.0372** |     **624 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **5/2**                  |   **303.26 ns** |  **20.049 ns** |  **1.099 ns** | **0.0372** |     **624 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **8/3**                  |   **332.74 ns** |  **30.653 ns** |  **1.680 ns** | **0.0372** |     **624 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **88427(...)10656 [31]** |   **394.37 ns** |  **41.960 ns** |  **2.300 ns** | **0.0429** |     **720 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **42**                   |    **42.20 ns** |   **1.257 ns** |  **0.069 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **400/3**                |   **337.15 ns** |  **22.895 ns** |  **1.255 ns** | **0.0443** |     **744 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **1234567/1000**         |   **373.88 ns** |  **63.758 ns** |  **3.495 ns** | **0.0496** |     **832 B** |
| **DecimalNotationFormatter_Format** | **C2**           | **123456789**            |    **55.31 ns** |   **1.338 ns** |  **0.073 ns** | **0.0033** |      **56 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-123456789**           |    **54.42 ns** |   **1.738 ns** |  **0.095 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-1234567/1000**        |   **337.93 ns** |   **9.121 ns** |  **0.500 ns** | **0.0167** |     **280 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-42**                  |    **49.44 ns** |   **0.797 ns** |  **0.044 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-8842(...)10656 [32]** |   **353.29 ns** |   **8.844 ns** |  **0.485 ns** | **0.0243** |     **408 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-5/2**                 |   **237.48 ns** |  **16.856 ns** |  **0.924 ns** | **0.0167** |     **280 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-2/3**                 |   **276.13 ns** |  **16.687 ns** |  **0.915 ns** | **0.0167** |     **280 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **-1/123456789**         |   **332.45 ns** | **138.410 ns** |  **7.587 ns** | **0.0205** |     **344 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **1/123456789**          |   **319.71 ns** |  **20.279 ns** |  **1.112 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **2/3**                  |   **266.50 ns** |   **6.676 ns** |  **0.366 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **269/200**              |   **274.82 ns** |   **3.720 ns** |  **0.204 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **5/2**                  |   **232.59 ns** |   **9.285 ns** |  **0.509 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **8/3**                  |   **265.72 ns** | **116.450 ns** |  **6.383 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **88427(...)10656 [31]** |   **318.27 ns** |  **41.813 ns** |  **2.292 ns** | **0.0238** |     **400 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **42**                   |    **49.21 ns** |   **1.853 ns** |  **0.102 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **400/3**                |   **317.85 ns** | **104.756 ns** |  **5.742 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **1234567/1000**         |   **330.23 ns** |  **95.949 ns** |  **5.259 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **E2**           | **123456789**            |    **55.20 ns** |   **1.275 ns** |  **0.070 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-123456789**           |    **51.01 ns** |   **1.556 ns** |  **0.085 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-1234567/1000**        |   **229.93 ns** |  **17.415 ns** |  **0.955 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-42**                  |    **43.58 ns** |   **0.544 ns** |  **0.030 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-8842(...)10656 [32]** |   **277.10 ns** |  **13.222 ns** |  **0.725 ns** | **0.0153** |     **256 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-5/2**                 |   **202.79 ns** |  **58.756 ns** |  **3.221 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-2/3**                 |   **220.37 ns** |  **17.221 ns** |  **0.944 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **-1/123456789**         |   **140.52 ns** |   **9.601 ns** |  **0.526 ns** | **0.0100** |     **168 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **1/123456789**          |   **140.07 ns** |   **4.678 ns** |  **0.256 ns** | **0.0100** |     **168 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **2/3**                  |   **208.65 ns** |   **5.334 ns** |  **0.292 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **269/200**              |   **229.26 ns** |   **8.526 ns** |  **0.467 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **5/2**                  |   **190.02 ns** |  **22.017 ns** |  **1.207 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **8/3**                  |   **225.44 ns** |   **9.124 ns** |  **0.500 ns** | **0.0095** |     **160 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **88427(...)10656 [31]** |   **260.09 ns** |   **4.667 ns** |  **0.256 ns** | **0.0153** |     **256 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **42**                   |    **38.59 ns** |   **0.411 ns** |  **0.023 ns** | **0.0019** |      **32 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **400/3**                |   **214.37 ns** |   **2.927 ns** |  **0.160 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **1234567/1000**         |   **215.92 ns** |  **26.320 ns** |  **1.443 ns** | **0.0105** |     **176 B** |
| **DecimalNotationFormatter_Format** | **F2**           | **123456789**            |    **49.25 ns** |   **1.742 ns** |  **0.095 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-123456789**           |   **265.85 ns** | **239.843 ns** | **13.147 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-1234567/1000**        |   **249.89 ns** |  **20.840 ns** |  **1.142 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-42**                  |    **89.49 ns** |   **4.127 ns** |  **0.226 ns** | **0.0072** |     **120 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-8842(...)10656 [32]** |   **204.10 ns** |  **23.036 ns** |  **1.263 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-5/2**                 |   **185.54 ns** |  **15.193 ns** |  **0.833 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-2/3**                 |   **208.89 ns** |  **18.699 ns** |  **1.025 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **-1/123456789**         |   **277.63 ns** |  **10.567 ns** |  **0.579 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **1/123456789**          |   **281.88 ns** |  **15.884 ns** |  **0.871 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **2/3**                  |   **198.98 ns** |   **4.883 ns** |  **0.268 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **269/200**              |   **158.93 ns** |   **8.228 ns** |  **0.451 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **5/2**                  |   **190.08 ns** |   **6.030 ns** |  **0.331 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **8/3**                  |   **161.58 ns** |   **8.557 ns** |  **0.469 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **88427(...)10656 [31]** |   **196.41 ns** |   **7.453 ns** |  **0.409 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **42**                   |    **81.31 ns** |   **2.534 ns** |  **0.139 ns** | **0.0072** |     **120 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **400/3**                |   **208.26 ns** |  **20.555 ns** |  **1.127 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **1234567/1000**         |   **239.20 ns** |   **2.847 ns** |  **0.156 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **G2**           | **123456789**            |   **248.57 ns** |  **18.243 ns** |  **1.000 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-123456789**           |    **51.03 ns** |   **4.612 ns** |  **0.253 ns** | **0.0033** |      **56 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-1234567/1000**        |   **256.40 ns** |  **19.828 ns** |  **1.087 ns** | **0.0210** |     **352 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-42**                  |    **38.79 ns** |   **0.841 ns** |  **0.046 ns** | **0.0024** |      **40 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-8842(...)10656 [32]** |   **281.08 ns** |  **17.237 ns** |  **0.945 ns** | **0.0143** |     **240 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-5/2**                 |   **202.09 ns** |   **2.062 ns** |  **0.113 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-2/3**                 |   **241.78 ns** |  **11.280 ns** |  **0.618 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **-1/123456789**         |   **140.28 ns** |  **39.985 ns** |  **2.192 ns** | **0.0072** |     **120 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **1/123456789**          |   **129.86 ns** |   **2.581 ns** |  **0.141 ns** | **0.0072** |     **120 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **2/3**                  |   **206.44 ns** |  **20.122 ns** |  **1.103 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **269/200**              |   **231.54 ns** |  **10.540 ns** |  **0.578 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **5/2**                  |   **181.12 ns** |  **17.912 ns** |  **0.982 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **8/3**                  |   **206.27 ns** |  **11.739 ns** |  **0.643 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **88427(...)10656 [31]** |   **254.24 ns** |   **5.667 ns** |  **0.311 ns** | **0.0143** |     **240 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **42**                   |    **37.98 ns** |   **2.376 ns** |  **0.130 ns** | **0.0019** |      **32 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **400/3**                |   **219.51 ns** |   **7.273 ns** |  **0.399 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **1234567/1000**         |   **233.59 ns** |  **16.390 ns** |  **0.898 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **N2**           | **123456789**            |    **48.63 ns** |   **2.018 ns** |  **0.111 ns** | **0.0033** |      **56 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-123456789**           |    **69.71 ns** |   **4.225 ns** |  **0.232 ns** | **0.0038** |      **64 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-1234567/1000**        |   **414.71 ns** |  **28.625 ns** |  **1.569 ns** | **0.0505** |     **848 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-42**                  |    **49.80 ns** |   **2.876 ns** |  **0.158 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-8842(...)10656 [32]** |   **579.05 ns** |   **8.373 ns** |  **0.459 ns** | **0.0610** |    **1024 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-5/2**                 |   **262.92 ns** |  **57.205 ns** |  **3.136 ns** | **0.0520** |     **872 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-2/3**                 |   **389.04 ns** |  **40.562 ns** |  **2.223 ns** | **0.0434** |     **728 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **-1/123456789**         |   **281.21 ns** |  **30.298 ns** |  **1.661 ns** | **0.0362** |     **608 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **1/123456789**          |   **257.58 ns** |  **36.414 ns** |  **1.996 ns** | **0.0362** |     **608 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **2/3**                  |   **384.07 ns** |  **14.171 ns** |  **0.777 ns** | **0.0434** |     **728 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **269/200**              |   **367.82 ns** |  **51.407 ns** |  **2.818 ns** | **0.0434** |     **728 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **5/2**                  |   **249.38 ns** |  **55.945 ns** |  **3.067 ns** | **0.0458** |     **768 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **8/3**                  |   **381.01 ns** |  **46.835 ns** |  **2.567 ns** | **0.0434** |     **728 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **88427(...)10656 [31]** |   **562.57 ns** |  **54.427 ns** |  **2.983 ns** | **0.0544** |     **920 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **42**                   |    **53.67 ns** |   **2.352 ns** |  **0.129 ns** | **0.0029** |      **48 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **400/3**                |   **372.59 ns** |  **16.618 ns** |  **0.911 ns** | **0.0443** |     **744 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **1234567/1000**         |   **412.87 ns** |  **69.892 ns** |  **3.831 ns** | **0.0443** |     **744 B** |
| **DecimalNotationFormatter_Format** | **P2**           | **123456789**            |    **60.60 ns** |   **3.247 ns** |  **0.178 ns** | **0.0038** |      **64 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-123456789**           |   **304.28 ns** | **116.039 ns** |  **6.360 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-1234567/1000**        |   **284.93 ns** |  **32.175 ns** |  **1.764 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-42**                  |   **118.68 ns** |   **9.204 ns** |  **0.505 ns** | **0.0091** |     **152 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-8842(...)10656 [32]** |   **294.29 ns** |  **60.116 ns** |  **3.295 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-5/2**                 |   **205.86 ns** |  **11.680 ns** |  **0.640 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-2/3**                 |   **231.97 ns** |   **5.538 ns** |  **0.304 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **-1/123456789**         |   **298.70 ns** |  **10.639 ns** |  **0.583 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **1/123456789**          |   **301.39 ns** |  **25.047 ns** |  **1.373 ns** | **0.0200** |     **336 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **2/3**                  |   **199.36 ns** |   **9.608 ns** |  **0.527 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **269/200**              |   **244.68 ns** |  **21.509 ns** |  **1.179 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **5/2**                  |   **194.04 ns** |  **18.634 ns** |  **1.021 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **8/3**                  |   **214.99 ns** |  **11.270 ns** |  **0.618 ns** | **0.0086** |     **144 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **88427(...)10656 [31]** |   **292.67 ns** |  **18.790 ns** |  **1.030 ns** | **0.0162** |     **272 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **42**                   |   **114.56 ns** |   **6.714 ns** |  **0.368 ns** | **0.0091** |     **152 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **400/3**                |   **248.63 ns** |   **8.493 ns** |  **0.466 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **1234567/1000**         |   **268.29 ns** |  **41.178 ns** |  **2.257 ns** | **0.0148** |     **248 B** |
| **DecimalNotationFormatter_Format** | **S2**           | **123456789**            |   **295.04 ns** |  **21.082 ns** |  **1.156 ns** | **0.0200** |     **336 B** |
