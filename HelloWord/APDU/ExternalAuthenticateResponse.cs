using HelloWord.APDU;
using HelloWord.ApduCommands;
using HelloWord.Cryptography;
using PCSC;
using PCSC.Iso7816;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.ApduCommandsResponses
{
    public class ExternalAuthenticateResponse : IBinary
    {
        private readonly ICommandAPDU _externalAuthenticateCommand;
        private readonly ISCardReader _reader;
        public ExternalAuthenticateResponse(
                ICommandAPDU externalAuthenticateCommand,
                ISCardReader reader
            )
        {
            this._externalAuthenticateCommand = externalAuthenticateCommand;
            this._reader = reader;
        }
        public byte[] Bytes()
        {
            return new ResponseApdu(
                    new ExecutedCommandAPDU(
                        _externalAuthenticateCommand,
                        _reader
                    ).Bytes(),
                    this._externalAuthenticateCommand.IsoCase(),
                    this._reader.ActiveProtocol
                ).FullApdu;
        }
    }
}
