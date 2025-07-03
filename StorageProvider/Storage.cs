using Core.Enums;
using Core.Interfaces;
using Core.Models;

namespace StorageProvider
{
    public abstract class Storage : IStorage
    {
        protected List<IDocument> documents = [];

        public StorageType Type { get; set; }
        public abstract IDocument GetDocument(string docName, ContentFormat format);
        public abstract void AddDocument(IDocument document);
        public abstract void RemoveDocument(IDocument document);

        public Storage()
        {
            //  HACK: Просто заполнение документами
            documents.Add(new Document("Вордовский документ 1", ContentFormat.Doc));
            documents.Add(new Document("Вордовский документ 2", ContentFormat.Doc));
            documents.Add(new Document("Вордовский документ 3", ContentFormat.Doc));
            documents.Add(new Document("Текстовый документ", ContentFormat.Txt));
            documents.Add(new Document("Rtf документ", ContentFormat.Rtf));
            documents.Add(new Document("Fm1 документ", ContentFormat.Fm1));
        }
    }
}
