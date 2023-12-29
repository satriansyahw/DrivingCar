using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingCar.Infrastructure.Logging
{
    public interface ILogger
    {
        void Info(string message);
    }
}
