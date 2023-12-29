using DrivingCar.Application.DTOs;

namespace DrivingCar.Application.Services
{
    public interface IDrivingCarAppService
    {
        CarMovementResultDto CarMovement(int fieldWidth, int fieldHeight, int initialX, int initialY, char initialDirection, string commands);
    }
}
