using Core.Interfaces;

namespace EditorProvider
{
    public abstract class EditorProvider : IEditorProvider
    {
        public abstract IEditor GetEditor();

        public void OpenDocument(IDocument document)
        {
            IEditor editor = this.GetEditor();
            editor.OpenDocument(document);
        }
        public void SaveDocument(IDocument document)
        {
            IEditor editor = this.GetEditor();
            editor.SaveDocument(document);
        }
        public void CloseDocument(IDocument document)
        {
            IEditor editor = this.GetEditor();
            editor.CloseDocument(document);
        }
    }
}
