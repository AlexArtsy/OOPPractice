using Core.Enums;

namespace Core.Interfaces
{
    public interface IDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ContentFormat Format { get; set; }
        public IEnumerable<byte> Content { get; set; }

    }
}
