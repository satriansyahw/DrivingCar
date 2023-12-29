using DrivingCar.Domain.Commands;
using DrivingCar.Domain.Shared;

namespace DrivingCar.Domain.Services
{
    public class DrivingCarService
    {
        public void ExecuteCommands(Car car, Field field, string commands)
        {
            foreach (char command in commands)
            {
                ICommand commandObj;
                switch (command)
                {
                    case 'L':
                        commandObj = new LeftCommand();
                        break;
                    case 'R':
                        commandObj = new RightCommand();
                        break;
                    case 'F':
                        commandObj = new ForwardCommand();
                        break;
                    default:
                        throw new ArgumentException($"Invalid command: {command}");
                }

                commandObj.Execute(car, field);
            }
        }
    }
}
