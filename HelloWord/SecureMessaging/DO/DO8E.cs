using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class DO8E : IDOFactory
    {
        private readonly IBinary _kSenc;
        public DO8E(IBinary _kSenc)
        {
            this._kSenc = _kSenc;
        }

        public IDO FromUnprotectedCommandApdu(IBinary uprotectedCommandApdu)
        {
            throw  new NotImplementedException();
            //return new UnprotectedCommandDO8E(_kSenc, _kSmac, uprotectedCommandApdu);
        }

        public IDO FromProtectedResponseApdu(IBinary protectedResponseApdu)
        {
            return new ProtectedResponseDO87(_kSenc, protectedResponseApdu);
        }
    }
}
