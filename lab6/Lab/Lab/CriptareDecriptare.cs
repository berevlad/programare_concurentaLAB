using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class CriptareDecriptare
    {
        

        public static string Criptare(string text)
        {
            string textCriptat = "";
            char randomChar;
            Random rand = new Random();
            for (int i = 0; i <= (text.Length - 1); i++)
            {
                randomChar = (char)(rand.Next(128));
                textCriptat += ((char)(text[i] ^ randomChar)).ToString();
                textCriptat += ((char)(randomChar ^ (128 - i))).ToString();
            }            

            return textCriptat;
        }

        public static string Decriptare(string textCriptat)
        {
            string textDecriptat = "";
            char decriptat;
            for (int i = 0; i < (textCriptat.Length - 1); i += 2)
            {
                decriptat = ((char)(textCriptat[i + 1] ^ (128 - (i + 1) / 2)));
                textDecriptat += ((char)(textCriptat[i] ^ decriptat)).ToString();
            }

            return textDecriptat;
        }
    }
}
