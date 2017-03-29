//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HelloWord.Commands;
//using HelloWord.Infrastructure;
//using HelloWord.SecureMessaging;
//using HelloWord.SmartCard;

//namespace HelloWord.DataGroups
//{
//    public class DGFirstFourBytes : IBinary
//    {
//        private readonly IBinary _applicationIdentifier;
//        private readonly IBinary _kSenc;
//        private readonly IBinary _kSmac;
//        private readonly IBinary _incrementedSsc;
//        private readonly IReader _reader;
//        private readonly int _firstFourBytesLength = 4;
//        public DGFirstFourBytes(
//                IBinary applicationIdentifier,
//                IBinary kSenc,
//                IBinary kSmac,
//                IBinary incrementedSsc,
//                IReader reader
//            )
//        {
//            _applicationIdentifier = applicationIdentifier;
//            _kSenc = kSenc;
//            _kSmac = kSmac;
//            _incrementedSsc = incrementedSsc;
//            _reader = reader;
//        }
//        public byte[] Bytes()
//        {
//            new VerifiedProtectedResponseApdu(
//                new Cached(
//                    new ExecutedCommandApdu(
//                        new ProtectedCommandApdu(
//                            new SelectApplicationCommandApdu(_applicationIdentifier),
//                            _kSenc,
//                            _kSmac,
//                             new IncrementedSSC(_ssc).By(1)
//                        ),
//                        _reader
//                    )
//                ),
//                new IncrementedSSC(_ssc).By(2),
//                _kSmac
//            ).Bytes();

//            var firstFourBytes = new DecryptedProtectedResponseApdu(
//                                     new Cached(
//                                         new VerifiedProtectedResponseApdu(
//                                             new Cached(
//                                                 new ExecutedCommandApdu(
//                                                     new ProtectedCommandApdu(
//                                                         new ReadBinaryCommandApdu(0, _firstFourBytesLength),
//                                                         _kSenc,
//                                                         _kSmac,
//                                                         _incrementedSsc
//                                                     ),
//                                                     _reader
//                                                 )
//                                             ),
//                                             _incrementedSsc,
//                                             _kSmac
//                                         )
//                                     ),
//                                     _kSenc
//                                 );
//        }


//    }
//}
