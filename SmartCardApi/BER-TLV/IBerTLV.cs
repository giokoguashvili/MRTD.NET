using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

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
