using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.ResponseDO.DO87;
using HelloWord.SecureMessaging.ResponseDO.DO97;

namespace HelloWord.SecureMessaging.ResponseDO.ResponseDOFactory
{
    public class SecondDO97ProtectedCommandResponseDOFactory : IProtectedCommandResponseDOFactory
    {
        public IBinary DO(IBinary commandResponse)
        {
            return new SecondDO97ProtectedCommandResponseDO87DO99(commandResponse);
        }

        public IBinary DO8E(IBinary commandResponse)
        {
            return new SecondDO97ProtectedCommandResponseDO8E(commandResponse);
        }
    }
}
