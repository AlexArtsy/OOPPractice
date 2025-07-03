using Core.Enums;
using Core.Interfaces;

namespace StorageProvider
{
    /// <summary>
    /// Декоратор над StorageProvider
    /// </summary>
    public class CachedStorageProvider : IStorageProvider
    {
        private CachedStorage CachedStorage = new CachedStorage();
        public IStorage GetStorage(StorageType type)
        {
            var storage = new StorageProvider().GetStorage(type);

            this.CachedStorage.Storage = storage;
            this.CachedStorage.Type = storage.Type;

            return this.CachedStorage;
        }
    }
}
