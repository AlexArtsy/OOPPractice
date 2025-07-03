using Core.Enums;
using Core.Interfaces;

namespace DocumentManager
{
    public class СacheManager
    {
        public List<IDocument> Documents { get; set; } = [];

        public void AddDocument(IDocument document)
        {
            // TODO: сделать проверку на наличие похожего документа
            Documents.Add(document);

            Console.WriteLine(String.Format("Документ {0} добавлен в кеш приложения", document.Name));
        }

        public bool TryGetDocument(string name, ContentFormat format, out IDocument document)
        {
            document = this.Documents.FirstOrDefault(doc =>
                doc.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                doc.Format.Equals(format));

            return document != null;
        }
    }
}
