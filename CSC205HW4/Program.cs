using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC205HW4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Prompt the user to enter a string to be encoded
			Console.Write("Enter a string to encode: ");

			// Read the input string from the user; O(n)
			string userInput = Console.ReadLine();

			// Encode the input string using the Encode method
			string encodedString = Encode(userInput);

			// Display the original and encoded strings to the user
			Console.WriteLine($"Original: {userInput}");
			Console.WriteLine($"Encoded: {encodedString}");
		}

		// Method to encode a string using Caesar cipher with a shift of 13
		static string Encode(string input)
		{
			// Create a character array to hold the encoded characters
			char[] encodedChar = new char[input.Length];

			// Loop through each character in the input string; O(n)
			for (int i = 0; i < encodedChar.Length; i++)
			{
				// Get the current character from the input string
				char currentChar = input[i];

				// Check if the character is a letter
				if (char.IsLetter(currentChar))
				{
					// Check if the character is an uppercase letter
					if (char.IsUpper(currentChar))
					{
						// Encode the uppercase letter by shifting it 13 places in the alphabet
						encodedChar[i] = (char)(((currentChar - 'A' + 13) % 26) + 'A');
					}
					else
					{
						// Encode the lowercase letter by shifting it 13 places in the alphabet
						encodedChar[i] = (char)(((currentChar - 'a' + 13) % 26) + 'a');
					}
				}
				else
				{
					// Keep non-letter characters (e.g., spaces) unchanged
					encodedChar[i] = currentChar;
				}
			}

			// Convert the character array back to a string and return it
			return new string(encodedChar);
		}
	}
}
