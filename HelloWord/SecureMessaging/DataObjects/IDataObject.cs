using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects
{
    public interface IDataObject
    {
        IBinary EncryptedData();
    }
}
