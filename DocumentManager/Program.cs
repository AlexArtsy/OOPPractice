using System.Net.WebSockets;
using DocumentManager.Storage;

namespace DocumentManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, выберите хранилище:");


            var storage = SelectStorage();
        }

        private static IStorage SelectStorage()
        {
            Console.WriteLine("1. SQL-хранилище");
            Console.WriteLine("2. S3-хранилище");


            switch (Console.ReadLine())
            {
                case "1":
                    return new S3StorageProvider();
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Ошибка! Нужно ввести число, соответствующее типу хранилища!");
                    return SelectStorage();
            }
        }

        private static void SelectFile()
        {

        }
    }
}
