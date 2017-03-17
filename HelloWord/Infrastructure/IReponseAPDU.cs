namespace HelloWord.Infrastructure
{
    public interface IResponseAPDU
    {
        IBinary Body();
        IBinary Trailer();
    }
}