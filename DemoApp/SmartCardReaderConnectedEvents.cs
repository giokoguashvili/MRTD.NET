using System;
using System.Linq;
using System.Management;
using PCSC;

namespace DemoApp
{
    public class SmartCardReaderConnectEvents : IObservable<ISCardReader>
    {
        private IObserver<ISCardReader> _observer;
        private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var cardContext = ContextFactory.Instance.Establish(SCardScope.System);
            //var readerName = "ACS CCID USB Reader 0";
            cardContext
                .GetReaders()
                .All((readerName) =>
                {
                    Console.WriteLine(readerName);
                    var reader = new SCardReader(cardContext);
                    var cardError = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
                    if (cardError == SCardError.Success)
                    {
                        SCardProtocol proto;
                        SCardState state;
                        byte[] atr;

                        string[] readerNames;
                        var sc = reader.Status(
                            out readerNames,
                            out state,
                            out proto,
                            out atr
                        );

                        sc = reader.BeginTransaction();
                        if (sc != SCardError.Success)
                        {
                            Console.WriteLine("Could not begin transaction.");
                            Console.ReadKey();
                            return false;
                        }

                        Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
                        Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));
                        _observer.OnNext(reader);
                    }

                    return true;
                });
        }
        public IDisposable Subscribe(IObserver<ISCardReader> observer)
        {
            _observer = observer;  
            //Insert
            WqlEventQuery q_creation = new WqlEventQuery();
            q_creation.EventClassName = "__InstanceCreationEvent";
            q_creation.WithinInterval = new TimeSpan(0, 0, 2);    //How often do you want to check it? 2Sec.
            q_creation.Condition = @"TargetInstance ISA 'Win32_USBControllerDevice'";
            ManagementEventWatcher mwe_creation = new ManagementEventWatcher(q_creation);
            mwe_creation.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            mwe_creation.Start(); // Start listen for events
            return mwe_creation;
        }
    }
}

