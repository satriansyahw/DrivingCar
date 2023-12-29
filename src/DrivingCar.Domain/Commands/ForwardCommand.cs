using DrivingCar.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingCar.Domain.Commands
{
    public class ForwardCommand : ICommand
    {
        public void Execute(Car car, Field field)
        {
            this.CheckingBoundary(car, field);
            switch (car.Direction)
            {
                case 'N':
                    if (car.Y < field.Height)
                        car.Y++;
                    break;
                case 'E':
                    if (car.X < field.Width)
                        car.X++;
                    break;
                case 'S':
                    if (car.Y > 0)
                        car.Y--;
                    break;
                case 'W':
                    if (car.X > 0)
                        car.X--;
                    break;
                default:
                    throw new ArgumentException($"Invalid Direction: {car.Direction}");
            }
        }
        private void CheckingBoundary(Car car, Field field)
        {
            if (car.X < 0) car.X = 0;
            if (car.Y < 0) car.Y = 0;
            if (car.X > field.Width) car.X = field.Width;
            if (car.Y > field.Height) car.Y = field.Height;
        }
    }
}
