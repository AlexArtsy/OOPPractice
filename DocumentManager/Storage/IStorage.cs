using DocumentManager.Document;

namespace DocumentManager.Storage
{
    public interface IStorage
    {
        public StorageType Type { get; set; }
        public List<IDocument> Documents { get; set; }
        public IDocument GetDocument(string docName, ContentFormat format);
        public void AddDocument(IDocument document);
        public void RemoveDocument(IDocument document);
    }
}
