using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging.DataObjects
{
    public interface IDataObject
    {
        IBinary EncryptedData();
    }
}
