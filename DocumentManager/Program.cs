using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection.Metadata;
using DocumentManager.Document;
using DocumentManager.Editors;
using DocumentManager.Storage;

namespace DocumentManager
{
    internal class Program
    {
        private static СacheManager Cache = new СacheManager();

        static void Main(string[] args)
        {
            RunApp();
        }

        private static void RunApp()
        {
            while(true)
            {
                //TODO попробовать сделать дженерик шаблонизатор провайдеров: эдитора, хранилища
                try
                {
                    Console.WriteLine("Выберите хранилище:");
                    var storage = SelectStorage();

                    Console.WriteLine("Введите формат файла:");
                    var docFormat = ContentFormatParser.Parse(Console.ReadLine());

                    Console.WriteLine("Введите имя файла:");
                    var docName = Console.ReadLine() ?? "";

                    var doc = LoadDocument(docName, docFormat, storage);

                    var path = "D://Documents";
                    SaveDocument(doc, path);
                    OpenDocument(doc, path);

                    Console.WriteLine();
                }
                catch(FileNotFoundException e)
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

        private static IStorage SelectStorage()
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
            if (Cache.TryGetDocument(docName, docFormat, out IDocument document))
            {
                Console.WriteLine(String.Format("Документ {0} прочитан из кеша приложения", document.Name));
                return document;
            }

            var notChachedDocument = storage.GetDocument(docName, docFormat);
            Cache.AddDocument(notChachedDocument);

            Console.WriteLine(String.Format("Документ {0} прочитан из {1}-хранилища", notChachedDocument.Name, storage.Type));
            return notChachedDocument;
        }

        private static void SaveDocument(IDocument document, string path)
        {
            Console.WriteLine(String.Format("Документ {0} сохранен в директории: {1}", document.Name, path));
        }

        private static void OpenDocument(IDocument document, string path)
        {
            IEditor editor = EditorProvider.GetEditor(document);
            editor.OpenDocument(document);

            CheckEditorState(editor);
        }

        private static void CheckEditorState(IEditor editor)
        {
            for(var i = 0; i < 3; i++)
            {
                Console.WriteLine(String.Format("Ожидание завершения приложения {0}-редактор", editor.EditorType));
                Thread.Sleep(1000);
            }

            Console.WriteLine(String.Format("Работа приложения {0}-редактор завершена", editor.EditorType));
        }
    }
}
