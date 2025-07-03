using Core.Enums;
using Core.Interfaces;

namespace Core.Models
{
    public class Document : IDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ContentFormat Format { get; set; }
        public IEnumerable<byte> Content { get; set; } = [];

        public Document(string name, ContentFormat format)
        {
            Id = new Guid();
            Name = name;
            Format = format;
        }
    }
}
