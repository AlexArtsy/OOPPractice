using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManager.Document;

namespace DocumentManager.Document
{
    public interface IDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ContentFormat Format { get; set; }
        public IEnumerable<byte> Content { get; set; }

    }
}
