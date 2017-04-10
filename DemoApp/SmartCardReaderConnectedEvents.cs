using System;
using System.Linq;
using System.Management;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using DemoApp.Infrastructure;
using PCSC;
using SmartCardApi.SmartCard.Reader;

namespace DemoApp
{
    public class SmartCardReaderConnectEvents : ISource<IReader> 
    {
        public IObservable<IReader> Source()
        {
            var cardContext = ContextFactory.Instance.Establish(SCardScope.System);
            var usbDevices = new USBDevices();
            return Observable
                .FromEventPattern<EventArrivedEventHandler, EventArrivedEventArgs>(
                    h => usbDevices.DeviceConnectEvent += h,
                    h => usbDevices.DeviceConnectEvent -= h
                )
                .SelectMany(e => new ConnectedReaders(cardContext))
                .Merge(
                        new ConnectedReaders(cardContext)
                            .ToObservable()
                            .ObserveOn(TaskPoolScheduler.Default) // in order to Read Data from another thread on Reader
                );
        }
    }
}

