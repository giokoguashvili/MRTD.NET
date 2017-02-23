using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCSC;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextFactory = ContextFactory.Instance;

            using (var context = contextFactory.Establish(SCardScope.System))
            {
                var readerNames = context.GetReaders();
                readerNames.ToList().ForEach(item => Console.WriteLine(item));
                Console.ReadKey();
            }
        }
    }
}
