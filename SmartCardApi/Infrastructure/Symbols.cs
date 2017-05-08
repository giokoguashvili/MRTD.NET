using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class Symbols : ISymbols
    {
        private readonly string _str;

        public Symbols(string str)
        {
            _str = str;
        }
        public override string ToString()
        {
            return _str;
        }
    }
}
