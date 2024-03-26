using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public static bool operator ==(ComplexNumber num1, ComplexNumber num2)
        {
            return num1.Real == num2.Real && num1.Imaginary == num2.Imaginary;
        }

        public static bool operator !=(ComplexNumber num1, ComplexNumber num2)
        {
            return !(num1 == num2);
        }

        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.Real + num2.Real, num1.Imaginary + num2.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.Real - num2.Real, num1.Imaginary - num2.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2)
        {
            double newReal = num1.Real * num2.Real - num1.Imaginary * num2.Imaginary;
            double newImaginary = num1.Real * num2.Imaginary + num1.Imaginary * num2.Real;
            return new ComplexNumber(newReal, newImaginary);
        }

        public static ComplexNumber operator /(ComplexNumber num1, ComplexNumber num2)
        {
            double denominator = num2.Real * num2.Real + num2.Imaginary * num2.Imaginary;
            double newReal = (num1.Real * num2.Real + num1.Imaginary * num2.Imaginary) / denominator;
            double newImaginary = (num1.Imaginary * num2.Real - num1.Real * num2.Imaginary) / denominator;
            return new ComplexNumber(newReal, newImaginary);
        }
        public static (ComplexNumber, ComplexNumber) ParseComplexNumbers(string input)
        {
            string[] numbers = input.Split(',');
            if (numbers.Length != 2)
            {
                throw new ArgumentException("Input string must contain two complex numbers separated by a comma.");
            }

            ComplexNumber number1 = ParseComplexNumber(numbers[0].Trim());
            ComplexNumber number2 = ParseComplexNumber(numbers[1].Trim());

            return (number1, number2);
        }

        public static ComplexNumber ParseComplexNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string is empty or null.");
            }

            input = input.Replace(" ", ""); // Remove any white spaces

            // Find the position of '+' or '-' sign to separate real and imaginary parts
            int separatorIndex = input.LastIndexOf('+');
            if (separatorIndex == -1)
            {
                separatorIndex = input.LastIndexOf('-');
            }

            if (separatorIndex == -1)
            {
                throw new ArgumentException("Input string is not in correct format.");
            }

            string realPart = input.Substring(0, separatorIndex);
            string imaginaryPart = input.Substring(separatorIndex);

            // Remove 'i' at the end of imaginary part
            imaginaryPart = imaginaryPart.Replace("i", "");

            double real = double.Parse(realPart);
            double imaginary = double.Parse(imaginaryPart);

            return new ComplexNumber(real, imaginary);
        }
    }
}
