﻿using DrivingCar.Domain.Commands;
using DrivingCar.Domain.Shared;

namespace DrivingCar.UnitTest.Domain.Commands
{
    [TestClass]
    public class RightCommandTest
    {
        ICommand command = new RightCommand();

        [TestMethod]
        [DataRow('N', 'E')]
        [DataRow('E', 'S')]
        [DataRow('S', 'W')]
        [DataRow('W', 'N')]
        public void Test_Positive_Given_Direction_ReturnNewDirection(char direction, char expected)
        {
            Car car = new Car();
            car.X = 1;
            car.Y = 2;
            car.Direction = direction;
            Field field = new Field(10, 10);
            command.Execute(car, field);
            Assert.AreEqual(expected, car.Direction);
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
