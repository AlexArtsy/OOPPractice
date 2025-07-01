using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManager
{
    internal class Document : IDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ContentFormat Format { get; set; }
        public IEnumerable<byte> Content { get; set; } = [];

        public Document(string name, ContentFormat format)
        {
            this.Id = new Guid();
            this.Name = name;
            this.Format = format;
        }
    }
}
