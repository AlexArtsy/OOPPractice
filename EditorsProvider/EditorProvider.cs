using Core.Enums;
using Core.Interfaces;

namespace EditorsProvider
{
    public static class EditorProvider
    {
        public static IEditor GetEditor(IDocument document)
        {
            switch (document.Format)
            {
                case ContentFormat.Doc:
                    return new DocEditor();
                case ContentFormat.Txt:
                    return new TxtEditor();
                default:
                    throw new Exception(string.Format("Неизвестный формат файла: {0}", document.Format));
            }
        }
    }
}
