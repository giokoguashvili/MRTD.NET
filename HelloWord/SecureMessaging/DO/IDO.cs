using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public interface IDOFactory
    {
        IDO FromUnprotectedCommand(IBinary uprotectedCommandApdu);
        IDO FromProtectedResponse(IBinary uprotectedCommandApdu);
    }

    public interface IDO : IBinary
    {
        IBinary EncryptedData();
        IBinary DecryptedData();
    }
}
