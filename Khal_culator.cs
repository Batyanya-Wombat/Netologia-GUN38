using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello! Please enter the first number - ");
        if (!Int32.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("Invalid input: not a number");
            return;
        }

        Console.WriteLine("First number (dec)={0}", a);
        Console.WriteLine("First number (bin)={0}", Convert.ToString(a, 2));
        Console.WriteLine("First number (hex)={0}", Convert.ToString(a, 16));

        Console.WriteLine("Now enter the second number - ");
        if (!Int32.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Invalid input: not a number");
            return;
        }

        Console.WriteLine("Second number (dec)={0}", b);
        Console.WriteLine("Second number (bin)={0}", Convert.ToString(b, 2));
        Console.WriteLine("Second number (hex)={0}", Convert.ToString(b, 16));

        Console.WriteLine("Choose an operator: & (AND), | (OR), ^ (XOR)");
        var s = Console.ReadLine();
        if (s.Length != 1)
        {
            Console.WriteLine("Error: You must enter exactly ONE operator symbol");
            return;

        }
        switch (s[0])
        {
            case '&':
                Console.ForegroundColor = ConsoleColor.Magenta; 
                Console.WriteLine("Decimal result of {0} & {1} = {2} ", a, b, a & b);
                Console.WriteLine("Binary result of {0} & {1} = {2} ", a, b, Convert.ToString(a & b, 2));
                Console.WriteLine("Hexadecimal result of {0} & {1} = {2} ", a, b, Convert.ToString(a & b, 16));
                Console.ResetColor();
                break;
            case '|':
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Decimal result of {0} | {1} = {2} ", a, b, a | b);
                Console.WriteLine("Binary result of {0} | {1} = {2} ", a, b, Convert.ToString(a | b, 2));
                Console.WriteLine("Hexadecimal result of {0} | {1} = {2} ", a, b, Convert.ToString(a | b, 16));
                Console.ResetColor();
                break;
            case '^':
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Decimal result of {0} ^ {1} = {2} ", a, b, a ^ b);
                Console.WriteLine("Binary result of {0} ^ {1} = {2} ", a, b, Convert.ToString(a ^ b, 2));
                Console.WriteLine("Hexadecimal result of {0} ^ {1} = {2} ", a, b, Convert.ToString(a ^ b, 16));
                Console.ResetColor();
                break;
            default:
                Console.WriteLine("Error: Invalid operator.");
                break;
        }
    }
}