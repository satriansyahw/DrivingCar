using DrivingCar.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingCar.Domain.Commands
{
    public interface ICommand
    {
        void Execute(Car car, Field field);
    }
}
