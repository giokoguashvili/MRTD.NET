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
//    public class DGLength : IBinary
//    {
//        private readonly IBinary _kSenc;
//        private readonly IBinary _kSmac;
//        private readonly IBinary _incrementedSsc;
//        private readonly IReader _reader;
//        private readonly int _firstFourBytesLength = 4;
//        public DGLength(
//                IBinary kSenc,
//                IBinary kSmac,
//                IBinary incrementedSsc,
//                IReader reader
//            )
//        {
//            _kSenc = kSenc;
//            _kSmac = kSmac;
//            _incrementedSsc = incrementedSsc;
//            _reader = reader;
//        }
//        public byte[] Bytes()
//        {
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
