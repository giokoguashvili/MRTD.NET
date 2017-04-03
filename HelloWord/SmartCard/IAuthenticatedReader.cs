using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace HelloWord.SmartCard
{
    public interface IAuthenticatedReader : IReader
    {
        IBinary KSenc();
        IBinary KSmac();
        IBinary SelfIncrementedSSC();
    }
}
