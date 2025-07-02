using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManager.Document;

namespace DocumentManager.Storage
{
    internal class SqlStorage : Storage
    {
        public override IDocument GetDocument(string docName, ContentFormat format)
        {
            //  Тут какая-то особая логика работы с SQL-хранилищем
            try
            {
                return this.Documents.Single(d => d.Name.Equals(docName) && d.Format.Equals(format));
            }
            catch (InvalidOperationException e)
            {
                throw new FileNotFoundException("Такого файла не существует в хранилище");
            }
        }

        public override void AddDocument(IDocument document)
        {
            //  Тут какая-то особая логика работы с SQL-хранилищем
            this.Documents.Add(document);
            Console.WriteLine(string.Format("Документ {0} добавлен в хранилище {1}", document.Name, this.Type));
        }

        public override void RemoveDocument(IDocument document)
        {
            //  Тут какая-то особая логика работы с SQL-хранилищем
            this.Documents.Remove(document);
            Console.WriteLine(string.Format("Документ {0} удален из хранилища {1}", document.Name, this.Type));
        }

        public SqlStorage()
        {
            this.Type = StorageType.Sql;
        }
    }
}
