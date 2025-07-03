using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Core.Interfaces;

namespace EditorProvider
{
    public class TxtEditorProvider : EditorProvider
    {
        public override IEditor GetEditor()
        {
            return new TxtEditor();
        }

        private class TxtEditor : Editor, IEditor
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

            public TxtEditor()
            {
                EditorType = ContentFormat.Txt;
            }
        }
    }
}
