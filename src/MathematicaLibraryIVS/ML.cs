using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MathematicaLibraryIVS
{
    public class ML 
    {
        private const double abovelimit = 79228162514264337593543950335d;
        private const double belovelimit = -79228162514264337593543950335d;
        public static decimal plus(decimal x,decimal y){
            double a = Decimal.ToDouble(x);
            double b = Decimal.ToDouble(y);
            if (((a+b) > abovelimit) || ((a+b) < belovelimit))
            {
                throw new OverflowException("Number is larger/lower than decimal type limit");
            }
            return x+y;
        }

        public static decimal minus(decimal x, decimal y)
        {
            if ((Decimal.ToDouble(x - y) > abovelimit) || (Decimal.ToDouble(x - y) < belovelimit))
            {
                throw new OverflowException("Number is larger/lower than decimal type limit");
            }
            return x - y;
        }

        public static decimal multiply(decimal x, decimal y)
        {
            double a = Decimal.ToDouble(x);
            double b = Decimal.ToDouble(y);
            if (((a * b) > abovelimit) || ((a * b) < belovelimit))
            {
                throw new OverflowException("Number is larger/lower than decimal type limit");
            }

            return x*y;
        }

        public static decimal divide(decimal x, decimal y)
        {
            if (y == 0) {
                throw new DivideByZeroException("Dividing_By_Zero");
            }

            return x/ y;
        }

        public static decimal factorial(decimal x)
        {


            if (x % 1 != 0) {
                throw new Exception("Number is not whole");
            }

            decimal sum = x;
            double checksum;
            double checkx;

            x--;
            while (x!=1) {
                checksum = Decimal.ToDouble(sum); 
                checkx = Decimal.ToDouble(x);
                if (((checksum* checkx) > abovelimit) || ((checksum * checkx) < belovelimit)) {
                    throw new OverflowException("Number is larger/lower than decimal type limit");
                }
                sum *=x;
                x--;
            }

            return sum;
        }

        public static decimal power(decimal number, decimal power)
        {

            if (power % 1 != 0 && power>0)
            {
                throw new Exception("exponent is not whole positive number");
            }

            if (power == 0) {
                return 1;
            }
            double checksum;
            double checkx;
            decimal sum = number;

          
            for (int i = 1;i<power;i++){
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

        public static decimal root(decimal number, decimal root)
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

        public static decimal modulo(decimal x, decimal y)
        {


            if (y == 0)
            {
                throw new DivideByZeroException("Modulo by zero");
            }

            return x % y;
        }
    }
}
