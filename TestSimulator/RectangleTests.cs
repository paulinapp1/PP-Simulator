using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Simulator;
namespace TestSimulator
{
    public class RectangleTests
    {
        [Fact]
        public void Constructor_setsRightPointsTest()
        {
            int x1 = 1;
            int y1 = 5;
            int x2 = 6;
            int y2 = 7;
            var rec = new Rectangle(x1, y1, x2, y2);

            Assert.Equal(1, rec.X1);
            Assert.Equal(5, rec.Y1);
            Assert.Equal(6, rec.X2);
            Assert.Equal(7, rec.Y2);

        }
        [Fact]
        public void Constructor_FlipsThePoints()
        {
            int x1 = 10, y1 = 0, x2 = 0, y2 = 10;
            var rec = new Rectangle(x1, y1, x2, y2);

            Assert.Equal(0, rec.X1);
            Assert.Equal(0, rec.Y1);
            Assert.Equal(10, rec.X2);
            Assert.Equal(10, rec.Y2);

        }
        [Fact]
        public void Constructor_throwsException()
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(2,2,2,5));
            Assert.Throws<ArgumentException>(() => new Rectangle(0,0,10,0));
        }
        [Fact]
        public void Constructor_InitializesRectangleWithPoints()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(5, 5);
            var rec = new Rectangle(p1, p2);

            Assert.Equal(0, rec.X1);
            Assert.Equal(0, rec.Y1);
            Assert.Equal(5, rec.X2);
            Assert.Equal(5, rec.Y2);
        }
        [Theory]
        [InlineData(5,11,false)]
        [InlineData(0,0,true)]
        [InlineData(0,5,true)]
        [InlineData(10,10,true)]
        public void Contains_returnsRightResult(int x, int y, bool expected)
        {
            var rec = new Rectangle(0, 0, 10, 10);
            var point = new Point(x, y);
            var temporary = rec.Contains(point);
            Assert.Equal(expected, temporary);

        }
        [Fact]
        public void ToString_returnsCorrectResult()
        {
            var rec = new Rectangle(2, 1, 3, 7);
            var temporary = rec.ToString();
            Assert.Equal("(2,1):(3,7)",temporary);
        }

    }
}
