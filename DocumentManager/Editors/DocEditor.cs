using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManager.Document;

namespace DocumentManager.Editors
{
    public class DocEditor : Editor
    {
        public override void OpenDocument(IDocument document)
        {
            Console.WriteLine(String.Format("Документ {0} открыт в {1}-редакторе", document.Name, this.EditorType));
        }
        public override void SaveDocument(IDocument document)
        {
            Console.WriteLine(String.Format("Документ {0} сохранен {1}-редактором", document.Name, this.EditorType));
        }
        public override void CloseDocument(IDocument document)
        {
            Console.WriteLine(String.Format("{0}-редактор освободил документ {1}", this.EditorType, document.Name));
        }

        public DocEditor()
        {
            this.EditorType = ContentFormat.Doc;
        }
    }
}
