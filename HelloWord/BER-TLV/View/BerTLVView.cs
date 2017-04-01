using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.BER_TLV
{
    public class BerTLVView
    {
        private readonly IBerTLV[] _berTlvs;
        private readonly int _depth;
        public BerTLVView(IBerTLV[] berTlvs) : this (berTlvs, 0)
        { }
        public BerTLVView(IBerTLV[] berTlvs, int depth)
        {
            _berTlvs = berTlvs;
            _depth = depth;
        }

        public void View()
        {
            var tagMaxLen = _berTlvs.Max(t => t.Tag.Length);
            foreach (var tlv in _berTlvs)
            {
                var tabs =
                        String.Concat(
                                    Enumerable
                                        .Range(0, _depth)
                                        .Select(ind => "\t")
                                );
                if (tlv.Data.Length == 0)
                {
                    Console.WriteLine(
                                "{0}{1} {2} {3}", 
                                tabs,
                                new PaddedSpace(tlv.Tag, tagMaxLen)
                                        .Paded(),
                                tlv.Len, 
                                new ValView(tlv.Val).View()
                            );
                }
                else
                {
                    Console.WriteLine(
                                     "{0}{1} {2}",
                                     tabs,
                                     tlv.Tag,
                                     tlv.Len
                                );
                    new BerTLVView(tlv.Data, _depth + 1).View();
                }
            }
        }
    }
}
