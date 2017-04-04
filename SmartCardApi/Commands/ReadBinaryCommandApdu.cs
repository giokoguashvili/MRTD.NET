using System.Linq;
using PCSC;
using PCSC.Iso7816;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Commands
{
    public class ReadBinaryCommandApdu : IBinary
    {
        private readonly IsoCase _isoCase = IsoCase.Case2Short;
        private readonly INumber _offsetLength;
        private readonly INumber _expectedDataLength;
        private readonly SCardProtocol _activeProtocol = SCardProtocol.T1;

        public ReadBinaryCommandApdu(INumber expectedDataLength) 
            : this(new Number(0), expectedDataLength)
        {
        }
        public ReadBinaryCommandApdu(INumber offsetLength, INumber expectedDataLength)
        {
            _offsetLength = offsetLength;
            _expectedDataLength = expectedDataLength;
        }

        public byte[] Bytes()
        {
            var hexLen = new BinaryHex(
                    _offsetLength
                        .Value()
                        .ToString("X4")
                ).Bytes();

            var offsetMSB = hexLen.Skip(0).Take(1).First(); // new HexInt(_offsetLength).Bytes().First();
            var offsetLSB = hexLen.Skip(1).Take(1).First(); //new HexInt(_offsetLength + _expectedDataLength).Bytes().First();

            var comm = new CommandApdu(_isoCase, _activeProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.ReadBinary,
                P1 = offsetMSB,
                P2 = offsetLSB, //new BinaryHex(_offsetLength.ToString("X2")).Bytes().First(),
                Le = _expectedDataLength.Value()
            }.ToArray();
            return comm;
        }
    }
}
