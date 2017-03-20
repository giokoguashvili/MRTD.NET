namespace HelloWord.Infrastructure
{
    public interface ICommandHeader
    {
        IBinary Header();
        IBinary CLA();
        IBinary INS();
        IBinary P1();
        IBinary P2();
        IBinary WithCLA(IBinary cla);
    }
}