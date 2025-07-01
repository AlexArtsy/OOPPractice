using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManager
{
    internal class IDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ContentFormat format { get; set; }
        public IEnumerable<byte> Content { get; set; } = [];

    }
}
