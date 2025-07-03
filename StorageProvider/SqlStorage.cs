using Core.Enums;
using Core.Interfaces;

namespace StorageProvider
{
    internal class SqlStorage : Storage
    {
        public override IDocument GetDocument(string docName, ContentFormat format)
        {
            //  Тут какая-то особая логика работы с SQL-хранилищем
            try
            {
                return documents.Single(d => d.Name.Equals(docName) && d.Format.Equals(format));
            }
            catch (InvalidOperationException e)
            {
                throw new FileNotFoundException("Такого файла не существует в хранилище");
            }
        }

        public override void AddDocument(IDocument document)
        {
            //  Тут какая-то особая логика работы с SQL-хранилищем
            documents.Add(document);
            Console.WriteLine(string.Format("Документ {0} добавлен в хранилище {1}", document.Name, Type));
        }

        public override void RemoveDocument(IDocument document)
        {
            //  Тут какая-то особая логика работы с SQL-хранилищем
            documents.Remove(document);
            Console.WriteLine(string.Format("Документ {0} удален из хранилища {1}", document.Name, Type));
        }

        public SqlStorage()
        {
            Type = StorageType.Sql;
        }
    }
}
