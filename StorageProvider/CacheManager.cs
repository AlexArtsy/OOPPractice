using Core.Enums;
using Core.Interfaces;

namespace StorageProvider
{
    internal class CacheManager
    {
        public List<IDocument> Documents { get; set; } = [];

        public void AddDocument(IDocument document)
        {
            // TODO: сделать проверку на наличие похожего документа
            Documents.Add(document);

            Console.WriteLine(string.Format("Документ {0} добавлен в кеш приложения", document.Name));
        }
    }
}
