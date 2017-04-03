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
using HelloWord.View;

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

                    var com = new COM(_reader);
                    var dg1 = new DG1(_reader);
                    var dg2 = new DG2(_reader);
                    var dg7 = new DG7(_reader);
                    var dg11 = new DG11(_reader);
                    var dg12 = new DG12(_reader);

                    var comData = new Cached(com.Bytes());
                    var dg1Data = new Cached(dg1.Bytes());
                    var dg2Data = new Cached(dg2.Bytes());
                    var dg7Data = new Cached(dg7.Bytes());
                    var dg11Data = new Cached(dg11.Bytes());
                    var dg12Data = new Cached(dg12.Bytes());

                    var comContent = com.Content();
                    var dg1Content = dg1.Content();

                    Console.WriteLine("\nData Groups:\n");
                    new DGDataView(comData).View();
                    new DGDataView(dg1Data).View();
                    new DGDataView(dg2Data).View();
                    new DGDataView(dg7Data).View();
                    new DGDataView(dg11Data).View();
                    new DGDataView(dg12Data).View();


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
