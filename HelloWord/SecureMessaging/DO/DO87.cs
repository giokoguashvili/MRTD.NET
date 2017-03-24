using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class DO87 : IDOFactory
    {
        private readonly IBinary _kSenc;
        public DO87(IBinary _kSenc)
        {
            this._kSenc = _kSenc;
        }

        public IDO FromUnprotectedCommand(IBinary uprotectedCommandApdu)
        {
            return new UnprotectedCommandDO87(_kSenc, uprotectedCommandApdu);
        }

        public IDO FromProtectedResponse(IBinary uprotectedCommandApdu)
        {
            throw new NotImplementedException();
        }
    }
}
