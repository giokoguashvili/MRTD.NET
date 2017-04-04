using SmartCardApi.Infrastructure;

namespace SmartCardApi
{
    public interface IBerTLV : IBinary
    {
        string T { get; }
        string L { get; }
        string V { get; }
        string TL { get; }
        IBerTLV[] Data { get; }
    }
}
