# SmartCard API

[![Build status](https://ci.appveyor.com/api/projects/status/ki0q2h4ekc8wfttv?svg=true)](https://ci.appveyor.com/project/kogoia/smartcardsamples)
[![Coverage Status](https://coveralls.io/repos/github/kogoia/MRTD.NET/badge.svg)](https://coveralls.io/github/kogoia/MRTD.NET)

```cs
var dg1Content = await new SmartCardContent(
                            new MRZInfo(
                                "29GJ27813",
                                new DateTime(1998, 08, 14),
                                new DateTime(2022, 12, 22)
                            )
                        ).Content();
                        
Console.WriteLine(
            dg1Content.MRZ.DocumentNumber
        );
```
