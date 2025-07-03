namespace DocumentManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new App(new StorageProvider.CachedStorageProvider(), new EditorProvider.EditorProvider());
            app.Run();
        }

        
    }
}
