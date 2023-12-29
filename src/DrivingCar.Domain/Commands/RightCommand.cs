using DrivingCar.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingCar.Domain.Commands
{
    public class RightCommand : ICommand
    {
        public void Execute(Car car, Field field)
        {
            switch (car.Direction)
            {
                case 'N':
                    car.Direction = 'E';
                    break;
                case 'E':
                    car.Direction = 'S';
                    break;
                case 'S':
                    car.Direction = 'W';
                    break;
                case 'W':
                    car.Direction = 'N';
                    break;
                default:
                    throw new ArgumentException($"Invalid Direction: {car.Direction}");
            }

        }
    }
}
