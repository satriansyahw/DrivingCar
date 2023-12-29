using DrivingCar.Domain.Commands;
using DrivingCar.Domain.Shared;

namespace DrivingCar.UnitTest.Domain
{
    [TestClass]
    public class LeftCommandTest
    {
        ICommand command = new LeftCommand();

        [TestMethod]
        [DataRow('N', 'W')]
        [DataRow('W', 'S')]
        [DataRow('S', 'E')]
        [DataRow('E', 'N')]
        public void Test_Positive_Given_Direction_ReturnDirection(char direction, char expected)
        {
            Car car = new Car();
            car.X = 1;
            car.Y = 2;
            car.Direction = direction;
            Field field = new Field(10, 10);
            command.Execute(car, field);
            Assert.AreEqual(expected,car.Direction) ;
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
            command.Execute(car, field);
        }
      }

}
