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
using DemoApp.Infrastructure;
using PCSC.Reactive;
using PCSC.Reactive.Events;
using SmartCardApi.Commands;

namespace DemoApp
{
   
    class Program
    {
        static void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var gip = 5;
            //string DriveName = e.NewEvent.Properties["DriveName"].Value.ToString();
            //var Type = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));
            Console.WriteLine("{0}", (gip++).ToString());
        }
        public static void Main()
        {
            foreach (var item in new Readers())
            {
                Console.WriteLine(item);
            }
    
            //new HandledSmartCardInsertEvents(
            //    new SmartCardInsertEventsSource(
            //        mrzInfo,
            //        new SmartCardReaderConnectEventsSource()
            //    )
            //).Handle();

            //var mrzInfo = new MRZInfo("15IC69034", new DateTime(1996,11,26), new DateTime(2026, 06, 11)); //"496112612606118" Bagdavadze
            //var mrzInfo = "13ID37063295110732402055";     // + Shako
            //var mrzInfo = "13IB90080296040761709252";   // + guka 
            //var mrzInfo = "13ID40308689022472402103";     // + Giorgio
            //"12IB34415792061602210089" K




            //var mwe_creation = new ManagementEventWatcher(new WqlEventQuery()
            //{
            //    EventClassName = "__InstanceCreationEvent",
            //    WithinInterval = new TimeSpan(0, 0, 2), //How often do you want to check it? 2Sec.
            //    Condition = @"TargetInstance ISA 'Win32_USBControllerDevice'"
            //});
            //mwe_creation.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            //mwe_creation.Start(); // Start listen for events

            //new USBDevices().DeviceConnectEvent += new EventArrivedEventHandler(watcher_EventArrived);

            //new SmartCardReaderConnectEvents()
            //    .Source()
            //    .Subscribe(r => r.Transmit(new SelectMRTDApplicationCommandApdu()));


            var mrzInfo = new MRZInfo(
                                "12IB34415",
                                new DateTime(1992, 06, 16),
                                new DateTime(2022, 10, 08)
                          );

            var dgsContent = new SmartCardContent(mrzInfo)
                                .Content()
                                .Result;
            Console.WriteLine(dgsContent.Dg1Content.MRZ.DocumentNumber);
            Console.ReadKey();
        }
    }
}
