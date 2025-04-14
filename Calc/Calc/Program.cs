class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number:");

        if (!int.TryParse(Console.ReadLine(), out int n1))
        {
            Console.WriteLine("Error. Not a number");
            return;
        }

        Console.WriteLine("Enter second number:");

        if (!int.TryParse(Console.ReadLine(), out int n2))
        {
            Console.WriteLine("Error. Not a number");
            return;
        }

        Console.WriteLine("Enter bitwise operator (&, | or ^):");
        var op = Console.ReadLine();
        if (op.Length != 1)
        {
            Console.WriteLine("Wrong sign");
            return;
        }

        int result = 0;
        switch (op[0])
        {
            case '&':
                result = n1 & n2;
                break;
            case '|':
                result = n1 | n2;
                break;
            case '^':
                result = n1 ^ n2;
                break;
            default:
                Console.WriteLine("Invalid operator!");
                return;
        }

        Console.WriteLine("Result:");
        Console.WriteLine($"Decimal (10): {result}");
        Console.WriteLine($"Binary  (2):  {Convert.ToString(result, 2) }");
        Console.WriteLine($"Hex     (16): 0x{result:X}");
    }
}