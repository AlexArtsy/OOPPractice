using Core.Enums;
using Core.Interfaces;

namespace StorageProvider
{
    /// <summary>
    /// Декоратор над Storage
    /// </summary>
    internal class CachedStorage : Storage
    {
        public IStorage Storage { get; set; }
        public CacheManager Cache { get; }

        public override IDocument GetDocument(string docName, ContentFormat format)
        {
            if (TryGetDocumentFromCache(docName, format, out IDocument document))
            {
                Console.WriteLine(String.Format("Документ {0} прочитан из кеша приложения", document.Name));
                return document;
            }

            var notChachedDocument = this.Storage.GetDocument(docName, format);
            Cache.AddDocument(notChachedDocument);

            Console.WriteLine(String.Format("Документ {0} прочитан из {1}-хранилища", notChachedDocument.Name, this.Storage.Type));
            return notChachedDocument;
        }

        public override void AddDocument(IDocument document)
        {
            this.Storage.AddDocument(document);
        }

        public override void RemoveDocument(IDocument document)
        {
            this.Storage.RemoveDocument(document);
        }

        private bool TryGetDocumentFromCache(string name, ContentFormat format, out IDocument document)
        {
            document = this.Cache.Documents.FirstOrDefault(doc =>
                doc.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                doc.Format.Equals(format));

            return document != null;
        }

        public CachedStorage()
        {
            this.Cache = new CacheManager();
        }
    }
}
