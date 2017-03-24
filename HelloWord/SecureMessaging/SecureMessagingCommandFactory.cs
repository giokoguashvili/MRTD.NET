using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public interface ISecureMessagingCommandFactory
    {
        IBinary RawCommandApdu(
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc
            );

    }
}
