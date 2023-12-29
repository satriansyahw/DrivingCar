using DrivingCar.Application.Interfaces;
using DrivingCar.Infrastructure;
using DrivingCar.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DrivingCar.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            int maxRetry = 3, retryCount = 1;
            int fieldWidth = 0, fieldHeight = 0, initialX = 0, initialY = 0;
            string input = string.Empty;
            bool correctInput = false;
            char direction = char.MinValue;

            var serviceProvider = CompositionRoot.Configure();
            var drivingCarAppService = serviceProvider.GetService<IDrivingCarAppService>();
            var log = serviceProvider.GetService<ILogger>();
            while (true)
            {
                Retry:
                Console.WriteLine("\nEnter 3 Lines for DrivingCar Simulation Input : ");
                input = Console.ReadLine().Trim();
                while (input.Split(' ').Length != 2 || !int.TryParse(input.Split(' ')[0], out fieldWidth) || !int.TryParse(input.Split(' ')[1], out fieldHeight))
                {
                    log.LogInfo($"Invalid input for field Width & Height :  {input}");
                    goto Retry;
                }
                input = Console.ReadLine().Trim();
                while (input.Split(' ').Length != 3 || !int.TryParse(input.Split(' ')[0], out initialX) || !int.TryParse(input.Split(' ')[1], out initialY)
                    || !char.TryParse(input.Split(' ')[2], out direction))
                {
                    log.LogInfo($"Invalid input for current Position(X,Y,Direction) : {input}");
                    goto Retry;
                }
                var commands = Console.ReadLine();
                try
                {
                    var result = drivingCarAppService.CarMovement(fieldWidth, fieldHeight, initialX, initialY, direction, commands);
                    Console.WriteLine($"{result.FinalX} {result.FinalY} {result.FinalDirection}");
                }catch(Exception ex)
                {
                    log.LogError($"Error: CarMovement ", ex);
                }
            }
        }
    }
}