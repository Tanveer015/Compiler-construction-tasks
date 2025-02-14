using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // Take inputs at runtime
        Console.WriteLine("Enter your first name:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter your last name:");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter your registration number (3 digits only):");
        string registrationNumber = Console.ReadLine();

        Console.WriteLine("Enter your favorite movie:");
        string favoriteMovie = Console.ReadLine();

        Console.WriteLine("Enter your favorite food:");
        string favoriteFood = Console.ReadLine();

        // Validate registration number (must be 3 digits)
        if (registrationNumber.Length != 3 || !registrationNumber.All(char.IsDigit))
        {
            Console.WriteLine("Invalid registration number. It must be exactly 3 digits.");
            return;
        }

        // Generate password
        string password = GeneratePassword(firstName, lastName, registrationNumber, favoriteMovie, favoriteFood);
        Console.WriteLine($"Generated Password: {password}");
    }

    static string GeneratePassword(string firstName, string lastName, string regNumber, string movie, string food)
    {
        Random random = new Random();
        StringBuilder password = new StringBuilder();

        // Combine parts of inputs
        string combinedInputs = firstName + lastName + regNumber + movie + food;

        // Shuffle the combined string to add randomness
        string shuffledInputs = new string(combinedInputs.OrderBy(c => random.Next()).ToArray());

        // Ensure the password has at least one uppercase, one lowercase, one number, and one special character
        char[] specialChars = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
        char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        // Add at least one uppercase letter
        password.Append(char.ToUpper(shuffledInputs[random.Next(shuffledInputs.Length)]));

        // Add at least one lowercase letter
        password.Append(char.ToLower(shuffledInputs[random.Next(shuffledInputs.Length)]));

        // Add at least one number
        password.Append(numbers[random.Next(numbers.Length)]);

        // Add at least one special character
        password.Append(specialChars[random.Next(specialChars.Length)]);

        // Add remaining characters from shuffled inputs
        while (password.Length < 12) // Ensure password length is 12 characters
        {
            password.Append(shuffledInputs[random.Next(shuffledInputs.Length)]);
        }

        // Shuffle the final password to ensure randomness
        string finalPassword = new string(password.ToString().OrderBy(c => random.Next()).ToArray());

        return finalPassword;
    }
}
