using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCSC;
using PCSC.Iso7816;
using HelloWord.Cryptography;
using HelloWord.Cryptography.Keys;
using HelloWord.SmartCard.DataElements;
using HelloWord.SmartCard;
using HelloWord.Cryptography.RandomKeys;
using HelloWord.ApduCommands;
using HelloWord.ApduCommandsResponses;
using HelloWord.APDU;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                    new Hex(
                        new SHA1(
                            new UTF8String("L898902C<369080619406236")
                        )
                    ).AsString()
                );

            Console.WriteLine(
                    new Hex(
                        new SHA1(
                            new UTF8String("239AB9CB282DAF66231DC5A4DF6BFBAE00000001")
                        )
                    ).AsString()
                );

            Console.WriteLine(
                    new Hex(
                        new SHA1(
                            new D(
                                new Kseed(
                                    new SHA1(
                                        new UTF8String("L898902C<369080619406236")
                                    )
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
                            new Kseed(
                                new SHA1(
                                    new UTF8String("L898902C<369080619406236")
                                )
                            )
                        );

            Console.WriteLine(
                    new Hex(
                        new Ka(kEnc)
                    ).AsString()
                );

            Console.WriteLine(
                    new Hex(
                        new Kb(kEnc)
                    ).AsString()
                );

            Console.WriteLine(
                    new Hex(
                        kEnc
                    ).AsString()
                );

            Console.WriteLine("KMac");
            var kMac = new Kmac(
                            new Kseed(
                                new SHA1(
                                    new UTF8String("L898902C<369080619406236")
                                )
                            )
                        );

            Console.WriteLine(
                    new Hex(
                        new Ka(kMac)
                    ).AsString()
                );

            Console.WriteLine(
                    new Hex(
                        new Kb(kMac)
                    ).AsString()
                );

            Console.WriteLine(
                new Hex(
                    new TripleDES(
                            kEnc,
                            new BinaryHex("781723860C06C2264608F919887022120B795240CB7049B01C19B33E32804F0B")
                        ).Encrypted()
                ).AsString()
            );

            var contextFactory = ContextFactory.Instance;
            SCardMonitor monitor = new SCardMonitor(contextFactory, SCardScope.System);
            monitor.CardInserted += new CardInsertedEvent(CardInsertEventHandler);
            monitor.Start("ACS CCID USB Reader 0");

            //new DG1(
            //    new MiniLectorEVO(
            //        () => new IdenitityCard()
            //    )
            //).Binary();

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
                                out readerNames,
                                out state,
                                out proto,
                                out atr);


                    Console.WriteLine("Connected with protocol {0} in state {1}", proto, state);
                    Console.WriteLine("Card ATR: {0}", BitConverter.ToString(atr));


                    Console.WriteLine("\n\nSelectFile DF: ");
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
                                    }
                    };
                    sc = reader.BeginTransaction();
                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Could not begin transaction.");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Retrieving the UID .... ");

                    var receivePci = new SCardPCI();
                    var sendPci = SCardPCI.GetPci(reader.ActiveProtocol);

                    var receiveBuffer = new byte[10];
                    var command = apdu.ToArray();
                    Console.WriteLine(
                                String.Format("APDU: {0}\n", new Hex(new Binary(command)).AsString())
                            );
                    sc = reader.Transmit(
                        sendPci,
                        command,
                        receivePci,
                        ref receiveBuffer);

                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Error: " + SCardHelper.StringifyError(sc));
                    }

                    var responseApdu = new ResponseApdu(receiveBuffer, IsoCase.Case3Short, reader.ActiveProtocol);
                    Console.Write("SW1: {0:X2}, SW2: {1:X2}\nUid: {2}\n",
                        responseApdu.SW1,
                        responseApdu.SW2,
                        responseApdu.HasData ? BitConverter.ToString(responseApdu.GetData()) : "No uid received");



                    // E1
                    Console.WriteLine("\n\nSelectFile: ");
                    var receiveBuffer0 = new byte[256];
                    var apdu0 = new CommandApdu(IsoCase.Case3Short, reader.ActiveProtocol)
                    {
                        CLA = 0x00,
                        Instruction = InstructionCode.SelectFile,
                        P1 = 0x02,
                        P2 = 0x0C,
                        Data = new byte[] { 0x01, 0x1E }
                    };
                    var command0 = apdu0.ToArray();
                    Console.WriteLine(
                                String.Format("APDU: {0}\n", new Hex(new Binary(command0)).AsString())
                            );
                    sc = reader.Transmit(
                            sendPci,
                            command0,
                            receivePci,
                            ref receiveBuffer0);

                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Error: " + SCardHelper.StringifyError(sc));
                    }

                    var responseApdu0 = new ResponseApdu(receiveBuffer0, IsoCase.Case3Short, reader.ActiveProtocol);
                    Console.Write("RND SW1: {0:X2}, SW2: {1:X2}\nUid: {2}\n",
                        responseApdu0.SW1,
                        responseApdu0.SW2,
                        responseApdu0.HasData ? BitConverter.ToString(responseApdu0.GetData()) : "No uid received");

                    // READ BINARY
                    Console.WriteLine("\n\nReadBinary: ");
                    var receiveBuffer00 = new byte[10];
                    var apdu00 = new CommandApdu(IsoCase.Case2Short, reader.ActiveProtocol)
                    {
                        CLA = 0x00,
                        Instruction = InstructionCode.ReadBinary,
                        P1 = 0x00,
                        P2 = 0x00,
                        Le = 0x08
                    };
                    var command00 = apdu00.ToArray();
                    Console.WriteLine(
                                String.Format("APDU: {0}\n", new Hex(new Binary(command00)).AsString())
                            );
                    sc = reader.Transmit(
                            sendPci,
                            command00,
                            receivePci,
                            ref receiveBuffer00);

                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Error: " + SCardHelper.StringifyError(sc));
                    }

                    var responseApdu00 = new ResponseApdu(receiveBuffer00, IsoCase.Case2Short, reader.ActiveProtocol);
                    Console.Write("RND SW1: {0:X2}, SW2: {1:X2}\nUid: {2}\n",
                        responseApdu00.SW1,
                        responseApdu00.SW2,
                        responseApdu00.HasData ? BitConverter.ToString(responseApdu00.GetData()) : "No uid received");

                    // GET CHALLENGE
                    Console.WriteLine("\n\nGetChallenge: ");
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
                    Console.WriteLine(
                                String.Format("APDU: {0}\n", new Hex(new Binary(command1)).AsString())
                            );
                    sc = reader.Transmit(
                            sendPci,
                            command1,
                            receivePci,
                            ref receiveBuffer1);

                    if (sc != SCardError.Success)
                    {
                        Console.WriteLine("Error: " + SCardHelper.StringifyError(sc));
                    }

                    var responseApdu1 = new ResponseApdu(receiveBuffer1, IsoCase.Case2Short, reader.ActiveProtocol);
                    Console.Write("RND SW1: {0:X2}, SW2: {1:X2}\nUid: {2}\n",
                        responseApdu1.SW1,
                        responseApdu1.SW2,
                        responseApdu1.HasData ? BitConverter.ToString(responseApdu1.GetData()) : "No uid received");

                    var mrzInfoMy = "12IB34415792061602210089";
                    var mrzInfoGio = "15IC69034696112602606119";

                    //var cmd_data = ;

                    //Console.WriteLine(
                    //        new Hex(
                    //            cmd_data
                    //        ).AsString()
                    //    );
                    //Console.WriteLine(
                    //        new Hex(
                    //            cmd_data
                    //        ).AsString()
                    //    );

                    Console.WriteLine("\n\nExternalAuthenticate: ");
                    //var receiveBuffer2 = new byte[42];
                    //var apdu2 = new CommandApdu(IsoCase.Case4Short, reader.ActiveProtocol)
                    //{
                    //    CLA = 0x00,
                    //    Instruction = InstructionCode.ExternalAuthenticate,
                    //    P1 = 0x00,
                    //    P2 = 0x00,
                    //    Data = cmd_data.Bytes(),
                    //    Le = 40, // (0x28)
                    //};
                    //var command2 = apdu2.ToArray(); //.Take(2).Concat(apdu2.ToArray().Skip(4)).ToArray();

                    //Console.WriteLine(
                    //            String.Format("APDU: {0}\n", new Hex(new Binary(command2)).AsString())
                    //        );

                    Console.WriteLine(
                            new Hex(
                                new ResponseAPDU(
                                    new ExecutedCommandAPDU(
                                        new ExternalAuthenticateCommand(
                                            new ExternalAuthenticateCommandData(
                                                   mrzInfoMy,
                                                   new BinaryHex(
                                                       new Hex(
                                                           new Binary(responseApdu1.GetData())
                                                       ).AsString()
                                                   )
                                               )
                                        ),
                                        reader
                                    )
                                ).FullData()
                            ).AsString()
                        );

                    //sc = reader.Transmit(
                    //        sendPci, // Protocol Control Information (T0, T1 or Raw)
                    //        command2, // command APDU
                    //        receivePci, // returning Protocol Control Information
                    //        ref receiveBuffer2); // data buffer

                    //if (sc != SCardError.Success)
                    //{
                    //    Console.WriteLine("Error: " + SCardHelper.StringifyError(sc));
                    //}

                    //var responseApdu2 = new ResponseApdu(receiveBuffer2, IsoCase.Case4Short, reader.ActiveProtocol);
                    //Console.Write("SW1: {0:X2}, SW2: {1:X2}\nUid: {2}\n",
                    //    responseApdu2.SW1,
                    //    responseApdu2.SW2,
                    //    responseApdu2.HasData ? BitConverter.ToString(responseApdu2.GetData()) : "No uid received");


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
