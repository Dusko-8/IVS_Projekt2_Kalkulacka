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
            decimal result1 = ML.Plus(a,b);
            decimal result2 = ML.Plus(c, d);
            decimal result3 = ML.Plus(e, f);
            decimal result4 = ML.Plus(g, h);

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
                decimal result1 = ML.Plus(a,b);
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
                decimal result1 = ML.Plus(c, d);
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
            decimal result1 = ML.Minus(a, b);
            decimal result2 = ML.Minus(c, d);
            decimal result3 = ML.Minus(e, f);
            decimal result4 = ML.Minus(g, h);

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
                decimal result1 = ML.Minus(a, b);
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
            decimal result1 = ML.Multiply(a, b);
            decimal result2 = ML.Multiply(c, d);
            decimal result3 = ML.Multiply(e, f);
            decimal result4 = ML.Multiply(g, h);

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
                decimal result1 = ML.Multiply(a, b);
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
                decimal result1 = ML.Multiply(c, d);
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
            decimal result1 = ML.Divide(a, b);
            decimal result2 = ML.Divide(c, d);
            decimal result3 = ML.Divide(e, f);
            decimal result4 = ML.Divide(g, h);

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
                decimal result1 = ML.Divide(a, b);
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
            decimal result1 = ML.Factorial(a);
            decimal result4 = ML.Factorial(d);
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
                decimal result1 = ML.Factorial(a);
                //Assert
                 Assert.Fail("Number is not whole");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result2 = ML.Factorial(b);
                //Assert
                Assert.Fail("Number is not whole");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result3 = ML.Factorial(c);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (Exception)
            {

            }

        }

        [TestMethod]
        public void Power_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 5;
            decimal b = 0;
            decimal c = 1;
            decimal d = 2.856M;
            decimal e = 999999999999999999999999M;

            //Act 
            decimal result1 = ML.Power(a,25);
            decimal result2 = ML.Power(b,99999999);
            decimal result3 = ML.Power(c, 99999999);
            decimal result4 = ML.Power(a, 2);
            decimal result5 = ML.Power(d, 2);
            decimal result6 = ML.Power(e, 0);


            //Assert
            Assert.AreEqual(298023223876953125, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(1, result3);
            Assert.AreEqual(25, result4);
            Assert.AreEqual(8.156736M, result5);
            Assert.AreEqual(1, result6);
        }
        [TestMethod]
        public void Power_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 5;


            try
            {
                //Act 
                decimal result1 = ML.Power(a, 2.1M);
                //Assert
                Assert.Fail("exponent is not whole positive number");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result2 = ML.Power(a, -2);
                //Assert
                Assert.Fail("exponent is not whole positive number");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result3 = ML.Power(a, 99);
                //Assert
                Assert.Fail("Number is larger/lower than decimal type limit");
            }
            catch (OverflowException)
            {

            }


        }
        [TestMethod]
        public void Root_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = 0;
            decimal c = 1;
            decimal d = 16.434856M;

            //Act 
            decimal result1 = ML.Root(a,2);
            decimal result2 = ML.Root(b, 9999);
            decimal result3 = ML.Root(c, 5);
            decimal result4 = ML.Root(d, 3);


            //Assert
            Console.WriteLine(result1);
            Assert.AreEqual(5, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(1, result3);
            Assert.AreEqual(2.54246686166691M, result4);

        }
        [TestMethod]
        public void Root_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = -25;

            try
            {
                //Act 
                decimal result1 = ML.Root(a, 2.1M);
                //Assert
                Assert.Fail("root is not whole positive number");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result2 = ML.Root(a, -2);
                //Assert
                Assert.Fail("root is not whole positive number");
            }
            catch (Exception)
            {

            }

            try
            {
                //Act 
                decimal result4 = ML.Root(b, 2);
                //Assert
                Assert.Fail("Number is negative(Not difined)");
            }
            catch (Exception)
            {

            }



        }

        [TestMethod]
        public void Modulo_CorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = 5;
            decimal c = 9;
            decimal d = -6;
            decimal e = 3.2M;

            //Act 
            decimal result1 = ML.Modulo(a, b);
            decimal result2 = ML.Modulo(c, d);
            decimal result3 = ML.Modulo(d, e);
            decimal result4 = ML.Modulo(0, 1);
            decimal result5 = ML.Modulo(26, 5);



            //Assert
            Assert.AreEqual(0, result1);
            Assert.AreEqual(3, result2);
            Assert.AreEqual(-2.8M, result3);
            Assert.AreEqual(0, result4);
            Assert.AreEqual(1, result5);


        }
        [TestMethod]
        public void Modulo_IncorectInput_AreEqual()
        {
            //Arrange
            decimal a = 25;
            decimal b = 0;

            try
            {
                //Act 
                decimal result1 = ML.Modulo(a, b);
                //Assert
                Assert.Fail("Modulo by zero");
            }
            catch (Exception)
            {

            }


        }
    }
}
