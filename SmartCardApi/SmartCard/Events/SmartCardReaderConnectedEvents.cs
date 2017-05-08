using System;
using System.Collections.Generic;
using System.Management;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using PCSC;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.SmartCardReader;

namespace SmartCardApi.SmartCard.Events
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
                            .ToObservable(TaskPoolScheduler.Default) // in order to Read Data from another thread on Reader
                            .ObserveOn(TaskPoolScheduler.Default) // in order to Read Data from another thread on Reader
                );
        }
    }
}

