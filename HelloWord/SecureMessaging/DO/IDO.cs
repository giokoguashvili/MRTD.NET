using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public interface IDO : IBinary
    {
        IBinary EncryptedData();
        IBinary DecryptedData();
    }
}
