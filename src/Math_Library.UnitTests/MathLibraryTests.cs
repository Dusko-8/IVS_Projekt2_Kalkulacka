using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Math_Library.UnitTests
{
    [TestClass]
    public class MathLibraryTests
    {
        [TestMethod]
        public void Plus_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 1;
            decimal b = 2;

            decimal c = decimal.MaxValue - 1.5M;
            decimal d = 1.5M;

            decimal e = 5.55555555555555555555M;
            decimal f = 5.555555555555555555555M;
            decimal e_f=11.111111111111111111105M;
            
            decimal g = -88888.53333331M;
            decimal h = 0.53333331M;

            //Act 
            decimal result1 = plus(a, b);
            decimal result2 = plus(c, d);
            decimal result3 = plus(e, f);
            decimal result4 = plus(g, h);

            //Assert
            Assert.AreEqual(5, result1);
            Assert.AreEqual(decimal.MaxValue, result2);
            Assert.AreEqual(e_f, result3);
            Assert.AreEqual(-88888, result4);
        }

        [TestMethod]
        public void Minus_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 1;
            decimal b = 2;

            decimal c = decimal.MaxValue-1.5M;
            decimal d = 1.5M;

            decimal e = 5.55555555555555555555M;
            decimal f = 5.55555555555555555555M;
            
            decimal g = -88888.53333331M;
            decimal h = 0.53333331M;

            //Act 
            decimal result1 = minus(a, b);
            decimal result2 = minus(c, d);
            decimal result3 = minus(e, f);
            decimal result4 = minus(g, h);

            //Assert
            Assert.AreEqual(-1, result1);
            Assert.AreEqual(decimal.MaxValue-3M, result2);
            Assert.AreEqual(0, result3);
            Assert.AreEqual(-88, result4);
        }

        [TestMethod]
        public void Multyply_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 1;
            decimal b = 2;

            decimal c = decimal.MaxValue;
            decimal d = 1;

            decimal e = 5.5555555555M;
            decimal f = 5.5555555555M;
            
            decimal g = -88888.53333331M;
            decimal h = 0.53333331M;
            decimal g_h = -4740.5509036995555561M;

            //Act 
            decimal result1 = multyply(a, b);
            decimal result2 = multyply(c, d);
            decimal result3 = multyply(e, f);
            decimal result4 = multyply(g, h);

            //Assert
            Assert.AreEqual(2, result1);
            Assert.AreEqual(decimal.MaxValue, result2);
            Assert.AreEqual(30.8641975302, result3);
            Assert.AreEqual(g_h, result4);
        }

        [TestMethod]
        public void Divide_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 1;
            decimal b = 2;

            decimal c = decimal.MaxValue;
            decimal d = 1;

            decimal e = -88888888888888888M;
            decimal f = -44444444444444444M;
            decimal e_f = 22222222222222222M;
            
            decimal g = -88888.444444M;
            decimal h = 2M;
            decimal g_h = -4444.222222M;

            //Act 
            decimal result1 = devide(a, b);
            decimal result2 = devide(c, d);
            decimal result3 = devide(e, f);
            decimal result4 = devide(g, h);

            //Assert
            Assert.AreEqual(0.5, result1);
            Assert.AreEqual(decimal.MaxValue, result2);
            Assert.AreEqual(e_f, result3);
            Assert.AreEqual(g_h, result4);
        }
        public void Divide_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 1;
            decimal b = 0;

            //Act 
            decimal result1 = devide(a, b);


            //Assert
            Assert.AreEqual("Deviding by zero", result1);
        }
        [TestMethod]
        public void Factorial_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 5;
            decimal d = 25;


            //Act 
            decimal result1 = factorial(a);
            decimal result4 = factorial(d);
            decimal result4_answer = 15511210043330985984000000M;

            //Assert
            Assert.AreEqual(120, result1);
            Assert.AreEqual(result4_answer, result4);


        }

        public void Factorial_IncorectInput_AreEqual()
        {
            //Arrange
            decimal b = 2.1M;
            decimal c = -2;
            decimal e = 26;

            //Act 
            String result1 = factorial(b);
            String result2 = factorial(c);
            String result3 = factorial(e);

            //Assert
            Assert.AreEqual("Wrong argument factorial", result1);
            Assert.AreEqual("Wrong argument factorial", result2);
            Assert.AreEqual("Too large factorial", result3);

        }

        [TestMethod]
        public void power_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 5;
            decimal b = 0;
            decimal c = 1;
            decimal d = 2.856M;
            decimal e = 999999999999999999999999M;

            //Act 
            decimal result1 = power(a,25);
            decimal result2 = power(b,99999999);
            decimal result3 = power(c, 99999999);
            decimal result4 = power(a, 2);
            decimal result5 = power(d, 2);
            decimal result6 = power(e, 0);


            //Assert
            Assert.AreEqual(298023223876953125, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(1, result3);
            Assert.AreEqual(25, result4);
            Assert.AreEqual(8.156736, result5);
            Assert.AreEqual(1, result6);
        }
        public void power_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 5;

            //Act 
            String result1 = power(a,2.1);
            String result2 = power(a,-2);
            String result3 = power(a, 99999999999);


            //Assert
            Assert.AreEqual("Wrong power", result1);
            Assert.AreEqual("Wrong power", result2);
            Assert.AreEqual("Too large power", result2);


        }
        [TestMethod]
        public void root_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = 0;
            decimal c = 1;
            decimal d = 16.434856M;

            //Act 
            decimal result1 = root(a,2);
            decimal result2 = root(b, 9999);
            decimal result3 = root(c, 5);
            decimal result4 = root(d, 3);


            //Assert
            Assert.AreEqual(298023223876953125, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(1, result3);
            Assert.AreEqual(1.86, result4);

        }
        public void root_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = -25;

            //Act 
            String result1 = root(a, 2.1);
            String result2 = root(a, -2);
            String result3 = root(a, 99999999999);
            String result4 = root(b, 2);


            //Assert
            Assert.AreEqual("Wrong root", result1);
            Assert.AreEqual("Wrong root", result2);
            Assert.AreEqual("Too large root", result3);
            Assert.AreEqual("Negative base", result4);


        }

        [TestMethod]
        public void modulo_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = 5;
            decimal c = 9;
            decimal d = -6;
            decimal e = 3.2M;

            //Act 
            decimal result1 = modulo(a, b);
            decimal result2 = modulo(c, d);
            decimal result3 = modulo(d, e);
            decimal result4 = modulo(0, 1);



            //Assert
            Assert.AreEqual(0, result1);
            Assert.AreEqual(-3, result2);
            Assert.AreEqual(2.8, result3);
            Assert.AreEqual(0, result4);


        }

        public void modulo_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = 0;


            //Act 
            decimal result1 = modulo(a, b);


            //Assert
            Assert.AreEqual("Modulo by zero", result1);


        }
    }
}
