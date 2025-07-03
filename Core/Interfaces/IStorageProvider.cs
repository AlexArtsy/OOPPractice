using Core.Enums;

namespace Core.Interfaces
{
    public interface IStorageProvider
    {
        public IStorage GetStorage(StorageType type);
    }
}
