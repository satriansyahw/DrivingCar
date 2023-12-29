using DrivingCar.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingCar.Domain.Commands
{
    public class LeftCommand : ICommand
    {
        public void Execute(Car car, Field field)
        {
            switch (car.Direction)
            {
                case 'N':
                    car.Direction = 'W';
                    break;
                case 'E':
                    car.Direction = 'N';
                    break;
                case 'S':
                    car.Direction = 'E';
                    break;
                case 'W':
                    car.Direction = 'S';
                    break;
                default:
                    throw new ArgumentException($"Invalid Direction: {car.Direction}");
            }
        }
    }
}
