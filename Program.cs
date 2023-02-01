using System;
using System.Text;

Console.OutputEncoding= Encoding.Unicode;

string selection;
do
{
    Console.Clear();
    Console.WriteLine("What do you want to execute?");
    Console.WriteLine("============================");
    Console.WriteLine();
    Console.WriteLine("0. Calculate Circle Area");
    Console.WriteLine("1. Random in Range");
    Console.WriteLine("2. To FizzBuzz");
    Console.WriteLine("3. Fibonacci by Index");
    Console.WriteLine("4. Ask for Number in Range");
    Console.WriteLine("5. Is palindrome?");
    Console.WriteLine("6. Is palindrome? (advanced)");
    Console.WriteLine("7. Chart Bar");
    Console.WriteLine("8. Count Smiling Faces");
    Console.WriteLine("q to Quit");
    selection = Console.ReadLine()!;

    if (selection != "q")
    {
        Console.Clear();
        switch (selection)
        {
            case "0": RunCalculateCircleArea(); break;
            case "1": RunRandomInRange(); break;
            case "2": RunFizzBuzz(); break;
            case "3": RunFibonacciByIndex(); break;
            case "4": RunAskForNumberInRange(); break;
            case "5": RunIsPalindrome(); break;
            case "6": RunIsPalindromeAdvanced(); break;
            case "7": RunChartBar(); break;
            case "8": RunCountSmilingFace(); break;
            default: break;
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

}
while (selection != "q");


#region Calculate Circle Area
void RunCalculateCircleArea()
{
    Console.Write("Enter radius:");
    var radius = double.Parse(Console.ReadLine()!);
    var area = CalculateCircleArea(radius);
    Console.WriteLine($"Area of circle with radius {radius} is {area}");
}

double CalculateCircleArea(double radius)
{
    return radius * radius * Math.PI;
}
#endregion

#region Random In Range
int RandomInRange(int min, int max)
{
    int random = Random.Shared.Next(min, max + 1);
    return random;
}
void RunRandomInRange()
{
    int i = 0;
    int countZero = 0, countOne = 0, countTwo = 0;
    int randomNumber;

    while (i < 1000000)
    {
        i++;
        randomNumber = RandomInRange(0, 2);

        switch (randomNumber)
        {
            case 0: countZero++; break;
            case 1: countOne++; break;
            case 2: countTwo++; break;
        }

    }

    Console.WriteLine($"Zero = {countZero} times");
    Console.WriteLine($"One = {countOne} times");
    Console.WriteLine($"Zero = {countTwo} times");
}
#endregion

#region To FizzBuzz
string ToFizzBuss(int number)
{
    string fizzBuzz = string.Empty;

    if (number % 3 == 0 && number % 5 != 0) { fizzBuzz = "Fizz"; }
    else if (number % 3 != 0 && number % 5 == 0) { fizzBuzz = "Buzz"; }
    else if (number % 3 == 0 && number % 5 == 0) { fizzBuzz = "FizzBuzz"; }
    else { fizzBuzz = $"{number}"; }

    return fizzBuzz;
}
void RunFizzBuzz()
{
    Console.WriteLine("** FizzBuzz ***");
    Console.Write("Enter a number:  ");
    int enteredNumber = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(ToFizzBuss(enteredNumber));
}
#endregion

#region FibonacciByIndex
int FibonacciByIndex(int index)
{
    int val1 = 0, val2 = 1, val3, i, n = 7;


    Console.WriteLine("Fibonacci series:");
    for (i = 2; i <= index; ++i)
    {

        val3 = val1 + val2;
        if (i == index)
        {
            Console.WriteLine(val3 + " ");
        }
        val1 = val2;
        val2 = val3;
    }
    return index;
}
void RunFibonacciByIndex()
{
    Console.WriteLine("Welchen Index der Fibonacci-Folge möchtest du ausgeben?  ");
    int enteredIndex = Convert.ToInt32(Console.ReadLine());
    FibonacciByIndex(enteredIndex);


}
#endregion

#region Ask For Number in Range
int AskForNumberInRange(int min, int max)
{
    Console.WriteLine($"Please enter a value between {min} and {max}");
    int input = Convert.ToInt32(Console.ReadLine());

    bool validInput = input >= min && input <= max;
    string ToHighOrToLow = string.Empty;
    string minOrMax = string.Empty;
    int limit = 0;

    while (!validInput)
    {
        if (input < min) { ToHighOrToLow = "low"; minOrMax = "minimum"; limit = min; }
        else { ToHighOrToLow = "high"; minOrMax = "maximum"; limit = max; }

        Console.WriteLine($"Wrong number. Your input is too {ToHighOrToLow}. The {minOrMax} ist {limit}. Try again!");
        input = Convert.ToInt32(Console.ReadLine());
        validInput = input > min && input < max;
    }
    Console.WriteLine("Thank you, your input is valid.");
    return input;
}

void RunAskForNumberInRange()
{
    AskForNumberInRange(5, 10);
}
#endregion

#region Is Palindrome
bool IsPalindrome(string text)
{
    for (int i = 0; i < text.Length / 2; i++)
    {
        if (text[i] != text[text.Length - 1 - i])
        {
            return false;
        }

    }
    return true;
}
void RunIsPalindrome()
{
    Console.WriteLine("Enter a text:  ");
    string enteredText = Console.ReadLine()!;

    Console.Write("The text is");
    if (!IsPalindrome(enteredText)) { Console.Write(" not"); }
    Console.WriteLine(" a palindrome");

}
#endregion

#region Is Palindrome (Advanced)
bool IsPalindromeAdvanced(string text)
{
    if (string.IsNullOrEmpty(text))
    {
        return false;
    }

    text = text
       .Replace(" ", "")
       .Replace(",", "")
       .Replace("-", "")
       .ToLower();

    for (int i = 0; i < text.Length / 2; i++)
    {
        if (text[i] != text[text.Length - 1 - i])
        {
            return false;
        }

    }
    return true;
}

void RunIsPalindromeAdvanced()
{
    Console.WriteLine("Enter a text:  ");
    string enteredText = Console.ReadLine()!;

    Console.Write("The text is");
    if (!IsPalindromeAdvanced(enteredText)) { Console.Write(" not"); }
    Console.WriteLine(" a palindrome");
}
#endregion

#region Count Smiling Face
int CountSmilingFaces(string smiley)
{
    int countSmiley = 0;

    for(int i = 0; i < smiley.Length; i++)
    {
        if (smiley[i]==':' && smiley[i+1] == '-' && smiley[i+2] == ')')
        {
            countSmiley++;
        }
    }
    return countSmiley;
}

void RunCountSmilingFace()
{
    Console.WriteLine("Enter Smileys [ :-) ]");
    string enteredSmiley = Console.ReadLine()!;
    Console.WriteLine($"Your entered {CountSmilingFaces(enteredSmiley)} smileys");
}
#endregion

#region ChartBar
string ChartBar(double number)
{
    string chartbar="";

    if(number < 0 || number > 1) { return chartbar=string.Empty; }
    else
    {
        for (int i = 0; i < number*10; i++)
        {
            chartbar += "$";
        }
        for (int a = 0; a < 10-number*10; a++)
        {
            chartbar += ".";
        }
    }

    return chartbar;
}

void RunChartBar()
{
    Console.Write("Enter a number:  ");
    double enteredNumber = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine();
    Console.WriteLine(ChartBar(enteredNumber));
}
#endregion