using System;
using System.Management;

namespace SmartCardApi.SmartCard.Events
{
    public class USBDevices : IDisposable
    {
        private bool _isFirstAttach = true;
        public event EventArrivedEventHandler DeviceConnectEvent
        {
            add
            {
                _eventWatcher.EventArrived += value;
                if (_isFirstAttach)
                {
                    _eventWatcher.Start();
                }
            }
            remove { _eventWatcher.EventArrived -= value; }
        }

        private readonly ManagementEventWatcher _eventWatcher;
        public USBDevices()
        {
            _eventWatcher = new ManagementEventWatcher(
                new WqlEventQuery()
                {
                    EventClassName = "__InstanceCreationEvent",
                    WithinInterval = new TimeSpan(0, 0, 2),
                    Condition = @"TargetInstance ISA 'Win32_USBControllerDevice'"
                }
            );
        }

        public void Dispose()
        {
            _eventWatcher.Dispose();
        }
    }
}
