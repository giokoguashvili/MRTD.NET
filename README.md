# SmartCard API

[![Build status](https://ci.appveyor.com/api/projects/status/ki0q2h4ekc8wfttv?svg=true)](https://ci.appveyor.com/project/kogoia/smartcardsamples)

```cs
var dg1Content = await new SmartCardContent(
                          new MRZInfo(
                              "29GJ27813",
                              new DateTime(1998, 08, 14),
                              new DateTime(2022, 12, 22)
                          )
                      ).Content();
Console.WriteLine(dg1Content.MRZ.DocumentNumber)                          
```
