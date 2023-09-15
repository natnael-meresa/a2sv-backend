using System.Linq;
using System.Text.RegularExpressions;

public class PalindromeChecker
{
     public bool IsPalindrome(string input){
         string cleanedInput = RemoveNonAlphanumericChars(input.ToLower());

         string reversedInput = new string(cleanedInput.Reverse().ToArray());

         return cleanedInput.Equals(reversedInput);

     }

    private string RemoveNonAlphanumericChars(string input){
        // Remove spaces and punctuation using regular expressions
        return System.Text.RegularExpressions.Regex.Replace(input, @"[^a-z0-9]", "");
    }
}