using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;


namespace TestSimulator
{
    public class PointTests
    {
        [Fact]
        public void Constructor_setsRightPointsTest()
        {
            int x = 7;
            int y = 8;
            var point = new Point(7, 8);
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);

        }
        [Theory]
        [InlineData(4,3,Direction.Left, 3,3)]
        [InlineData(5,8,Direction.Right,6,8)]
        [InlineData(3,3,Direction.Up, 3,4)]
        [InlineData(8,4, Direction.Down,8,3)]
        public void Next_SchouldReturnCorrect(int x, int y, Direction direction, int expectedX,int expectedY)
        {
            var point = new Point(x, y);
            var nextPoint = point.Next(direction);
            Assert.Equal(expectedX, nextPoint.X);
            Assert.Equal(expectedY, nextPoint.Y);

        }
        [Theory]
        [InlineData(4,3,Direction.Right, 5,2)]
        [InlineData(3,3, Direction.Left, 3,4)]
        [InlineData(8,5, Direction.Up, 9,6)]
        [InlineData(7,7, Direction.Down, 6,6)]
        public void NextDiagonal_ShouldReturnCorrect(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            var point = new Point(x, y);
            var nextPoint = point.NextDiagonal(direction);
            Assert.Equal(expectedX, nextPoint.X);
            Assert.Equal(expectedY, nextPoint.Y);

        }
    }
}
