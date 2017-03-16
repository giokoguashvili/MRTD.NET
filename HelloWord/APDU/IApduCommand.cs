namespace HelloWord.ApduCommands
{
    public interface IApduCommand
    {
        byte SW1();
        byte SW2();


        byte[] Data();
    }
}