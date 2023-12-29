using DrivingCar.Domain.Commands;
using DrivingCar.Domain.Shared;

namespace DrivingCar.UnitTest.Domain.Commands
{
    [TestClass]
    public class ForwardCommandTest
    {
        ICommand command = new ForwardCommand();

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
            command.Execute(car, field);
            Assert.AreEqual(expected, car.Y);
        }
        [TestMethod]
        [DataRow('N', 0, 10, 10, 10, 10)]
        [DataRow('N', 0, 11, 10, 10, 10)]
        public void Test_PositiveForDirectionN_Given_OutOfBoundaryMoreThanOrEqualFieldHeight_Return_fieldHeight(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            command.Execute(car, field);
            Assert.AreEqual(expected, car.Y);
        }
        [TestMethod]
        [DataRow('N', 0, -1, 10, 10, 1)]
        [DataRow('N', 0, 0, 10, 10, 1)]
        public void Test_PositiveForDirectionN_Given_OutOfBoundaryLessThanZeroOrEqualZero_Return_One(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            command.Execute(car, field);
            Assert.AreEqual(expected, car.Y);
        }
        [TestMethod]
        [DataRow('S', 0, 11, 10, 10, 9)]
        [DataRow('S', 0, 10, 10, 10, 9)]
        public void Test_PositiveForDirectionS_Given_OutOfBoundaryMoreThanOrEqualFieldHeight_Return_fieldHeightSubtractOne(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            command.Execute(car, field);
            Assert.AreEqual(expected, car.Y);
        }
        [TestMethod]
        [DataRow('S', 0, -1, 10, 10, 0)]
        [DataRow('S', 0, 0, 10, 10, 0)]
        public void Test_PositiveForDirectionS_Given_OutOfBoundaryLessThanZeroOrEqualZero_Return_Zero(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            command.Execute(car, field);
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
            command.Execute(car, field);
            Assert.AreEqual(expected, car.X);
        }
        [TestMethod]
        [DataRow('E', -2, 9, 10, 10, 1)]
        [DataRow('E', 0, 9, 10, 10, 1)]
        public void Test_PositiveForDirectionE_Given_OutOfBoundaryLessThanOrEqualZero_Return_Zero(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            command.Execute(car, field);
            Assert.AreEqual(expected, car.X);
        }
        [TestMethod]
        [DataRow('E', 10, 9, 10, 10, 10)]
        [DataRow('E', 11, 9, 10, 10, 10)]
        public void Test_PositiveForDirectionE_Given_OutOfBoundaryLessMoreThanOrEqualFieldWidth_Return_FieldWidth(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            command.Execute(car, field);
            Assert.AreEqual(expected, car.X);
        }
        [TestMethod]
        [DataRow('W', 0, 9, 10, 10, 0)]
        [DataRow('W', -1, 9, 10, 10, 0)]
        public void Test_PositiveForDirectionW_Given_OutOfBoundaryLessThanOrEqualZero_Return_Zero(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            command.Execute(car, field);
            Assert.AreEqual(expected, car.X);
        }
        [TestMethod]
        [DataRow('W', 10, 9, 10, 10, 9)]
        [DataRow('W', 11, 9, 10, 10, 9)]
        public void Test_PositiveForDirectionW_Given_OutOfBoundaryLessMoreThanOrEqualFieldWidth_Return_FieldWidthSubtractOne(char direction, int posWidth, int posHeight, int fieldWidth, int fieldHeight, int expected)
        {
            Car car = new Car();
            car.X = posWidth;
            car.Y = posHeight;
            car.Direction = direction;
            Field field = new Field(fieldWidth, fieldHeight);
            command.Execute(car, field);
            Assert.AreEqual(expected, car.X);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow('X')]
        public void Test_Negative_Given_WrongDirection_Return_ArgumentException(char direction)
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
