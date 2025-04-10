using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        public int gcd(int par1, int par2){
            int par3 = 1;
            while(par3 != 0){
                par3 = par1 % par2;
                par1 = par2;
                par2 = par3;
            }
            return par1;
        }
        public double Calculate(double num1, string op, double num2) {
            int par1 = (int)num1;
            int par2 = (int)num2;
            switch(op){
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    if(num2 == 0){
                        throw new DivideByZeroException("Division by zero is not allowed");
                    }
                    else {
                        return num1 / num2;
                    }
                case "**":
                    return Math.Pow(num1, num2);
                case "%":
                    return num1 % num2;
                case "G":
                    return gcd(par1, par2);
                case "L":
                    return par1 * par2 / gcd(par1, par2);
                default:
                    throw new InvalidOperationException("Invalid operator");
            }
        }
    }
}

/* example output

Enter an expression (ex. 2 + 3):
>> 4 * 3
Result: 12

*/


/* example output (CHALLANGE)

Enter an expression (ex. 2 + 3):
>> 4 ** 3
Result: 64

Enter an expression (ex. 2 + 3):
>> 5 ** -2
Result: 0.04

Enter an expression (ex. 2 + 3):
>> 12 G 15
Result: 3

Enter an expression (ex. 2 + 3):
>> 12 L 15
Result: 60

Enter an expression (ex. 2 + 3):
>> 12 % 5
Result: 2

*/
