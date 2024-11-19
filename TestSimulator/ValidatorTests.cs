using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Simulator;


namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(20, 5, 21, 20)]
        [InlineData(30, 5, 20, 20)]
        [InlineData(5, 10, 20, 10)]
        public void Limiter_returnsCorrectValue(int value, int min, int max, int expected)
        {
            var result = Validator.Limiter(value, min, max);
            Assert.Equal(expected, result);

        }
        [Theory]
        [InlineData("abc",5,10, '#',"Abc##")]
        [InlineData("abcdefghijklm",5,10,'#',"Abcdefghij")]
        [InlineData("hello world", 5,15,'#',"Hello world")]
        [InlineData("",5,10,'#',"#####")]
        [InlineData("   abc",5,10,'#',"Abc##")]
        public void Shortener_returnsCorrectValue(string value, int min, int max, char placeholder, string expected)
        {
            var result = Validator.Shortener(value, min, max, placeholder);
            Assert.Equal(expected, result);

        }
    }
}
