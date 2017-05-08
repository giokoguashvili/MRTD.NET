using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging.DataObjects
{
    public interface IDataObject
    {
        IBinary EncryptedData();
    }
}
