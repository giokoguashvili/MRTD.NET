using System;
using PCSC;
using PCSC.Iso7816;
using HelloWord.Cryptography;
using HelloWord.SmartCard;
using HelloWord.CommandAPDU;
using HelloWord.Commands;
using HelloWord.Cryptography.RandomKeys;
using HelloWord.DataGroups;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {

            var contextFactory = ContextFactory.Instance;
            SCardMonitor monitor = new SCardMonitor(contextFactory, SCardScope.System);
            monitor.CardInserted += new CardInsertedEvent(CardInsertEventHandler);
            monitor.Start("ACS CCID USB Reader 0");

            Console.ReadKey();
        }


        static void CardInsertEventHandler(object sender, PCSC.CardStatusEventArgs e)
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
                    Console.WriteLine("\n\nSelectFile DF: ");
                    Console.WriteLine("Retrieving the UID .... ");

                    Console.WriteLine("\nSelectMRTDApplication\nResponseAPDU: ");
                    Console.WriteLine(
                        new Hex(
                            new ResponseAPDU(
                                new ExecutedCommandAPDU(
                                    new SelectMRTDApplicationCommand(),
                                    _reader
                                )
                            )
                        )
                    );


                    Console.WriteLine("\nSelectEFCOMApplication\nResponseAPDU: ");
                    Console.WriteLine(
                        new Hex(
                            new ResponseAPDU(
                                new ExecutedCommandAPDU(
                                    new SelectEFCOMApplicationCommand(),
                                    _reader
                                )
                            )
                        )
                     );

                    Console.WriteLine("\nReadBinary\nResponseAPDU: ");
                    Console.WriteLine(
                        new Hex(
                            new ResponseAPDU(
                                new ExecutedCommandAPDU(
                                    new ReadBinaryCommand(),
                                    _reader
                                )
                            )
                        )
                    );

                    //var mrzInfo = "12IB34415792061602210089"; // K
                    //var mrzInfo = "15IC69034696112602606119"; // Bagdavadze
                    var mrzInfo = "13ID37063295110732402055"; // Shako

                    Console.WriteLine("\nExternalAuthenticate\nResponseAPDU: ");

                    var kIfd = new CachedBinary(new Kifd());
                    var rndIc = new CachedBinary(new RNDic(_reader));
                    var rndIfd = new CachedBinary(new RNDifd());

                    var externalAuthRespData = new ResponseAPDU(
                                                    new ExecutedCommandAPDU(
                                                        new ExternalAuthenticateCommand(
                                                            new ExternalAuthenticateCommandData(
                                                                mrzInfo,
                                                                rndIc,
                                                                rndIfd,
                                                                kIfd
                                                            )
                                                        ),
                                                        _reader
                                                    )
                                                ).Body();

                    Console.WriteLine(
                        new Hex(
                            externalAuthRespData
                        )
                    );

                    Console.WriteLine("\nSecure Messaging");

                    var kSeedIc = new KseedIc(
                                        kIfd,
                                        new Kic(
                                            new R(
                                                externalAuthRespData,
                                                mrzInfo
                                            )
                                        )
                                    );

                    Console.Write(
                            new Hex(
                                new COM(
                                    new KSenc(kSeedIc),
                                    new KSmac(kSeedIc),
                                    new SSC(
                                            rndIc,
                                            rndIfd
                                    ),
                                    _reader
                                )
                            ).ToString()
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
