using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathematicaLibraryIVS;
/// <summary>
/// This unit test where used for TDD developing ML (Mathematical Lybrary)
/// </summary>
namespace Math_Library.UnitTests
{
    [TestClass]
    public class MathematicLibraryIVS
    {
        [TestMethod]
        public void Plus_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 1;
            decimal b = 2;

            decimal c = decimal.MaxValue - 1M;
            decimal d = -1;

            decimal e = 5.55555555555555555555M;
            decimal f = 5.555555555555555555555M;
            decimal e_f =11.111111111111111111105M;
            
            decimal g = -88888.53333331M;
            decimal h = 0.53333331M;

            //Act 
            decimal result1 = ML.plus(a,b);
            decimal result2 = ML.plus(c, d);
            decimal result3 = ML.plus(e, f);
            decimal result4 = ML.plus(g, h);

            //Assert
            Assert.AreEqual(3, result1);
            Assert.AreEqual(decimal.MaxValue-2M, result2);
            Assert.AreEqual(e_f, result3);
            Assert.AreEqual(-88888, result4);
        }
        [TestMethod]
        public void Plus_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = decimal.MaxValue;
            decimal b = 1;

            decimal c = decimal.MinValue;
            decimal d = -1;

            try
            {
                //Act 
                decimal result1 = ML.plus(a,b);
                Console.WriteLine(result1);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (OverflowException)
            {


            }

            try
            {
                //Act 
                decimal result1 = ML.plus(c, d);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (OverflowException)
            {


            }

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
            decimal h = 0.00000001M;

            //Act 
            decimal result1 = ML.minus(a, b);
            decimal result2 = ML.minus(c, d);
            decimal result3 = ML.minus(e, f);
            decimal result4 = ML.minus(g, h);

            //Assert
            Assert.AreEqual(-1, result1);
            Assert.AreEqual(decimal.MaxValue-3M, result2);
            Assert.AreEqual(0, result3);
            Assert.AreEqual(-88888.53333332M, result4);
        }

        [TestMethod]
        public void Minus_IncorectInput_Fail()
        {
            //Arrange

            decimal a = decimal.MinValue;
            decimal b = 1;

            try
            {
                //Act 
                decimal result1 = ML.minus(a, b);
                Console.WriteLine(result1);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (OverflowException)
            {


            }

        }

        [TestMethod]
        public void Multiply_CorectInput_Fail()
        {
            Console.WriteLine(decimal.MaxValue);
            //Arrange
            decimal a = 1;
            decimal b = 2;

            decimal c = decimal.MaxValue;
            decimal d = 1;

            decimal e = 5.5555555555M;
            decimal f = 5.5555555555M;
            
            decimal g = -88888.53333331M;
            decimal h = 0.53333331M;
            decimal g_h = -47407.2157036995555561M;

            //Act 
            decimal result1 = ML.multiply(a, b);
            decimal result2 = ML.multiply(c, d);
            decimal result3 = ML.multiply(e, f);
            decimal result4 = ML.multiply(g, h);

            //Assert
            Assert.AreEqual(2, result1);
            Assert.AreEqual(decimal.MaxValue, result2);
            Assert.AreEqual(30.86419753024691358025M, result3);
            Assert.AreEqual(g_h, result4);
        }

        [TestMethod]
        public void Multiply_IncorectInput_Fail()
        {
            //Arrange
            decimal a = decimal.MinValue;
            decimal b = 2;

            decimal c = decimal.MaxValue;
            decimal d = 2;

            try
            {
                //Act 
                decimal result1 = ML.multiply(a, b);
                Console.WriteLine(result1);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (OverflowException)
            {


            }

            try
            {
                //Act 
                decimal result1 = ML.multiply(c, d);
                Console.WriteLine(result1);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (OverflowException)
            {


            }
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
            decimal e_f = 2M;
            
            decimal g = -88888.444444M;
            decimal h = 2M;
            decimal g_h = -44444.222222M;

            //Act 
            decimal result1 = ML.divide(a, b);
            decimal result2 = ML.divide(c, d);
            decimal result3 = ML.divide(e, f);
            decimal result4 = ML.divide(g, h);

            //Assert
            Assert.AreEqual(0.5M, result1);
            Assert.AreEqual(decimal.MaxValue, result2);
            Assert.AreEqual(e_f, result3);
            Assert.AreEqual(g_h, result4);
        }

        [TestMethod]
        public void Divide_IncorectInput_AreEqual()
        {
            
            //Arrange
            decimal a = 1;
            decimal b = 0;
            try
            {
                //Act 
                decimal result1 = ML.divide(a, b);
                //Assert
                Assert.Fail("Dividing_By_Zero");
            }
            catch (DivideByZeroException)
            {
                
                
            }
        }
        [TestMethod]
        public void Factorial_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 5;
            decimal d = 25;


            //Act 
            decimal result1 = ML.factorial(a);
            decimal result4 = ML.factorial(d);
            decimal result4_answer = 15511210043330985984000000M;

            //Assert
            Assert.AreEqual(120, result1);
            Assert.AreEqual(result4_answer, result4);


        }
        [TestMethod]
        public void Factorial_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 2.1M;
            decimal b = -2;
            decimal c = 26;

            try { 
                //Act 
                decimal result1 = ML.factorial(a);
                //Assert
                 Assert.Fail("Number is not whole");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result2 = ML.factorial(b);
                //Assert
                Assert.Fail("Number is not whole");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result3 = ML.factorial(c);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (Exception)
            {

            }

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
            decimal result1 = ML.power(a,25);
            decimal result2 = ML.power(b,99999999);
            decimal result3 = ML.power(c, 99999999);
            decimal result4 = ML.power(a, 2);
            decimal result5 = ML.power(d, 2);
            decimal result6 = ML.power(e, 0);


            //Assert
            Assert.AreEqual(298023223876953125, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(1, result3);
            Assert.AreEqual(25, result4);
            Assert.AreEqual(8.156736M, result5);
            Assert.AreEqual(1, result6);
        }
        [TestMethod]
        public void power_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 5;


            try
            {
                //Act 
                decimal result1 = ML.power(a, 2.1M);
                //Assert
                Assert.Fail("exponent is not whole positive number");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result2 = ML.power(a, -2);
                //Assert
                Assert.Fail("exponent is not whole positive number");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result3 = ML.power(a, 99);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (OverflowException)
            {

            }


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
            decimal result1 = ML.root(a,2);
            decimal result2 = ML.root(b, 9999);
            decimal result3 = ML.root(c, 5);
            decimal result4 = ML.root(d, 3);


            //Assert
            Console.WriteLine(result1);
            Assert.AreEqual(5, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(1, result3);
            Assert.AreEqual(2.54246686166691M, result4);

        }
        [TestMethod]
        public void root_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = -25;

            try
            {
                //Act 
                decimal result1 = ML.root(a, 2.1M);
                //Assert
                Assert.Fail("root is not whole positive number");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result2 = ML.root(a, -2);
                //Assert
                Assert.Fail("root is not whole positive number");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result4 = ML.root(b, 2);
                //Assert
                Assert.Fail("Number is negative(Not difined)");
            }
            catch (Exception)
            {

            }



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
            decimal result1 = ML.modulo(a, b);
            decimal result2 = ML.modulo(c, d);
            decimal result3 = ML.modulo(d, e);
            decimal result4 = ML.modulo(0, 1);
            decimal result5 = ML.modulo(26, 5);



            //Assert
            Assert.AreEqual(0, result1);
            Assert.AreEqual(3, result2);
            Assert.AreEqual(-2.8M, result3);
            Assert.AreEqual(0, result4);
            Assert.AreEqual(1, result5);


        }
        [TestMethod]
        public void modulo_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = 0;

            try
            {
                //Act 
                decimal result1 = ML.modulo(a, b);
                //Assert
                Assert.Fail("Modulo by zero");
            }
            catch (Exception)
            {

            }


        }
    }
}
