using System;
using System.Collections;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    // Padding
    // The input data must be padded to a multiple of the cipher block size, so that each subsequent cryptographic operation will have a complete block of data.
    // The data to be encrypted SHALL be padded according t o[ISO / IEC 9797 - 1] Padding Method 2
    // 
    // Padding method 2:
    // Add a single bit with value 1 to the end of the data.
    // Then if necessary add bits with value 0 to the end of the data until the padded data is a multiple of n (n is the block length in bits).
    
    public class Padded : IBinary
    {
        private readonly IBinary _data;
        private readonly byte _singleBitWithLackingZeroBytes = 0x80; // 0x80 == 128 == 0b 1000 0000 
        private readonly int _blockSize = 8; // DesEngine cipher block size is 8 byte
        public Padded(IBinary data)
        {
            _data = data;
        }
        public byte[] Bytes()
        {
            var dataWithPaddedSingleBit = new CombinedBinaries(
                                            _data,
                                            new Binary(new [] { _singleBitWithLackingZeroBytes })
                                          );

            var paddedDataLengthInBytes = dataWithPaddedSingleBit
                                            .Bytes()
                                            .Count();
            var lackingBytesCount = _blockSize - (paddedDataLengthInBytes % 8);
            var lackingBytes = Enumerable
                                .Range(0, lackingBytesCount)
                                .Select(i => (byte) 0x00);

            return new CombinedBinaries(
                    dataWithPaddedSingleBit,
                    new Binary(lackingBytes)
                ).Bytes();
        }
    }
}
