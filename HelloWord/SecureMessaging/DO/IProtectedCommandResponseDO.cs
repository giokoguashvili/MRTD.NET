using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public interface IProtectedCommandResponseDOFactory
    {
        IBinary DO(IBinary commandResponse);
        IBinary DO8E(IBinary commandResponse);
    }
}
