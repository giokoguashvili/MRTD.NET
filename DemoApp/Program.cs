using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using PCSC;
using SmartCardApi.DataGroups;
using SmartCardApi.Infrastructure;
using SmartCardApi.MRZ;
using SmartCardApi.SmartCard;
using SmartCardApi.SmartCard.Reader;
using System.Management;
using System.Reactive.Linq;
using PCSC.Reactive;
using PCSC.Reactive.Events;

namespace DemoApp
{
   
    class Program
    {

      
        public static void Main()
        {
            new SmartCardReaderConnectedEvents()
                .SelectMany(reader => new SmartCardInsertedEvents(reader))
                .Subscribe(new InsertedCardHandledEvent());


            Console.ReadKey();
        
        }
    }
}
