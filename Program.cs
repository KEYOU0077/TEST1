using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
    
    
        // 1. 
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        string birthdateInput;
        DateTime birthdate;
        
      //2
        while (true)
        {
            Console.WriteLine("Enter your birthdate (MM/dd/yyyy):");
            birthdateInput = Console.ReadLine();
            //  regex pattern to validate MM/dd/yyyy format.
            if (Regex.IsMatch(birthdateInput, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$"))
            {
                if (DateTime.TryParseExact(birthdateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthdate))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid date. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use MM/dd/yyyy.");
            }
        }

        // 3. 
        int age = DateTime.Now.Year - birthdate.Year;
        if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
        {
            age--; 
        }
        Console.WriteLine($"Hello {name}, you are {age} years old.");

        // 4. 
        string userInfo = $"Name: {name}\nBirthdate: {birthdateInput}\nAge: {age}\n";
        File.WriteAllText("user_info.txt", userInfo);
        Console.WriteLine("User information saved to 'user_info.txt'.");

        //5
        string fileContent = File.ReadAllText("user_info.txt");
        Console.WriteLine("\nContents of 'user_info.txt':");
        Console.WriteLine(fileContent);

        // 6. 
        Console.WriteLine("Enter a directory path to list its files:");
        string directoryPath = Console.ReadLine();

        // 7. 
        if (Directory.Exists(directoryPath))
        {
            Console.WriteLine("\nFiles in the specified directory:");
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        else
        {
            Console.WriteLine("The specified directory does not exist.");
        }

        // 8. Prompt the user to input a string.
        Console.WriteLine("Enter a string to format to title case:");
        string userInput = Console.ReadLine();

        // 9. Format the string to title case.
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        string titleCaseString = textInfo.ToTitleCase(userInput.ToLower());
        Console.WriteLine($"Formatted string in title case: {titleCaseString}");

        // 10. Explicitly trigger garbage collection.
        GC.Collect();
        Console.WriteLine("Garbage collection has been triggered.");
    

