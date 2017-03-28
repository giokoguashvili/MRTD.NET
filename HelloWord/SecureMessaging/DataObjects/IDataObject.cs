using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.SecureMessaging.DataObjects
{
    public interface IDataObject
    {
        byte[] EncryptedData();
    }
}
