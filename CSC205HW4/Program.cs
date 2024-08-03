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

			// Read the input string from the user
			string userInput = Console.ReadLine();

			// Prompt the user to enter the shift value for encoding
			Console.Write("Enter shift value: ");
			// Try parsing the shift value entered by the user
			if (!int.TryParse(Console.ReadLine(), out int shift))
			{
				// Notify the user if the shift value is invalid
				Console.WriteLine("Invalid shift value. Please enter a number.");
				return; // Exit the program if the input is not a valid number
			}

			// Encode the input string using the provided shift value
			string encodedString = Encode(userInput, shift);

			// Display the original and encoded strings
			Console.WriteLine($"Original: {userInput}");
			Console.WriteLine($"Encoded: {encodedString}");

			// Optional: Decode the encoded string to verify correctness
			string decodedString = Encode(encodedString, -shift);
			Console.WriteLine($"Decoded: {decodedString}");
		}

		// Method to encode a string using Caesar cipher with a given shift
		static string Encode(string input, int shift)
		{
			// Create a character array to hold the encoded characters
			char[] encodedChar = new char[input.Length];
			// Normalize the shift to be within 0-25 to handle large shifts
			shift = shift % 26;

			// Loop through each character in the input string
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
						// Encode the uppercase letter by applying the shift
						encodedChar[i] = (char)(((currentChar - 'A' + shift + 26) % 26) + 'A');
					}
					else
					{
						// Encode the lowercase letter by applying the shift
						encodedChar[i] = (char)(((currentChar - 'a' + shift + 26) % 26) + 'a');
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
