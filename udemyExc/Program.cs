using System;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    /*
     * Section 5- part1 :Control Flow
     * 1- Write a program and ask the user to enter a number. The number should be between 1 to 10. If the user enters a valid number, display "Valid" on the console. Otherwise, display "Invalid". (This logic is used a lot in applications where values entered into input boxes need to be validated.)
     */
    public static string Exc1_part1()
    {
        Console.WriteLine("enter a number between 1-10 : ");
        int num = Convert.ToInt32(Console.ReadLine());
        var res =(num>=1&&num<=10) ? "Valid" : "Not Valid";
        return res;
    }

    /*
     * 2- Write a program which takes two numbers from the console and displays the maximum of the two.
     */
    public static string Exc2_part1()
    {
        Console.WriteLine("enter 2 numbers : ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        int num2 = Convert.ToInt32(Console.ReadLine());
        var res= (num1>num2) ? "the max is :" +num1 : "the max is : " + num2;
        return res;
    }
    /*
     * 3- Write a program and ask the user to enter the width and height of an image. Then tell if the image is landscape or portrait.
     */
    public static string Exc3_part1()
    {
        Console.WriteLine("enter the width of the image : ");
        int width = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter the height of the image : ");
        int height = Convert.ToInt32(Console.ReadLine());
        var res = (width > height) ? "the image is Landscape" : "the image is Portrait";
        return res;
    }
    /*
     * 4- Your job is to write a program for a speed camera. For simplicity, ignore the details such as camera, sensors, etc and focus purely on the logic. Write a program that asks the user to enter the speed limit. Once set, the program asks for the speed of a car. If the user enters a value less than the speed limit, program should display Ok on the console. If the value is above the speed limit, the program should calculate the number of demerit points. For every 5km/hr above the speed limit, 1 demerit points should be incurred and displayed on the console. If the number of demerit points is above 12, the program should display License Suspended.
     */
    public static string Exc4_part1()
    {
        Console.WriteLine("please enter the speed limit : ");
        int speed_limt = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("please enter speed of the car : ");
        int speed_car = Convert.ToInt32(Console.ReadLine());
        if (speed_car < speed_limt) return "Ok";
        else
        {
            int points = 0;
            int gap = speed_car - speed_limt;
            points = gap / 5;
            if (points > 12) 
                return "License Suspended";
            else 
                return string.Format("demerit points: {0}", points);
        }
      

    }

    /*
       * Section 5- part2 :Control Flow
   */
    //1- Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on the console.

    public static int ques1_part2()
    {
        int cnt = 0;
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0) cnt++;
        }
        return cnt;
    }

    //2- Write a program and continuously ask the user to enter a number or "ok" to exit. Calculate the sum of all the previously entered numbers and display it on the console.
    public static int ques2_part2()
    {
        var sum = 0;
        while (true)
        {
            Console.WriteLine("please enter number , enter 'Ok' to exit");
            var input = Console.ReadLine();
            int n;
            if (int.TryParse(input, out n) == true)
            {
                int num = int.Parse(input);
                sum += num;
            }
            else if (input == "ok") break;

        }
        return sum;
    }

    //3- Write a program and ask the user to enter a number. Compute the factorial of the number and print it on the console. For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
    public static int ques3_part2()
    {
        int factorial = 1;
        Console.WriteLine("please enter a number :");
        int input = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= input; i++)
        {
            factorial *= i;
        }
        return factorial;
    }

    //4- Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. If the user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program is behaving correctly, you can display the secret number on the console first.)
    public static void ques4_part2()
    {
        Random rnd = new Random();
        int randon_num = rnd.Next(1, 11);
        int flag = 0;
        int chances = 0;
        Console.WriteLine("Random number is {0}", randon_num);
        while (flag == 0 && chances < 4)
        {
            Console.WriteLine("guess a number between 1-10 , you have 4 chances , chance number : {0}", chances + 1);
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == randon_num)
            {
                flag = 1;
                Console.WriteLine("You Won , from chance number : {0}", chances + 1);
            }
            chances++;
        }
        if (chances == 4)
        {
            Console.WriteLine("You Lost , the random number is : {0}", randon_num);
        }
    }

    //5- Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the numbers and display it on the console. For example, if the user enters “5, 3, 8, 1, 4", the program should display 8.
    public static int ques5_part2()
    {
        Console.WriteLine("please enter a series of numbers ,separated by comma :");
        var input = Console.ReadLine();

        try
        {
            string[] str = input.Split(",");
            int[] arr = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
                arr[i] = Int32.Parse(str[i]);
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }
        catch
        {
            Console.WriteLine("invalid input");
            return 0;

        }

    }



    //String Exc
    //1- Write a program and ask the user to enter a few numbers separated by a hyphen. Work out if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message: "Consecutive"; otherwise, display "Not Consecutive".
    static string ques1()
    {
        Console.WriteLine("please enter enter a few numbers separated by a hyphen");
        var input = Console.ReadLine();
            var nums = input.Split("-");
            int[] numbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                numbers[i] = int.Parse(nums[i]);
            if (numbers[0] < numbers[numbers.Length - 1])
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] + 1 != numbers[i + 1]) return "Not Consecutive";
                }
                return "Consecutive";
            }
            else
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] - 1 != numbers[i + 1]) return "Not Consecutive";
                }
                return "Consecutive";
            }  
    }

    //2- Write a program and ask the user to enter a few numbers separated by a hyphen. If the user simply presses Enter, without supplying an input, exit immediately; otherwise, check to see if there are duplicates. If so, display "Duplicate" on the console.
    static string ques2()
    {
        Console.WriteLine("please enter a few numbers, separated by a hyphen. ");
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) == true) return "null";
        else
        {
            string[] nums = input.Split("-");
            int[] numbers = new int[nums.Length];
            for (int j = 0; j < nums.Length; j++)
            {
                numbers[j] = int.Parse(nums[j]);
            }
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        Console.WriteLine(numbers[i] + "-----" + numbers[j]);
                        return "Duplicate";
                    }
                }
            }

            return "Not Duplicate";
        }
    }

    //3- Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00). A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, display "Invalid Time". If the user doesn't provide any values, consider it as invalid time.
    static string ques3()
    {
        Console.WriteLine("please enter a time value in the 24-hour time format (e.g. 19:00).");
        var input = Console.ReadLine();
        int n;
        try
        {
            string[] time = new string[3];
            time[0] = input.Substring(0, 2);
            time[1] = input.Substring(2, 1);
            time[2] = input.Substring(3);
            if (int.TryParse(time[0], out n) == true && int.TryParse(time[2], out n) == true && time[1] == ":")
            {
                int hours = int.Parse(time[0]);
                int minutes = int.Parse(time[2]);
                if ((hours >= 0 && hours < 24) && (minutes >= 0 && minutes < 60))
                    return "Ok";
            }
            return "Invalid time";
        }
        catch
        {
            return "Invalid time";
        }
    }

    //4- Write a program and ask the user to enter a few words separated by a space. Use the words to create a variable name with Pascal Case. For example, if the user types: "number of students", display "NumberOfStudents". Make sure that the program is not dependent on the input. So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".
    static string ques4()
    {
        Console.WriteLine("please enter a few words , separated by a space");
        var input = Console.ReadLine();
        string [] words = input.Split(' ');
        string new_str="";
        for (int i = 0; i < words.Length; i++)
        {
            char first_let = words[i][0];
            first_let=Char.ToUpper(first_let);
            new_str += first_let;
            new_str += words[i].Substring(1).ToLower();
        }
        return new_str;
    }

    //5- Write a program and ask the user to enter an English word. Count the number of vowels (a, e, o, u, i) in the word. So, if the user enters "inadequate", the program should display 6 on the console.
    static string ques5()
    {
        Console.WriteLine("please enter an English word");
        string input =Console.ReadLine();
        string[] words = input.Split(" ");
        if (words.Length > 1) return "invalid input";
        
            var cnt = 0;
            List<char> vowels = new List<char>();
            vowels.Add('a');
            vowels.Add('e');
            vowels.Add('o');
            vowels.Add('u');
            vowels.Add('i');
            for (int i = 0; i < input.Length; i++)
            {
                if (vowels.Contains(input[i]) == true)
                    cnt++;
            }
        
        return "vowels from the word is : " +cnt;

    }
    private static void Main(string[] args)
    {
        // Section 5 :Control Flow - part1
        //Console.WriteLine(Exc1_part1());
        //Console.WriteLine(Exc2_part1());
        //Console.WriteLine(Exc3_part1());
        //Console.WriteLine(Exc4_part1());

        // Section 5 :Control Flow - part2
       // Console.WriteLine(ques1_part2());
       // Console.WriteLine(ques2_part2());
        //Console.WriteLine(ques3_part2());
        // ques4_part2();
       // Console.WriteLine(ques5_part2());

        //Section 8 Working with text
        // Console.WriteLine(ques1());
        //Console.WriteLine(ques2());
        //Console.WriteLine(ques3());
        // Console.WriteLine(ques4());
        // Console.WriteLine(ques5());


    }
}