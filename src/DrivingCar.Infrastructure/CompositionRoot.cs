using DrivingCar.Application.Interfaces;
using DrivingCar.Application.Services;
using DrivingCar.Domain.Services;
using DrivingCar.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DrivingCar.Infrastructure
{
    public class CompositionRoot
    {
        public static ServiceProvider Configure()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<DrivingCarService>()
                .AddTransient<IDrivingCarAppService, DrivingCarAppService>()
                .AddSingleton<ILogger, Logger>()
                .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
