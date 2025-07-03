using Core.Enums;

namespace Core.Interfaces
{
    public interface IStorage
    {
        public StorageType Type { get; set; }
        public IDocument GetDocument(string docName, ContentFormat format);
        public void AddDocument(IDocument document);
        public void RemoveDocument(IDocument document);
    }
}
