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
using HelloWord.SmartCard.Reader;

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
                    Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
                    Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));

                    var mrzInfo = "12IB34415792061602210089"; // + K
                    //var mrzInfo = "15IC69034496112612606118"; // Bagdavadze
                    //var mrzInfo = "13ID37063295110732402055";     // + Shako
                    //var mrzInfo = "13IB90080296040761709252";   // + guka 
                    //var mrzInfo = "13ID40308689022472402103";     // + Giorgio
                    var _reader = new BacReader(
                                        new SecuredReader(
                                                mrzInfo,
                                                new WrReader(
                                                    new LogedReader(
                                                        reader
                                                    )
                                                )
                                         )
                                  );

                    var dg1 = new DG1(_reader);
                    Console.Write(
                           "\nDG1: {0}\n\n",
                           new Hex(dg1)
                       );
                    Console.Write(
                           "\nDG1 Data: {0}\n",
                           dg1.Content()
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
