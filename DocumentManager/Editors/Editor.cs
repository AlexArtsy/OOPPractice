using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManager.Document;

namespace DocumentManager.Editors
{
    public abstract class Editor : IEditor
    {
        public ContentFormat EditorType { get; set; }
        public abstract void OpenDocument(IDocument document);
        public abstract void SaveDocument(IDocument document);
        public abstract void CloseDocument(IDocument document);
    }
}
