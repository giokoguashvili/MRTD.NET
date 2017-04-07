using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure
{
    public class Readers : Optional<int>
    {
        private readonly Option<int> _element;

        public override IOption<int> GetEnumerator()
        {
            return new Option<int>(27);
        }
    }
}
