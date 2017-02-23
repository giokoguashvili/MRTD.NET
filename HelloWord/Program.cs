using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCSC;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {



            //var contextFactory = ContextFactory.Instance;

            var cardContext = new SCardContext();
            cardContext.Establish(SCardScope.System);


            SCardMonitor monitor = new SCardMonitor(cardContext, SCardScope.System);
            // Point the callback function(s) to the pre-defined method MyCardInsertedMethod.
            monitor.CardInserted += new CardInsertedEvent(CardInsertEventHandler);
            // Start to monitor the reader
            monitor.Start("ACS CCID USB Reader 0");


            using (cardContext)
            {
                var readerNames = cardContext.GetReaders();
                readerNames
                    .ToList()
                    .ForEach(readerName => Console.WriteLine(readerName));

                readerNames
                    .ToList()
                    .ForEach(readerName =>
                    {
                        using (var reader = new SCardReader(cardContext))
                        {



                            var cardError = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
                            if (cardError == SCardError.Success)
                            {
                                string[] names;
                                SCardProtocol proto;
                                SCardState state;
                                byte[] atr;

                                var sc = reader.Status(
                                            out readerNames, // contains the reader name(s)
                                            out state, // contains the current state (flags)
                                            out proto, // contains the currently used communication protocol
                                            out atr); //            


                                Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
                                Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));
                            }
                            else
                            {
                                Console.WriteLine("Error message: {0}\n", SCardHelper.StringifyError(cardError));
                            }
                        }
                    });
                Console.ReadKey();
            }

        }

        static void CardInsertEventHandler(object sender, PCSC.CardStatusEventArgs e)
        {

            Console.WriteLine("Reader name: {0}\nCard ART: {1}", e.ReaderName, BitConverter.ToString(e.Atr));
            //using (var reader = new SCardReader(cardContext))
            //{



            //    var cardError = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
            //    if (cardError == SCardError.Success)
            //    {
            //        string[] names;
            //        SCardProtocol proto;
            //        SCardState state;
            //        byte[] atr;

            //        var sc = reader.Status(
            //                    out readerNames, // contains the reader name(s)
            //                    out state, // contains the current state (flags)
            //                    out proto, // contains the currently used communication protocol
            //                    out atr); //            


            //        Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
            //        Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));
            //    }
            //    else
            //    {
            //        Console.WriteLine("Error message: {0}\n", SCardHelper.StringifyError(cardError));
            //    }
            //}


            //Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
            //Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));
        }
    }
}
