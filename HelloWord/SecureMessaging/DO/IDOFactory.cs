using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public interface IDOFactory
    {
        IDO FromUnprotectedCommandApdu(IBinary uprotectedCommandApdu);
        IDO FromProtectedResponseApdu(IBinary protectedResponseApdu);
    }
}
