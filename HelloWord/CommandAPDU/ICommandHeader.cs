using HelloWord.Infrastructure;

namespace HelloWord.CommandAPDU
{
    public interface ICommandAPDUHeader
    {
        IBinary Header();
        IBinary CLA();
        IBinary INS();
        IBinary P1();
        IBinary P2();
        //IBinary Lc();
        //IBinary Data();
        //IBinary Le();
        //IBinary WithCLA(IBinary cla);
    }
}