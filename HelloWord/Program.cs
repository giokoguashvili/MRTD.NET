using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCSC;
using PCSC.Iso7816;
using HelloWord.Cryptography;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {

            //var contextFactory = ContextFactory.Instance;

            //SCardMonitor monitor = new SCardMonitor(contextFactory, SCardScope.System);
            //// Point the callback function(s) to the pre-defined method MyCardInsertedMethod.
            //monitor.CardInserted += new CardInsertedEvent(CardInsertEventHandler);
            //// Start to monitor the reader
            //monitor.Start("ACS CCID USB Reader 0");


            Console.WriteLine(
                    new Hex(
                        new SHA1("L898902C<369080619406236")
                    ).AsString()
                );
            Console.WriteLine(
                    new Hex(
                        new SHA1("239AB9CB282DAF66231DC5A4DF6BFBAE00000001")
                    ).AsString()
                );


            Console.WriteLine(
                    new Hex(
                        new SHA1(
                            new D(
                                new KSeed(
                                    new SHA1("L898902C<369080619406236")
                                ),
                                "00000001"
                            )
                        )
                    ).AsString()
                );

            Console.WriteLine(
                    new Hex(
                        new AdjustedParity(
                            new BinaryHex("AB94FCEDF2664EDF")
                        )
                    ).AsString()
                );
            Console.WriteLine(
                    new Hex(
                        new AdjustedParity(
                            new BinaryHex("B9B291F85D7F77F2")
                        )
                    ).AsString()
                );

            Console.WriteLine("KEnc");
            var kEnc = new Kenc(
                            new KSeed(
                                new SHA1("L898902C<369080619406236")
                            )
                        )
                        .Keys();

            Console.WriteLine(
                    new Hex(
                        kEnc.Ka()
                    ).AsString()
                );

            Console.WriteLine(
                    new Hex(
                        kEnc.Kb()
                    ).AsString()
                );

            Console.WriteLine("KMac");
            var kMac = new Kmac(
                            new KSeed(
                                new SHA1("L898902C<369080619406236")
                            )
                        )
                        .Keys();

            Console.WriteLine(
                    new Hex(
                        kMac.Ka()
                    ).AsString()
                );

            Console.WriteLine(
                    new Hex(
                        kMac.Kb()
                    ).AsString()
                );

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



                    var apdu = new CommandApdu(IsoCase.Case3Short, reader.ActiveProtocol)
                    {
                        CLA = 0x00,
                        Instruction = InstructionCode.SelectFile,
                        P1 = 0x04,
                        P2 = 0x0C,
                        Data = new byte[] {
                                        0xA0,
                                        0x00,
                                        0x00,
                                        0x02,
                                        0x47,
                                        0x10,
                                        0x01
                                    }// We don't know the ID tag size
                    };
                    sc = reader.BeginTransaction();
                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Could not begin transaction.");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Retrieving the UID .... ");

                    var receivePci = new SCardPCI(); // IO returned protocol control information.
                    var sendPci = SCardPCI.GetPci(reader.ActiveProtocol);

                    var receiveBuffer = new byte[10];
                    var command = apdu.ToArray();

                    sc = reader.Transmit(
                        sendPci, // Protocol Control Information (T0, T1 or Raw)
                        command, // command APDU
                        receivePci, // returning Protocol Control Information
                        ref receiveBuffer); // data buffer

                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Error: " + SCardHelper.StringifyError(sc));
                    }

                    var responseApdu = new ResponseApdu(receiveBuffer, IsoCase.Case3Short, reader.ActiveProtocol);
                    Console.Write("SW1: {0:X2}, SW2: {1:X2}\nUid: {2}\n",
                        responseApdu.SW1,
                        responseApdu.SW2,
                        responseApdu.HasData ? BitConverter.ToString(responseApdu.GetData()) : "No uid received");






                    var receiveBuffer1 = new byte[256];
                    var apdu1 = new CommandApdu(IsoCase.Case2Short, reader.ActiveProtocol)
                    {
                        CLA = 0x00,
                        Instruction = InstructionCode.GetChallenge,
                        P1 = 0x00,
                        P2 = 0x00,
                        Le = 8,
                    };
                    var command1 = apdu1.ToArray();

                    sc = reader.Transmit(
                            sendPci, // Protocol Control Information (T0, T1 or Raw)
                            command1, // command APDU
                            receivePci, // returning Protocol Control Information
                            ref receiveBuffer1); // data buffer

                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Error: " + SCardHelper.StringifyError(sc));
                    }

                    var responseApdu1 = new ResponseApdu(receiveBuffer1, IsoCase.Case2Short, reader.ActiveProtocol);
                    Console.Write("SW1: {0:X2}, SW2: {1:X2}\nUid: {2}",
                        responseApdu1.SW1,
                        responseApdu1.SW2,
                        responseApdu1.HasData ? BitConverter.ToString(responseApdu1.GetData()) : "No uid received");





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
