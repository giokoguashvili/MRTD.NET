namespace HelloWord.ApduCommandsResponses
{
    public interface IResponseStatus
    {
        bool Ok();
        string ErrorMessage();
    }
}