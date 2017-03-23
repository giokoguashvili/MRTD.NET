using HelloWord.ISO7816.CommandAPDU;
using HelloWord.ISO7816.ResponseAPDU.Body;
using HelloWord.SmartCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.SecureMessaging;
using HelloWord.SecureMessaging.ResponseDO.DO87;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Infrastructure
{

                //return
                //new ChainedCommand(
                //     (s) => new DO97ProtectedCommandApdu(
                //        new ReadBinaryCommand(4),
                //        _kSenc,
                //        _kSmac,
                //        new IncrementedSSC(
                //            new IncrementedSSC(
                //                new IncrementedSSC(
                //                    _ssc
                //                )
                //            )
                //        )
                //     ),
                //     new ChainedCommand(
                //        (result) => new VerifiedResponseApduFactory(result).Command(),
                //        new DO87ProtectedCommandApduFactory(_kSenc, _kSmac, _ssc)
                //    )
                //)
                //.Enclosed(_reader)
                //.Bytes();
    public class ChainedCommand : IChain
    {
        private readonly Func<IBinary, IBinary> _func;
        private readonly ICommandApdu _nextCommand;
        private readonly IChain _chain;
        private readonly ICommandApduFactory _commandFactory;
        

        public ChainedCommand(
                Func<IBinary, IBinary> func,
                ICommandApduFactory commandFactory
            )
            : this(
                    func,
                    new FkCommandApdu(),
                    new FkChainedCommand(),
                    commandFactory
                  )
        {

        }

        public ChainedCommand(
                Func<IBinary, IBinary> func,
                ICommandApdu command
            ) 
            : this(
                    func, 
                    command, 
                    new FkChainedCommand(),
                    new FkCommandFactory()
                  )
        {

        }

        public ChainedCommand(
                Func<IBinary, IBinary> func,
                IChain chain
            )
            : this(
                      func, 
                      new FkCommandApdu(), 
                      chain,
                      new FkCommandFactory()
                  )
        {

        }
        private ChainedCommand(
                Func<IBinary, IBinary> func,
                ICommandApdu nextCommand,
                IChain chain,
                ICommandApduFactory commandFactory
            )
        {
            _func = func;
            _nextCommand = nextCommand;
            _chain = chain;
            _commandFactory = commandFactory;
        }

        public IBinary Enclosed(IReader reader)
        {
            var commandResult = _nextCommand.Bytes();
            var chainResult = _chain.Enclosed(reader).Bytes();
            var commandFactoruResult = _commandFactory.Command().Bytes();

            var nextInput = chainResult;
            if (commandResult.Length != 0)
            {
                nextInput = new ResponseApduData(
                                    new CachedBinary(
                                        new ExecutedCommandApdu(
                                            _nextCommand,
                                            reader
                                         )
                                     )
                                 ).Bytes();
            }
            else if (commandFactoruResult.Length != 0)
            {
                nextInput = new ResponseApduData(
                                    new CachedBinary(
                                        new ExecutedCommandApdu(
                                            _commandFactory.Command(),
                                            reader
                                         )
                                     )
                                 ).Bytes();
            }



            return _func(
                    new Binary(nextInput)
                );
        }
    }

    public class FkChainedCommand : IChain
    {
        public IBinary Enclosed(IReader reader)
        {
            return new Binary();
        }
    }

    public class FkCommandApdu : ICommandApdu
    {
        public SCardProtocol ActiveProtocol()
        {
            throw new NotImplementedException();
        }

        public byte[] Bytes()
        {
            return new Binary().Bytes();
        }

        public IsoCase Case()
        {
            throw new NotImplementedException();
        }

        public int ExceptedDataLength()
        {
            throw new NotImplementedException();
        }
    }

    public class FkCommandFactory : ICommandApduFactory
    {
        public IBinary Command()
        {
            return new FkCommandApdu();
        }
    }


    public class VerifiedResponseApduFactory : ICommandApduFactory
    {
        public VerifiedResponseApduFactory(IBinary r)
        {

        }
        public IBinary Command()
        {
            throw new NotImplementedException();
        }
    }

    public class DO87ProtectedCommandApduFactory : ICommandApduFactory
    {
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        public DO87ProtectedCommandApduFactory(
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc
            )
        {
            _kSenc = kSenc;
            _kSmac = kSmac;
            _ssc = ssc;
        }

        public IBinary Command()
        {
            return new DO87ProtectedCommandApdu(
                            new SelectEFCOMApplicationCommand(),
                            _kSenc,
                            _kSmac,
                            new IncrementedSSC(_ssc).By(1)
                   );
        }
    }
}
