using DrivingCar.Application;
using DrivingCar.Application.DTOs;
using DrivingCar.Application.Services;
using DrivingCar.Domain.Services;
using DrivingCar.Domain.Shared;

namespace AutoCarSimulation.Application
{
    [TestClass]
    public class DrivingCarAppServiceTest
    {
        IDrivingCarAppService autoDrivingCarAppService = new DrivingCarAppService(new DrivingCarService());
        
        [TestMethod]
        [DataRow('N', 'W')]
        [DataRow('W', 'S')]
        [DataRow('S', 'E')]
        [DataRow('E', 'N')]
        public void Test_Positive_Given_LeftCommand_Return_CorrectDirection(char direction,char expected)
        {
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(0, 0, 0, 0, direction, "L");
            Assert.AreEqual(resultDto.FinalDirection, expected);
        }
        [TestMethod]
        [DataRow('N', 'E')]
        [DataRow('E', 'S')]
        [DataRow('S', 'W')]
        [DataRow('W', 'N')]
        public void Test_Positive_Given_RightCommand_Return_CorrectDirection(char direction, char expected)
        {
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(0, 0, 0, 0, direction, "R");
            Assert.AreEqual(resultDto.FinalDirection, expected);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow('X',"L")]
        [DataRow('X', "R")]
        [DataRow('X', "F")]
        public void Test_Negative_Given_L_or_R_or_F_CommandWrongDirection_Return_ArgumentException(char direction, string command)
        {
            Car car = new Car();
            car.X = 1;
            car.Y = 2;
            car.Direction = direction;
            Field field = new Field(10, 10);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(0, 0, 0, 0, direction,command);
        }
        [TestMethod]
        [DataRow('N', 0, 6, 10, 10, 7)]
        [DataRow('S', 0, 7, 10, 10, 6)]
        public void Test_PositiveForDirectionNS_Given_ForwardCommand_Return_NewCoordinateFinalY(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight,posWidth,posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalY, expected);
        }
        [TestMethod]
        [DataRow('N', 0, 10, 10, 10, 10)]
        [DataRow('N', 0, 11, 10, 10, 10)]
        public void Test_PositiveForDirectionN_Given_ForwardCommand_OutOfBoundaryMoreThanOrEqualFieldHeight_Return_FieldHeightFinalY(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalY, expected);
        }
        [TestMethod]
        [DataRow('N', 0, -1, 10, 10, 1)]
        [DataRow('N', 0, 0, 10, 10, 1)]
        public void Test_PositiveForDirectionN_Given_ForwardCommand_OutOfBoundaryLessThanZeroOrEqualZero_Return_OneFinalY(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalY, expected);
        }
        [TestMethod]
        [DataRow('S', 0, 11, 10, 10, 9)]
        [DataRow('S', 0, 10, 10, 10, 9)]
        public void Test_PositiveForDirectionS_Given_ForwardCommand_OutOfBoundaryMoreThanOrEqualFieldHeight_Return_fieldHeightSubtractOneFinalY(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalY, expected);
        }
        [TestMethod]
        [DataRow('S', 0, -1, 10, 10, 0)]
        [DataRow('S', 0, 0, 10, 10, 0)]
        public void Test_PositiveForDirectionS_Given_ForwardCommand_OutOfBoundaryLessThanZeroOrEqualZero_Return_ZeroFinalY(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalY, expected);
        }
        [TestMethod]
        [DataRow('E', 1, 6, 10, 10, 2)]
        [DataRow('W', 6, 0, 10, 10, 5)]
        public void Test_PositiveForDirectionEW_Given_ForwardCommand_Coordinate_Return_NewWidthCoordinateFinalX(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalX, expected);
        }
        [TestMethod]
        [DataRow('E', -2, 9, 10, 10, 1)]
        [DataRow('E', 0, 9, 10, 10, 1)] 
        public void Test_PositiveForDirectionE_Given_ForwardCommand_OutOfBoundaryLessThanOrEqualZero_Return_ZeroFinalX(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalX, expected);
        }
        [TestMethod]
        [DataRow('E', 10, 9, 10, 10, 10)]
        [DataRow('E', 11, 9, 10, 10, 10)]
        public void Test_PositiveForDirectionE_Given_ForwardCommand_OutOfBoundaryLessMoreThanOrEqualFieldWidth_Return_FieldWidthFinalX(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalX, expected);
        }
        [TestMethod]
        [DataRow('W', 0, 9, 10, 10, 0)]
        [DataRow('W', -1, 9, 10, 10, 0)]
        public void Test_PositiveForDirectionW_Given_ForwardCommand_OutOfBoundaryLessThanOrEqualZero_Return_ZeroFinalX(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalX, expected);
        }
        [TestMethod]
        [DataRow('W', 10, 9, 10, 10, 9)]
        [DataRow('W', 11, 9, 10, 10, 9)]
        public void Test_PositiveForDirectionW_Given_ForwardCommand_OutOfBoundaryLessMoreThanOrEqualFieldWidth_Return_FieldWidthSubtractOneFinalX(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            CarMovementResultDto resultDto = autoDrivingCarAppService.CarMovement(fieldWidth, fieldHeight, posWidth, posHeight, direction, "F");
            Assert.AreEqual(resultDto.FinalX, expected);
        }
    }
}
