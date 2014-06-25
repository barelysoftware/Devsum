using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace AutoFixture.Tests
{
    
    public class ComplexTests
    {
        [Theory,
        AutoData,
        InlineData(4,5)]
        public void CreateComplex(int realPart,int imaginaryPart)
        {
            
            //Act
            var complex = new Complex(realPart, imaginaryPart);

            //Assert
            Assert.Equal(realPart,complex.Real);
            Assert.Equal(imaginaryPart,complex.Imaginary);
        }

        [Fact]
        public void EqualComplex()
        {
            //Arrange
            var realPart = 3;
            var imaginaryPart = 5;

            //Act
            var complex1 = new Complex(realPart, imaginaryPart);
            var complex2 = new Complex(realPart, imaginaryPart);
            //Assert
            Assert.True(complex2.Equals(complex1));
            
        }


        [Fact]
        public void AddComplex()
        {
            var  complex1 = new Complex(1,2);
            var complex2 = new Complex(3,4); 
            var expected = new Complex(4,6);

            var actual = complex1 + complex2;

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void MultipleComplex()
        {
            var complex1 = new Complex(1, 2);
            var complex2 = new Complex(3, 4);
            var expected = new Complex(-5, 10);

            var actual = complex1 * complex2;

            Assert.Equal(expected,actual);
        }
    }
}
