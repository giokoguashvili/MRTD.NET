using HelloWord.Cryptography;

namespace HelloWord.ApduCommandsResponses
{
    public interface IApduCommandResponse
    {
        IResponseStatus Status();
        IBinary Data();
    }
}