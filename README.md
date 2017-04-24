# SmartCard API

[![Build status](https://ci.appveyor.com/api/projects/status/ki0q2h4ekc8wfttv?svg=true)](https://ci.appveyor.com/project/kogoia/smartcardsamples)
[![Coverage Status](https://coveralls.io/repos/github/kogoia/MRTD.NET/badge.svg)](https://coveralls.io/github/kogoia/MRTD.NET)
[![Dependency Status](https://www.versioneye.com/user/projects/58e93b1724ef3e004521755f/badge.svg?style=flat-square)](https://www.versioneye.com/user/projects/58e93b1724ef3e004521755f)
[![NuGet](https://img.shields.io/nuget/v/MRTD.NET.svg)](https://www.nuget.org/packages/MRTD.NET)
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
