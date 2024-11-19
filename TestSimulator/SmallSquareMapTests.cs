using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class SmallSquareMapTests
    {
        [Fact]
        public void MapConstructorTestValid()
        {
            int size = 10;
            var map = new SmallSquareMap(size);
            Assert.Equal(size, map.Size);

        }
        [Theory]
        [InlineData(21)]
        [InlineData(4)]
        public void MapConstructorTestInvalid(int size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
        }
        [Theory]
        [InlineData(6,6,10, true)]
        [InlineData(6, 1, 5, false)]
        [InlineData(19, 19, 20, true)]
        [InlineData(20, 20, 20, false)]
        public void ExistMethodTest(int x, int y, int size, bool expected)
        {
           
            var map = new SmallSquareMap(size);
            var point = new Point(x, y);
            var result = map.Exist(point);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(5,5,Direction.Up,5,6)]
        [InlineData(5, 5, Direction.Right, 6, 5)]
        [InlineData(0,0,Direction.Down,0,0)]
        [InlineData(5,5,Direction.Left,4,5)]
        public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
       
            var map = new SmallSquareMap(10);
            var point = new Point(x, y);
            var nextPoint = map.Next(point, direction);
            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        }

        [Theory]
        [InlineData(0,0, Direction.Up,0,1)]
        [InlineData(4,4, Direction.Left,3,4)]
        [InlineData(4,4, Direction.Down, 4,3)]
        [InlineData(0, 8, Direction.Left, 0, 8)]
        public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            var map = new SmallSquareMap(10);
            var point = new Point(x, y);
            var nextPoint = map.Next(point, direction);
            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        }
    }
}
