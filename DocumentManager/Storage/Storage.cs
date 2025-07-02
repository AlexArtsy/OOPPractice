using DocumentManager.Document;

namespace DocumentManager.Storage
{
    internal abstract class Storage : IStorage
    {
        public StorageType Type { get; set; }
        public List<IDocument> Documents { get; set; } = [];
        public abstract IDocument GetDocument(string docName, ContentFormat format);
        public abstract void AddDocument(IDocument document);
        public abstract void RemoveDocument(IDocument document);

        public Storage()
        {
            this.Documents.Add(new Document.Document("Вордовский документ 1", ContentFormat.Doc));
            this.Documents.Add(new Document.Document("Вордовский документ 2", ContentFormat.Doc));
            this.Documents.Add(new Document.Document("Вордовский документ 3", ContentFormat.Doc));
            this.Documents.Add(new Document.Document("Текстовый документ", ContentFormat.Txt));
            this.Documents.Add(new Document.Document("Rtf документ", ContentFormat.Rtf));
            this.Documents.Add(new Document.Document("Fm1 документ", ContentFormat.Fm1));
        }
    }
}
