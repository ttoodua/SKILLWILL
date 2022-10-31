var numbers = new List<int>();
var operators = new Queue<string>();

string input = null;
var operatorsString = "+-/*";
int sum = 0;

var RomanMap = new Dictionary<char, int>()
{
    {'I', 1},
    {'V', 5},
    {'X', 10},
    {'L', 50},
    {'C', 100}
};

Console.WriteLine("Start");
input = Console.ReadLine();

while (input != "exit")
{
    if (operatorsString.Contains(input))
    {
        operators.Enqueue(input);
    }
    else
    {
        int arabicNumber = RomanToInteger(input);
        numbers.Add(arabicNumber);
    }

    input = Console.ReadLine();
}

sum = numbers[0];
numbers.Remove(numbers[0]);
string lastOperator = null;

foreach (var number in numbers)
{
    if (operators.Count != 0)
        lastOperator = operators.Dequeue();

    switch (lastOperator)
    {
        case "+":
            sum += number;
            break;
        case "-":
            sum -= number;
            break;
        case "*":
            sum *= number;
            break;
        case "/":
            sum /= number;
            break;
        default:
            break;
    }
}

Console.WriteLine(ToRoman(sum));

int RomanToInteger(string roman)
{
    int number = 0;
    for (int i = 0; i < roman.Length; i++)
    {
        if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
        {
            number -= RomanMap[roman[i]];
        }
        else
        {
            number += RomanMap[roman[i]];
        }
    }
    return number;
}


 string ToRoman(int number)
{
    if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
    if (number < 1) return string.Empty;
    if (number >= 1000) return "M" + ToRoman(number - 1000);
    if (number >= 900) return "CM" + ToRoman(number - 900);
    if (number >= 500) return "D" + ToRoman(number - 500);
    if (number >= 400) return "CD" + ToRoman(number - 400);
    if (number >= 100) return "C" + ToRoman(number - 100);
    if (number >= 90) return "XC" + ToRoman(number - 90);
    if (number >= 50) return "L" + ToRoman(number - 50);
    if (number >= 40) return "XL" + ToRoman(number - 40);
    if (number >= 10) return "X" + ToRoman(number - 10);
    if (number >= 9) return "IX" + ToRoman(number - 9);
    if (number >= 5) return "V" + ToRoman(number - 5);
    if (number >= 4) return "IV" + ToRoman(number - 4);
    if (number >= 1) return "I" + ToRoman(number - 1);
    throw new ArgumentOutOfRangeException("something bad happened");
}

