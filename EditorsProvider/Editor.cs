using Core.Enums;
using Core.Interfaces;

namespace EditorProvider
{
    public abstract class Editor : IEditor
    {
        public ContentFormat EditorType { get; set; }
        public abstract void OpenDocument(IDocument document);
        public abstract void SaveDocument(IDocument document);
        public abstract void CloseDocument(IDocument document);
    }
}
