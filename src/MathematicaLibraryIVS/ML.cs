using System;

namespace MathematicaLibraryIVS
{
    /// <summary>
    /// Mathematical lybrary build with simple functions used in calculators
    /// </summary>
    public class ML
    {   /// <summary>
        /// Constants represents highest possible number that can be reached
        /// </summary>
        private const double abovelimit = 79228162514264337593543950335d;
        private const double belovelimit = -79228162514264337593543950335d;

        /// <summary>
        /// Adds first and second number passed as params.
        /// </summary>
        /// <param name="x">Number 1.</param>
        /// <param name="y">Number 2.</param>
        /// <returns>Sum of Number 1. plus Number 2.</returns>
        /// <exception cref="OverflowException">If the numbers are larger than expected.</exception>
        public static decimal Plus(decimal x, decimal y)
        {
            double a = Decimal.ToDouble(x);
            double b = Decimal.ToDouble(y);
            if (((a + b) > abovelimit) || ((a + b) < belovelimit))
            {
                throw new OverflowException("Number is larger/lower than decimal type limit");
            }
            return x + y;
        }
        /// <summary>
        /// Subtructs second number from first passed as params.
        /// </summary>
        /// <param name="x">Number 1.</param>
        /// <param name="y">Number 2.</param>
        /// <returns>Sum of Number 1. minus Number 2.</returns>
        /// <exception cref="OverflowException">If the numbers are larger than expected.</exception>
        public static decimal Minus(decimal x, decimal y)
        {
            if ((Decimal.ToDouble(x - y) > abovelimit) || (Decimal.ToDouble(x - y) < belovelimit))
            {
                throw new OverflowException("Number is larger/lower than decimal type limit");
            }
            return x - y;
        }
        /// <summary>
        /// Multiplies first and second number passed as params.
        /// </summary>
        /// <param name="x">Number 1.</param>
        /// <param name="y">Number 2.</param>
        /// <returns>Sum of Number 1. times Number 2.</returns>
        /// <exception cref="OverflowException">If the numbers are larger than expected.</exception>
        public static decimal Multiply(decimal x, decimal y)
        {
            double a = Decimal.ToDouble(x);
            double b = Decimal.ToDouble(y);
            if (((a * b) > abovelimit) || ((a * b) < belovelimit))
            {
                throw new OverflowException("Number is larger/lower than decimal type limit");
            }

            return x * y;
        }
        /// <summary>
        /// Devides first and second number passed as params.
        /// </summary>
        /// <param name="x">Number 1.</param>
        /// <param name="y">Number 2.</param>
        /// <returns>Sum of Number 1. devided by Number 2.</returns>
        /// <exception cref="DivideByZeroException">If the devision is done with **0** .</exception>
        public static decimal Divide(decimal x, decimal y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Dividing_By_Zero");
            }

            return x / y;
        }
        /// <summary>
        /// Makes factorial of given number passed in params
        /// </summary>
        /// <param name="x">Number 1.</param>
        /// <returns>Factorial of Number 1.</returns>
        /// <exception cref="Exception">If the number is not whole</exception>
        /// <exception cref="OverflowException">If the numbers are larger than expected.</exception>
        public static decimal Factorial(decimal x)
        {


            if (x % 1 != 0)
            {
                throw new Exception("Number is not whole");
            }

            decimal sum = x;
            double checksum;
            double checkx;

            x--;
            while (x != 1)
            {
                checksum = Decimal.ToDouble(sum);
                checkx = Decimal.ToDouble(x);
                if (((checksum * checkx) > abovelimit) || ((checksum * checkx) < belovelimit))
                {
                    throw new OverflowException("Number is larger/lower than decimal type limit");
                }
                sum *= x;
                x--;
            }

            return sum;
        }
        /// <summary>
        /// Resolves to number the power of given whole number.
        /// </summary>
        /// <param name="number">Number 1.</param>
        /// <param name="power">Power</param>
        /// <returns>**Number 1.** to the power of **Power**</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="OverflowException">If the numbers are larger than expected.</exception>
        public static decimal Power(decimal number, decimal power)
        {

            if (power % 1 != 0 && power > 0)
            {
                throw new Exception("exponent is not whole positive number");
            }

            if (power == 0)
            {
                return 1;
            }
            double checksum;
            double checkx;
            decimal sum = number;


            for (int i = 1; i < power; i++)
            {
                checksum = Decimal.ToDouble(sum);
                checkx = Decimal.ToDouble(number);
                if ((checksum * checkx) > abovelimit)
                {
                    throw new OverflowException("Number is larger/lower than decimal type limit");
                }
                sum *= number;
            }

            return sum;
        }
        /// <summary>
        /// Resolves to number the root of given whole number.
        /// </summary>
        /// <param name="number">Number 1.</param>
        /// <param name="root">Root</param>
        /// <returns>**Number 1.** root of **Power**</returns>
        /// <exception cref="Exception">If the number is negative or root is not whole.</exception>
        public static decimal Root(decimal number, decimal root)
        {
            if (root % 1 != 0 && root > 0)
            {
                throw new Exception("arg1 is not whole positive number");
            }
            if (number < 0)
            {
                throw new Exception("arg2 is not whole positive number");
            }
            if (number == 0)
            {
                return 0;
            }
            if (root == 1)
            {
                return number;
            }
            decimal result = (decimal)System.Math.Pow((double)number, (double)(1.0M / root));
            return result;

        }
        /// <summary>
        /// Calculates the remainder after division.
        /// </summary>
        /// <param name="x">Number 1.</param>
        /// <param name="y">Number 2.</param>
        /// <returns> Remainder ofNumber 1. modulo Number 2.</returns>
        /// <exception cref="DivideByZeroException">If the division is done by 0</exception>
        public static decimal Modulo(decimal x, decimal y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Modulo by zero");
            }

            return x % y;
        }
    }
}
