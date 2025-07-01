namespace DocumentManager
{
    internal static class StorageProvider
    {
        public static IStorage GetStorage(StorageType type)
        {
            switch(type)
            {
                case StorageType.S3:
                    return new S3Storage();
                case StorageType.Sql:
                    break;
                default:
                    throw new Exception(String.Format("Неизвестный тип хранилища: {0}", type));
            }
        }
    }
}
