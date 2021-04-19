using System;
using System.Collections.Generic;
using System.Text;

namespace Randoms
{
    class Encrypter
    {
        //string allowedCharacters = ""

        public int Shifts { get; private set; }

        private List<char> characters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å' };


        public Encrypter(int shifts, bool reverted)
        {
            if(shifts <= characters.Count && 0 < shifts)
            {
                Shifts = shifts;
            }
            if (reverted)
            {
                characters.Reverse();
            }
        }
        public Encrypter(int shifts) : this(shifts, false)
        {
            
        }
        public string Encrypt(string textToEncrypt)
        {
            textToEncrypt =textToEncrypt.ToLower();
            StringBuilder stringBuilder = new StringBuilder();
            char[] toEncrypt = textToEncrypt.ToCharArray();
            for (int i = 0; i < toEncrypt.Length; i++)
            {
                int index = characters.IndexOf(toEncrypt[i]);
                if (index != -1)
                {
                    stringBuilder.Append(characters[(index + Shifts) % characters.Count]);
                }
                else
                {
                    stringBuilder.Append(toEncrypt[i]);
                }
            }
            return stringBuilder.ToString();
        }

        public string Decrypt(string textToDecrypt)
        {
            textToDecrypt = textToDecrypt.ToLower();
            StringBuilder stringBuilder = new StringBuilder();
            char[] toEncrypt = textToDecrypt.ToCharArray();
            for (int i = 0; i < toEncrypt.Length; i++)
            {
                int index = characters.IndexOf(toEncrypt[i]);
                if (index != -1)
                {
                    int result =  characters.Count + index- Shifts;
                    
                    stringBuilder.Append(characters[result % characters.Count]);
                }
                else
                {
                    stringBuilder.Append(toEncrypt[i]);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
