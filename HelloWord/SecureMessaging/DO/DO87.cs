using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.ResponseDO.DO97;

namespace HelloWord.SecureMessaging.DO
{
    public class DO87 : IDOFactory
    {
        private readonly IBinary _kSenc;
        public DO87(IBinary _kSenc)
        {
            this._kSenc = _kSenc;
        }

        public IDO FromUnprotectedCommandApdu(IBinary uprotectedCommandApdu)
        {
            return new UnprotectedCommandDO87(_kSenc, uprotectedCommandApdu);
        }

        public IDO FromProtectedResponseApdu(IBinary protectedResponseApdu)
        {
            return new ProtectedResponseDO87(_kSenc, protectedResponseApdu);
        }
    }
}
