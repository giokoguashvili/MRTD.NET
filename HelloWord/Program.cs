using System;
using PCSC;
using PCSC.Iso7816;
using HelloWord.Cryptography;
using HelloWord.SmartCard;
using HelloWord.CommandAPDU;
using HelloWord.Cryptography.RandomKeys;
using HelloWord.Infrastructure;

namespace HelloWord
{

    public interface IDoor 
    { 
        IDoor Opend();
        IDoor Closed();
    }
    public class OpendDoor: IDoor 
    {
        private readonly string _color;
        private bool _isOpend = true;
        public Door(string color) 
        {
            _color = color;
        }

        public IDoor Open() {
            return this;
        }

        public IDoor Close();
    }

}
