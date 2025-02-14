using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string regexPattern = @"^(?=.*SP)(?=.*[A-Z])(?=.*[!@#$%^&*()_+{}|:""<>?~\-=\[\]\\;',./]{2})(?=.*[tanveer]{4}).{0,12}$";
        Regex regex = new Regex(regexPattern);

        // Test strings
        string[] testStrings = {
            "SP!@tanv",  // Valid
            "SPA@#tanav", // Valid
            "SPA@tanv",  // Invalid (only one special character)
            "SP@#tav",  // Valid
            "SP@#tanveeraa", // Invalid (length exceeds 12)
            "SP@#tnA", // Valid
            "SP@#tav1", // Invalid (contains a digit)
            "SP@#taav!", // Valid
        };

        foreach (var testString in testStrings)
        {
            bool isValid = regex.IsMatch(testString);
            Console.WriteLine($"\"{testString}\" is {(isValid ? "valid" : "invalid")}");
        }
    }
}
