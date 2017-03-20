using System;
using PCSC;
using PCSC.Iso7816;
using HelloWord.Cryptography;
using HelloWord.SmartCard;
using HelloWord.CommandAPDU;
using HelloWord.Commands;
using HelloWord.Cryptography.RandomKeys;
using HelloWord.Infrastructure;

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
                                    reader
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
                                    reader
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
                                    reader
                                )
                            )
                        )
                    );

                    var mrzInfo = "12IB34415792061602210089"; // Bagdavadze
                    //var mrzInfo = "15IC69034696112602606119"; // K
                    //var mrzInfo = "13ID37063295110732402055"; // Shako

                    Console.WriteLine("\nExternalAuthenticate\nResponseAPDU: ");
                    Console.WriteLine(
                        new Hex(
                            new ResponseAPDU(
                                new ExecutedCommandAPDU(
                                    new ExternalAuthenticateCommand(
                                        new ExternalAuthenticateCommandData(
                                            mrzInfo,
                                            new RNDic(reader)
                                        )
                                    ),
                                    reader
                                )
                            )
                        )
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
