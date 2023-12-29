using DrivingCar.Domain.Services;
using DrivingCar.Domain.Shared;

namespace DrivingCar.UnitTest.Domain.Services
{
    [TestClass]
    public class DrivingCarServiceTest
    {
        DrivingCarService drivingCarService = new DrivingCarService(); 
        [TestMethod]
        [DataRow('N', 'W')]
        [DataRow('W', 'S')]
        [DataRow('S', 'E')]
        [DataRow('E', 'N')]
        public void Test_Positive_Given_Direction_L_Return_NewDirection(char direction, char expected)
        {
            Car car = new Car();
            car.X = 1;
            car.Y = 2;
            car.Direction = direction;
            Field field = new Field(10, 10);
            drivingCarService.ExecuteCommands(car, field, "L");
            Assert.AreEqual(expected, car.Direction);
        }
        [TestMethod]
        [DataRow('N', 'E')]
        [DataRow('E', 'S')]
        [DataRow('S', 'W')]
        [DataRow('W', 'N')]
        public void Test_Positive_Given_Direction_R_Return_NewDirection(char direction, char expected)
        {
            Car car = new Car();
            car.X = 1;
            car.Y = 2;
            car.Direction = direction;
            Field field = new Field(10, 10);
            drivingCarService.ExecuteCommands(car, field, "R");
            Assert.AreEqual(expected, car.Direction);
        }
        [TestMethod]
        [DataRow('N', 0, 6, 10, 10, 7)]
        [DataRow('S', 0, 7, 10, 10, 6)]
        public void Test_PositiveForDirectionNS_Given_Coordinate_Return_NewCoordinate(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            drivingCarService.ExecuteCommands(car, field, "F");
            Assert.AreEqual(expected, car.Y);
        }
        [TestMethod]
        [DataRow('E', 1, 6, 10, 10, 2)]
        [DataRow('W', 6, 0, 10, 10, 5)]
        public void Test_PositiveForDirectionEW_Given_Coordinate_Return_NewCoordinate(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            drivingCarService.ExecuteCommands(car, field, "F");
            Assert.AreEqual(expected, car.X);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow('X')]
        public void Test_Negative_GivenWrongDirection_Return_ArgumentException(char direction)
        {
            Car car = new Car();
            car.X = 1;
            car.Y = 2;
            car.Direction = direction;
            Field field = new Field(10, 10);
            drivingCarService.ExecuteCommands(car, field, "R");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Negative_GivenWrongCommands_Return_ArgumentException()
        {
            Car car = new Car();
            car.X = 1;
            car.Y = 2;
            car.Direction = 'N';
            Field field = new Field(10, 10);
            drivingCarService.ExecuteCommands(car, field, "X");
        }
    }
}
