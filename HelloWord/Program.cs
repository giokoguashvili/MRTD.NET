using System;
using PCSC;
using PCSC.Iso7816;
using HelloWord.Cryptography;
using HelloWord.SmartCard;
using HelloWord.Commands;
using HelloWord.Cryptography.RandomKeys;
using HelloWord.DataGroups;
using HelloWord.DataGroups.DG;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.ResponseAPDU.Body;
using HelloWord.SecureMessaging;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextFactory2 = ContextFactory.Instance;
            var context = contextFactory2.Establish(SCardScope.System);


            var readerNames = context.GetReaders();
            foreach (var readerName in readerNames)
            {
                Console.WriteLine(readerName);
            }


            var contextFactory = ContextFactory.Instance;
            SCardMonitor monitor = new SCardMonitor(contextFactory, SCardScope.System);
            monitor.CardInserted += new CardInsertedEvent(CardInsertEventHandler);
            monitor.Start("ACS CCID USB Reader 0");

            Console.ReadKey();
        }


        static void CardInsertEventHandler(object sender, CardStatusEventArgs e)
        {

            var cardContext = ContextFactory.Instance.Establish(SCardScope.System);
            var readerName = e.ReaderName;
            var readerNames = cardContext.GetReaders();

            using (var reader = new SCardReader(cardContext))
            {
                var cardError = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
                if (cardError == SCardError.Success)
                {
                    SCardProtocol proto;
                    SCardState state;
                    byte[] atr;

                    var sc = reader.Status(
                                out readerNames,
                                out state,
                                out proto,
                                out atr);
                    sc = reader.BeginTransaction();
                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Could not begin transaction.");
                        Console.ReadKey();
                        return;
                    }

                    var _reader = new LogedReader(reader);
                    Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
                    Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));

                    Console.WriteLine(
                        new Hex(
                            new ResponseApduData(
                                new Cached(
                                    new ExecutedCommandApdu(
                                        new SelectMRTDApplicationCommandApdu(),
                                        _reader
                                    )
                                )
                            )
                        )
                    );

                    var mrzInfo = "12IB34415792061602210089"; // + K
                    //var mrzInfo = "15IC69034496112612606118"; // Bagdavadze
                    //var mrzInfo = "13ID37063295110732402055";     // + Shako
                    //var mrzInfo = "13IB90080296040761709252";   // + guka 
                    //var mrzInfo = "13ID40308689022472402103";     // + Giorgio

                    var kIfd = new Cached(new Kifd());
                    var rndIc = new Cached(new RNDic(_reader));
                    var rndIfd = new Cached(new RNDifd());

                    var externalAuthRespData = new ResponseApduData(
                                                    new Cached(
                                                        new ExecutedCommandApdu(
                                                            new ExternalAuthenticateCommandApdu(
                                                                new ExternalAuthenticateCommandData(
                                                                    mrzInfo,
                                                                    rndIc,
                                                                    rndIfd,
                                                                    kIfd
                                                                )
                                                            ),
                                                            _reader
                                                        )
                                                    )
                                                );


                    var kSeedIc = new KseedIc(
                                        kIfd,
                                        new Kic(
                                            new R(
                                                externalAuthRespData,
                                                mrzInfo
                                            )
                                        )
                                    );

                    var kSenc = new KSenc(kSeedIc);
                    var kSmac = new KSmac(kSeedIc);
                    var selfIncrementSsc =
                                new SelfIncrementSSC(
                                    new Cached(
                                        new SSC(
                                            rndIc,
                                            rndIfd
                                        )
                                    )
                                );


                    //var com =
                    //    new Cached(
                    //        new COM(
                    //            kSenc,
                    //            kSmac,
                    //            ssc,
                    //            _reader
                    //        )
                    //    );

                    //Console.Write(
                    //        "\nCOM: {0}\n",
                    //        new Hex(
                    //            com
                    //        )
                    //    );
                    //Console.Write(
                    //     "\nCOM Data: {0}\n",
                    //     new COMData(com)
                    // );

                    var dg1 =
                        new Cached(
                            new DG1(
                                kSenc,
                                kSmac,
                                selfIncrementSsc,
                                _reader
                            )
                        );

                    //new DG12(
                    //    new BACReader(
                    //        new MRZInfo(cardID, birtDate, expireData)
                    //    )
                    //).Content();

                    Console.Write(
                           "\nDG1: {0}\n\n",
                           new Hex(dg1)
                       );
                    Console.Write(
                           "\nDG1 Data: {0}\n",
                           new DG1Content(dg1)
                       );

                    reader.EndTransaction(SCardReaderDisposition.Leave);
                    reader.Disconnect(SCardReaderDisposition.Reset);

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Error message: {0}\n", SCardHelper.StringifyError(cardError));
                }
            }
        }
    }
}
