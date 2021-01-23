using System;
using System.Text.RegularExpressions;
using CandidateTesting.WythorFerreiraBazan.iTaaS.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS
{
    class Program
    {
        static void Main(string[] args)
        {
            // I opted for this 'try-catch', because the arguments may not come, so I validate here.
            try
            {
                // Configurating our container of dependency inversion.
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();

                var _scrapeService = serviceProvider.GetService<IScrapeServices>();
                var _convertService = serviceProvider.GetService<IConvertServices>();

              
                MatchCollection log = _scrapeService.GetLogFile(args[0]);
                _convertService.ConvertFile(log,args[1]);
            }
            catch(IndexOutOfRangeException)
            {
                 throw new Exception("Missing one or more arguments on command line!");
            }
            catch(Exception e)
            {
                throw new Exception("Something went wrong: "+e.Message);
            }
        }

        // I opted for a dependency injection container, because I dont wanna to depend of implementations.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IScrapeServices,ScrapeService>()
                .AddScoped<IConvertServices, ConvertService>();
        }
    }
}
