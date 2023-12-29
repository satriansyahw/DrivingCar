
using DrivingCar.Application.DTOs;
using DrivingCar.Application.Services;
using DrivingCar.Domain.Services;
using DrivingCar.Domain.Shared;

namespace DrivingCar.Application
{
    public class DrivingCarAppService : IDrivingCarAppService
    {
        private readonly DrivingCarService autoDrivingCarService;

        public DrivingCarAppService(DrivingCarService autoDrivingCarService)
        {
            this.autoDrivingCarService = autoDrivingCarService;
        }

        public CarMovementResultDto CarMovement(int fieldWidth, int fieldHeight, int initialX, int initialY, char initialDirection, string commands)
        {
            Field field = new Field(fieldWidth, fieldHeight);
            Car car = new Car { X = initialX, Y = initialY, Direction = initialDirection };

            autoDrivingCarService.ExecuteCommands(car, field, commands);

            return new CarMovementResultDto
            {
                FinalX = car.X,
                FinalY = car.Y,
                FinalDirection = car.Direction
            };
        }
    }
}
