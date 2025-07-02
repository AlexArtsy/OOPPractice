using DocumentManager.Document;

namespace DocumentManager.Editors
{
    public interface IEditor
    {
        public ContentFormat EditorType { get; set; }
        public abstract void OpenDocument(IDocument document);
        public abstract void SaveDocument(IDocument document);
        public abstract void CloseDocument(IDocument document);
    }
}
