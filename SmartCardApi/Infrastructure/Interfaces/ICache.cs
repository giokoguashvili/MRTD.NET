namespace SmartCardApi.Infrastructure.Interfaces
{
    public interface ICache<out TResult>
    {
        TResult Content();
    }

    public interface ICache<in TInput, out TResult>
    {
        TResult Content(TInput input);
    }
}