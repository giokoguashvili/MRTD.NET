using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SmartCardApi.View
{
    public class BerTLVEnumberable : IEnumerable<IBerTLV>
    {
        private readonly IBerTLV[] _berTlvs;

        public BerTLVEnumberable(IBerTLV[] berTlvs)
        {
            _berTlvs = berTlvs;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IBerTLV> GetEnumerator()
        {
            foreach (var tlv in _berTlvs)
            {
                if (tlv.Data.Length == 0)
                {
                    yield return tlv;
                }
                else
                {
                    foreach (var tlv2 in new BerTLVEnumberable(tlv.Data))
                    {
                        yield return tlv2;
                    }
                }
            }
        }
    }
}
