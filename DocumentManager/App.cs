using Core.Enums;
using Core.Interfaces;
using Core.Utilities;

namespace DocumentManager
{
    public class App
    {
        public IEditorProvider EditorProvider { get; set; }
        public IStorageProvider StorageProvider { get; set; }

        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите хранилище:");
                    var storage = SelectStorage();

                    Console.WriteLine("Введите формат файла:");
                    var docFormat = ContentFormatParser.Parse(Console.ReadLine());

                    Console.WriteLine("Введите имя файла:");
                    var docName = Console.ReadLine() ?? "";

                    var doc = LoadDocument(docName, docFormat, storage);

                    //  HACK: например, пусть будет такой путь.
                    var path = "D://Documents";

                    SaveDocument(doc, path);
                    OpenDocument(EditorProvider.GetEditor(doc), doc, path);


                    Console.WriteLine();
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Повторите ввод.\n");
                    continue;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Повторите ввод.\n");
                    continue;
                }
            }
        }

        private IStorage SelectStorage()
        {
            Console.WriteLine("1. SQL-хранилище");
            Console.WriteLine("2. S3-хранилище");


            switch (Console.ReadLine())
            {
                case "1":
                    return StorageProvider.GetStorage(StorageType.Sql);
                case "2":
                    return StorageProvider.GetStorage(StorageType.S3);
                default:
                    Console.WriteLine("Ошибка! Нужно ввести число, соответствующее типу хранилища!");
                    return SelectStorage();
            }
        }

        private static IDocument LoadDocument(string docName, ContentFormat docFormat, IStorage storage)
        {
            return storage.GetDocument(docName, docFormat);
        }

        private static void SaveDocument(IDocument document, string path)
        {
            Console.WriteLine(String.Format("Документ {0} сохранен в директории: {1}", document.Name, path));
        }

        private static void OpenDocument(IEditor editor, IDocument document, string path)
        {
            editor.OpenDocument(document);
            CheckEditorState(editor);
        }

        private static void CheckEditorState(IEditor editor)
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine(String.Format("Ожидание завершения приложения {0}-редактор", editor.EditorType));
                Thread.Sleep(1000);
            }

            Console.WriteLine(String.Format("Работа приложения {0}-редактор завершена", editor.EditorType));
        }

        public App(IStorageProvider storageProvider, IEditorProvider editorProvider)
        {
            this.StorageProvider = storageProvider;
            this.EditorProvider = editorProvider;
        }
    }
}
