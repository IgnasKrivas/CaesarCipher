using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transunion
{
    public class CaesarCipher
    {
        /// <summary>
        /// Method to encrypt given char by given key value. En (x) = ((ch + key)  mod 26
        /// </summary>
        /// <param name="ch">char</param>
        /// <param name="key">shift</param>
        /// <returns></returns>
        public char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }
            //Saves upper or lower case first value
            char firstLetter = char.IsUpper(ch) ? 'A' : 'a';
            char lastLetter = char.IsUpper(ch) ? 'Z' : 'z';

            int result = ch + key;
            if (result < firstLetter) 
            { 
                result = lastLetter - (firstLetter - result - 1); 
            }
            else
            {
                result = ((((ch + key) - firstLetter) % 26) + firstLetter);
            }
            return (char)result;
        }
        /// <summary>
        /// encrypts every string char values
        /// </summary>
        /// <param name="input">text</param>
        /// <param name="key">shift</param>
        /// <returns></returns>
        public string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        /// <summary>
        /// decrypts every string char values
        /// </summary>
        /// <param name="input">text</param>
        /// <param name="key">shift</param>
        /// <returns></returns>
        public string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
        /// <summary>
        /// get user text input
        /// </summary>
        /// <param name="text">text</param>
        /// <returns></returns>
        public string GetText(string text = null)
        {
            Console.WriteLine("Enter text to cipher:");
            text = text ?? Console.ReadLine();
            return text;
        }
        /// <summary>
        /// get user numeric input
        /// </summary>
        /// <param name="key">shift</param>
        /// <returns></returns>
        public int GetKey(string key = null)
        {
            int output;
            Console.WriteLine("Enter steps to shift by:");
            key = key ?? Console.ReadLine();
            output = int.Parse(key);
            return output;
        }
    }
}
