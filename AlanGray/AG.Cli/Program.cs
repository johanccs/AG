using AG.Data.Contracts;
using AG.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace AG.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.RegisterServices();

            var serviceProvider = services.BuildServiceProvider();

            var tweetManager = serviceProvider.GetService<ITweetManager>();

            tweetManager.Run();
        }
    }
}
