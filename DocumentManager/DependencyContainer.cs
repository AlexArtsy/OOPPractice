using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentManager
{
    internal class DependencyContainer
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //  Если вдруг не нужно кешировать
            //services.AddSingleton<IStorageProvider, StorageProvider.StorageProvider>();

            services.AddSingleton<IStorageProvider, StorageProvider.CachedStorageProvider>();
            services.AddScoped<IEditorProvider, EditorProvider.EditorProvider>();

            services.AddTransient<App>();

            return services.BuildServiceProvider();
        }
    }
}
