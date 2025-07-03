using Core.Enums;
using Core.Interfaces;

namespace StorageProvider
{
    public class S3Storage : Storage
    {
        public override IDocument GetDocument(string docName, ContentFormat format)
        {
            //  Тут какая-то особая логика работы с S3-хранилищем
            try
            {
                return Documents.Single(d => d.Name.Equals(docName) && d.Format.Equals(format));
            }
            catch (InvalidOperationException e)
            {
                throw new FileNotFoundException("Такого файла не существует в хранилище");
            }
        }

        public override void AddDocument(IDocument document)
        {
            //  Тут какая-то особая логика работы с S3-хранилищем
            Documents.Add(document);
            Console.WriteLine(string.Format("Документ {0} добавлен в хранилище {1}", document.Name, Type));
        }

        public override void RemoveDocument(IDocument document)
        {
            //  Тут какая-то особая логика работы с S3-хранилищем
            Documents.Remove(document);
            Console.WriteLine(string.Format("Документ {0} удален из хранилища {1}", document.Name, Type));
        }

        public S3Storage()
        {
            Type = StorageType.S3;
        }
    }
}
