using DataAceess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaMishaVisage
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            serviceCollection
                .AddSingleton(configurationBuilder.Build().Get<DatabaseConfiguration>())
                .AddSingleton<EventsService>()
                .AddSingleton<PowerPlantsService>()
                .AddSingleton<CountriesService>()
                .AddSingleton<ContinentsService>()
                .AddTransient<MainForm>();

            using var sp = serviceCollection.BuildServiceProvider();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(sp.GetRequiredService<MainForm>());
        }
    }
}
