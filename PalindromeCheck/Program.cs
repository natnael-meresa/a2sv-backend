// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

 Console.Write("Enter a string: ");
string? input;
input  = Console.ReadLine();

if (input == null){
        throw new ArgumentNullException("string must not be null");
}


PalindromeChecker palindromeChecker = new PalindromeChecker();
bool isPalindrome = palindromeChecker.IsPalindrome(input);

Console.WriteLine(isPalindrome ? "It is a palindrome." : "It is not a palindrome.");