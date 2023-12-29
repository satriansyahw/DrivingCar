using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingCar.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        public void LogError(string message, Exception exception)
        {
            Console.WriteLine(($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} ERROR : {message}\nException: {exception}"));
        }
        public void LogInfo(string message)
        {
            Console.WriteLine(($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}{message}"));
        }
    }
}
