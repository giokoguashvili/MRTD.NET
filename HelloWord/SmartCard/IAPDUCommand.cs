using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.SmartCard
{
    public interface IApduCommand
    {
        IBinary Data();
    }
}
