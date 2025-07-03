using Core.Enums;
using Core.Interfaces;

namespace EditorProvider
{
    public class DocEditorProvider : EditorProvider
    {
        public override IEditor GetEditor()
        {
            return new DocEditor();
        }

        private class DocEditor : Editor, IEditor
        {
            public override void OpenDocument(IDocument document)
            {
                Console.WriteLine(string.Format("Документ {0} открыт в {1}-редакторе", document.Name, EditorType));
            }
            public override void SaveDocument(IDocument document)
            {
                Console.WriteLine(string.Format("Документ {0} сохранен {1}-редактором", document.Name, EditorType));
            }
            public override void CloseDocument(IDocument document)
            {
                Console.WriteLine(string.Format("{0}-редактор освободил документ {1}", EditorType, document.Name));
            }

            public DocEditor()
            {
                this.EditorType = ContentFormat.Doc;
            }
        }
    }
}
