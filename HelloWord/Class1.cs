using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.ResponseDO.DO87;
using HelloWord.SecureMessaging.ResponseDO.DO97;
using HelloWord.SecureMessaging.ResponseDO.ResponseDOFactory;
using HelloWord.SmartCard;

namespace HelloWord
{
    class Class1
    {
        private readonly IReader _reader;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        //public Class1()
        //{
        //    new VerifiedProtectedCommandResponse(new VerifiedProtectedCommandResponse(new VerifiedProtectedCommandResponse(
        //        new CachedBinary(new CachedBinary(new CachedBinary(
        //            new ExecutedCommandApdu(new ExecutedCommandApdu(new ExecutedCommandApdu(
        //                new DO87ProtectedCommandApdu(new DO97ProtectedCommandApdu(new DO97ProtectedCommandApdu(
        //                    new SelectEFCOMApplicationCommand(), new ReadBinaryCommand(4), new ReadBinaryCommand(4, 18),
        //                    _kSenc, _kSenc, _kSenc,
        //                    _kSmac, _kSmac, _kSmac,
        //                    new IncrementedSSC(_ssc).By(1)                          new IncrementedSSC(_ssc).By(3)                      new IncrementedSSC(_ssc).By(5)
        //                ),                                                      ),                                                  ),
        //                _reader                                                 _reader                                             _reader
        //            )))
        //        ),                                                      ),                                                  ),
        //        new IncrementedSSC(_ssc).By(2), new IncrementedSSC(_ssc).By(4), new IncrementedSSC(_ssc).By(6),
        //        _kSmac, _kSmac, _kSmac,
        //        new DO87ProtectedCommandResponseDOFactory()             new DO97ProtectedCommandResponseDOFactory()         new SecondDO97ProtectedCommandResponseDOFactory()
        //    ).Bytes();                                              ).Bytes();                                          ).Bytes();
        //}
    }
}
