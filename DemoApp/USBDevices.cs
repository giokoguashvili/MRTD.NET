using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
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
            //_eventWatcher.Dispose();
        }
    }
}
