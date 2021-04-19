using System;
using System.Collections.Generic;
using System.Text;

namespace Randoms
{
    class Encrypter
    {

        /// <summary>
        /// Amount of shifts to perform
        /// </summary>
        public int Shifts { get; private set; }

        /// <summary>
        /// The known characters, currently hardcoded, through nothing stopping for creating a constructor that changes this.
        /// </summary>
        private List<char> characters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å' };

        /// <summary>
        /// Sets up the Encrypter with the amount of shifts and gives the option to reverse the order of the shifting.
        /// </summary>
        /// <param name="shifts">a number between 0 to the amount of shifts per defined as the lenght of the characters</param>
        /// <param name="reverted">If the shifting should be reversed false means that</param>
        public Encrypter(int shifts, bool reverted)
        {
            if(shifts <= characters.Count && 0 < shifts)
            {
                Shifts = shifts;
            }
            else
            {
                throw new Exception("Shifts must be within positive numbers or within " + characters.Count + " characters");
            }
            if (reverted)
            {
                characters.Reverse();
            }
        }
        /// <summary>
        /// Sets up the Encrypter with the amount of shifts and does not reverse the order of the shifting
        /// see also Constructor with (int, bool) arguments
        /// calls Constructor with (shifts,false)
        /// </summary>
        /// <param name="shifts">a number between 0 to the amount of shifts per defined as the lenght of the characters</param>
        public Encrypter(int shifts) : this(shifts, false)
        {
            
        }

        /// <summary>
        /// Encrypts the incoming string shifiting the characters with the constructed settings, unknown characters are ignored. all output are lowercase
        /// </summary>
        /// <param name="textToEncrypt">the text you which you had inserted.</param>
        /// <returns>The string with shifted characters</returns>
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

        /// <summary>
        /// Decrypts the incoming string ignoring any and all unknown characters, all output are lowercase
        /// </summary>
        /// <param name="textToDecrypt">The text to decrypt</param>
        /// <returns>Lower case of the decrypted input text</returns>
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
