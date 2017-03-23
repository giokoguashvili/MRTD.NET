using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DO;

namespace HelloWord.SecureMessaging.ResponseDO
{
    public class DO97ProtectedCommandResponseDOFactory : IProtectedCommandResponseDOFactory
    {
        public IBinary DO(IBinary commandResponse)
        {
            return new DO97ProtectedCommandResponseDO87DO99(commandResponse);
        }

        public IBinary DO8E(IBinary commandResponse)
        {
            return new DO97ProtectedCommandResponseDO8E(commandResponse);
        }
    }
}
