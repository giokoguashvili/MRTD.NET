//using System;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices;
//using PCSC;
//using SmartCardApi.DataGroups;
//using SmartCardApi.Infrastructure;
//using SmartCardApi.MRZ;
//using SmartCardApi.SmartCard;
//using SmartCardApi.SmartCard.Reader;
//using System.Management;
//using System.Reactive.Linq;
//using PCSC.Reactive;
//using PCSC.Reactive.Events;

//namespace DemoApp
//{
//    public enum EventType
//    {
//        Inserted,
//        Removed
//    }
//    public class WMIReceiveEvent
//    {
//        public WMIReceiveEvent()
//        {
//            try
//            {
//                WqlEventQuery query = new WqlEventQuery(
//                    "SELECT * FROM __InstanceCreationEvent WITHIN 1");

//                ManagementEventWatcher watcher = new ManagementEventWatcher(query);
//                Console.WriteLine("Waiting for an event...");

//                watcher.EventArrived +=
//                    new EventArrivedEventHandler(
//                    HandleEvent);

//                // Start listening for events
//                watcher.Start();

//                //// Do something while waiting for events
//                //System.Threading.Thread.Sleep(1000);

//                //// Stop listening for events
//                //watcher.Stop();
//            }
//            catch (ManagementException err)
//            {
//                Console.WriteLine("An error occurred while trying to receive an event: " + err.Message);
//            }
//        }

//        private void HandleEvent(object sender,
//            EventArrivedEventArgs e)
//        {
//            Console.WriteLine("__InstanceCreationEvent event occurred.");
//        }

//    }

//    class Program
//    {

//        static void watcher_EventArrived(object sender, EventArrivedEventArgs e)
//        {
//            var gip = 5;
//            //string DriveName = e.NewEvent.Properties["DriveName"].Value.ToString();
//            //var Type = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));
//            Console.WriteLine("{0}", (gip++).ToString());
//        }
//        static ManagementEventWatcher mwe_creation = null;

//        public static void Main()
//        {
//            Console.WriteLine("Listen device attached/detached events. Press any key to stop.");

//            //var factory = DeviceMonitorFactory.Instance;

//            //var subscription = factory
//            //    .CreateObservable(SCardScope.System)
//            //    .Subscribe(OnNext, OnError);


//            var monitorFactory2 = MonitorFactory.Instance;

//            var subscription2 = monitorFactory2
//                .CreateObservable(SCardScope.System, GetReaders())
//                ;
//            //.Subscribe(OnNext1, OnError1);

//            Console.ReadKey();
//            // subscription.Dispose();
//        }

//        private static string[] GetReaders()
//        {
//            var contextFactory = ContextFactory.Instance;
//            using (var ctx = contextFactory.Establish(SCardScope.System))
//            {
//                return ctx.GetReaders();
//            }
//        }

//        private static void OnError(Exception exception)
//        {
//            Console.WriteLine("ERROR: {0}", exception.Message);
//        }

//        private static void OnError1(Exception exception)
//        {
//            Console.WriteLine("ERROR: {0}", exception.Message);
//        }

//        private static void OnNext1(MonitorEvent e)
//        {
//            Console.WriteLine($"Event type {e.GetType()}, reader: {e.ReaderName}");
//            var cardContext = ContextFactory.Instance.Establish(SCardScope.System);
//            var readerName = e.ReaderName;
//            var readerNames = cardContext.GetReaders();

//            using (var reader = new SCardReader(cardContext))
//            {
//                var cardError = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
//                if (cardError == SCardError.Success)
//                {
//                    SCardProtocol proto;
//                    SCardState state;
//                    byte[] atr;

//                    var sc = reader.Status(
//                        out readerNames,
//                        out state,
//                        out proto,
//                        out atr
//                    );

//                    sc = reader.BeginTransaction();
//                    if (sc != SCardError.Success)
//                    {
//                        Console.WriteLine("Could not begin transaction.");
//                        Console.ReadKey();
//                        return;
//                    }

//                    Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
//                    Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));

//                    var mrzInfo = new MRZInfo(
//                        "12IB34415",
//                        new DateTime(1992, 06, 16),
//                        new DateTime(2022, 10, 08)
//                    ); //"12IB34415792061602210089" K

//                    //var mrzInfo = new MRZInfo("15IC69034", new DateTime(1996,11,26), new DateTime(2026, 06, 11)); //"496112612606118" Bagdavadze
//                    //var mrzInfo = "13ID37063295110732402055";     // + Shako
//                    //var mrzInfo = "13IB90080296040761709252";   // + guka 
//                    //var mrzInfo = "13ID40308689022472402103";     // + Giorgio

//                    var smartCard = new SmartCard(
//                        new BacReader(
//                            new SecuredReader(
//                                mrzInfo,
//                                new WrReader(
//                                    new LogedReader(
//                                        reader
//                                    )
//                                )
//                            )
//                        )
//                    );

//                    var dg1Content = smartCard.DG1().Content();
//                    var dg2Content = smartCard.DG2().Content();
//                    var dg7Content = smartCard.DG7().Content();
//                    var dg11Content = smartCard.DG11().Content();
//                    var dg12Content = smartCard.DG12().Content();

//                    reader.EndTransaction(SCardReaderDisposition.Leave);
//                    reader.Disconnect(SCardReaderDisposition.Reset);

//                    //Console.ReadKey();
//                }
//                else
//                {
//                    Console.WriteLine("Error message: {0}\n", SCardHelper.StringifyError(cardError));
//                }
//            }

//        }

//        private static void OnNext(DeviceMonitorEvent ev)
//        {

//            Console.WriteLine($"Event type {ev.GetType()}, (readers: {string.Join(", ", ev.Readers)})");

//        }

//        //static void Main(string[] args)
//        //{
//        //    //var drives = DriveInfo.GetDrives()
//        //    //    .Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
//        //    //WMIReceiveEvent receiveEvent = new WMIReceiveEvent();
//        //    //Console.ReadKey();

//        //    //Insert
//        //    WqlEventQuery q_creation = new WqlEventQuery();
//        //    q_creation.EventClassName = "__InstanceCreationEvent";
//        //    q_creation.WithinInterval = new TimeSpan(0, 0, 2);    //How often do you want to check it? 2Sec.
//        //    q_creation.Condition = @"TargetInstance ISA 'Win32_USBControllerDevice'";
//        //    mwe_creation = new ManagementEventWatcher(q_creation);
//        //    mwe_creation.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
//        //    mwe_creation.Start(); // Start listen for events


//        //    //ManagementEventWatcher watcher = new ManagementEventWatcher();
//        //    //WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 or EventType = 3");
//        //    //watcher.EventArrived += (s, e) =>
//        //    //{
//        //    //    string DriveName = e.NewEvent.Properties["DriveName"].Value.ToString();
//        //    //    var Type = (EventType)(Convert.ToInt16(e.NewEvent.Properties["EventType"].Value));
//        //    //};


//        //    //ManagementEventWatcher w = null;
//        //    //WqlEventQuery q;
//        //    //ManagementScope scope = new ManagementScope("root\\CIMV2");
//        //    //scope.Options.EnablePrivileges = true;
//        //    //    q = new WqlEventQuery();
//        //    //    q.EventClassName = "__InstanceCreationEvent";
//        //    //    q.WithinInterval = new TimeSpan(0, 0, 3);
//        //    //    q.Condition = @"TargetInstance ISA 'Win32_USBHub'";
//        //    //    w = new ManagementEventWatcher(scope, q);
//        //    //    w.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
//        //    //    w.Start();


//        //    //    ManagementEventWatcher watcher = new ManagementEventWatcher();
//        //    //WqlEventQuery query = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WHERE EventType = 2");
//        //    //watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
//        //    //watcher.Query = query;
//        //    //watcher.Start();
//        //    //watcher.WaitForNextEvent();

//        //    //var smartCard = new SmartCardFactory(
//        //    //    new MRZInfo(
//        //    //        "12IB34415",
//        //    //        new DateTime(1992, 06, 16),
//        //    //        new DateTime(2022, 10, 08)
//        //    //    )
//        //    //).SmartCard();

//        //    //var dg1Content = smartCard.DG1().Content();
//        //    //var gio = 5;
//        //    //var contextFactory2 = ContextFactory.Instance;
//        //    //var context = contextFactory2.Establish(SCardScope.System);


//        //    //var readerNames = context.GetReaders();
//        //    //foreach (var readerName in readerNames)
//        //    //{
//        //    //    Console.WriteLine(readerName);
//        //    //}


//        //    var contextFactory = ContextFactory.Instance;
//        //    SCardMonitor monitor = new SCardMonitor(contextFactory, SCardScope.System);
//        //    monitor.CardInserted += new CardInsertedEvent(CardInsertEventHandler);

//        //    monitor.Start("ACS CCID USB Reader 0");
//        //    //monitor.Start("OMNIKEY CardMan 5x21-CL 0");

//        //    Console.ReadKey();
//        //}


//        static void CardInsertEventHandler(object sender, CardStatusEventArgs e)
//        {

//            var cardContext = ContextFactory.Instance.Establish(SCardScope.System);
//            var readerName = e.ReaderName;
//            var readerNames = cardContext.GetReaders();

//            using (var reader = new SCardReader(cardContext))
//            {
//                var cardError = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
//                if (cardError == SCardError.Success)
//                {
//                    SCardProtocol proto;
//                    SCardState state;
//                    byte[] atr;

//                    var sc = reader.Status(
//                                    out readerNames,
//                                    out state,
//                                    out proto,
//                                    out atr
//                                );

//                    sc = reader.BeginTransaction();
//                    if (sc != SCardError.Success)
//                    {
//                        Console.WriteLine("Could not begin transaction.");
//                        Console.ReadKey();
//                        return;
//                    }

//                    Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
//                    Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));

//                    var mrzInfo = new MRZInfo(
//                                        "12IB34415",
//                                        new DateTime(1992, 06, 16),
//                                        new DateTime(2022, 10, 08)
//                                  ); //"12IB34415792061602210089" K

//                    //var mrzInfo = new MRZInfo("15IC69034", new DateTime(1996,11,26), new DateTime(2026, 06, 11)); //"496112612606118" Bagdavadze
//                    //var mrzInfo = "13ID37063295110732402055";     // + Shako
//                    //var mrzInfo = "13IB90080296040761709252";   // + guka 
//                    //var mrzInfo = "13ID40308689022472402103";     // + Giorgio

//                    var smartCard = new SmartCard(
//                                        new BacReader(
//                                            new SecuredReader(
//                                                mrzInfo,
//                                                new WrReader(
//                                                    new LogedReader(
//                                                        reader
//                                                    )
//                                                )
//                                            )
//                                        )
//                                    );

//                    var dg1Content = smartCard.DG1().Content();
//                    var dg2Content = smartCard.DG2().Content();
//                    var dg7Content = smartCard.DG7().Content();
//                    var dg11Content = smartCard.DG11().Content();
//                    var dg12Content = smartCard.DG12().Content();

//                    reader.EndTransaction(SCardReaderDisposition.Leave);
//                    reader.Disconnect(SCardReaderDisposition.Reset);

//                    Console.ReadKey();
//                }
//                else
//                {
//                    Console.WriteLine("Error message: {0}\n", SCardHelper.StringifyError(cardError));
//                }
//            }
//        }
//    }
//}
