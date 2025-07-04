﻿using Core.Enums;
using Core.Interfaces;

namespace StorageProvider
{
    public class StorageProvider : IStorageProvider
    {
        public IStorage GetStorage(StorageType type)
        {
            switch (type)
            {
                case StorageType.S3:
                    return new S3Storage();
                case StorageType.Sql:
                    return new SqlStorage();
                default:
                    throw new Exception(string.Format("Неизвестный тип хранилища: {0}", type));
            }
        }
    }
}
