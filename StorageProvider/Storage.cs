using Core.Enums;
using Core.Interfaces;
using Core.Models;

namespace StorageProvider
{
    public abstract class Storage : IStorage
    {
        public StorageType Type { get; set; }
        public List<IDocument> Documents { get; set; } = [];
        public abstract IDocument GetDocument(string docName, ContentFormat format);
        public abstract void AddDocument(IDocument document);
        public abstract void RemoveDocument(IDocument document);

        public Storage()
        {
            //  HACK: Просто заполнение документами
            Documents.Add(new Document("Вордовский документ 1", ContentFormat.Doc));
            Documents.Add(new Document("Вордовский документ 2", ContentFormat.Doc));
            Documents.Add(new Document("Вордовский документ 3", ContentFormat.Doc));
            Documents.Add(new Document("Текстовый документ", ContentFormat.Txt));
            Documents.Add(new Document("Rtf документ", ContentFormat.Rtf));
            Documents.Add(new Document("Fm1 документ", ContentFormat.Fm1));
        }
    }
}
