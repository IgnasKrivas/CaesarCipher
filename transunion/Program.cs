using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transunion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Caesar Cipher--");
            Console.WriteLine("--Press Ctrl+C to close console--");
            Console.WriteLine("-----------------\n");
            CaesarCipher cipher = new CaesarCipher();

            while (true)
            {
                string text = cipher.GetText();
                int key = int.MinValue;
                try
                {
                    key = cipher.GetKey();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Number must be an integer.");
                    Console.WriteLine("-----------------");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large.");
                    Console.WriteLine("-----------------");
                }
                if (key != int.MinValue)
                {
                    string encrypted = cipher.Encipher(text, key);
                    string descrypted = cipher.Decipher(encrypted, key);
                    Console.WriteLine("Encrypted: {0}\n", encrypted);
                    Console.WriteLine("Descrypted: {0}", descrypted);
                    Console.WriteLine("-----------------");
                }
            }

        }
    }
}
