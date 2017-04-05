using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardApi.MRZ
{
    public class Sex
    {
        private readonly string _mrzDataFieldElement;
        private readonly Dictionary<string, string> _map = new Dictionary<string, string>()
        {
            { "M", "Male" },
            { "F", "Female" },
        };
        public Sex(string mrzDataFieldElement)
        {
            _mrzDataFieldElement = mrzDataFieldElement;
        }

        public override string ToString()
        {
            return _map[_mrzDataFieldElement];
        }
    }
}
