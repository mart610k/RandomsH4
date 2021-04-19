using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Randoms
{
    class Program
    {
        static Random random = new Random(1);
        static RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(BitConverter.ToInt32(GenerateSecureRandomValue(4),0));
            }
            stopwatch.Stop();
            Console.WriteLine("------");
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine("------");

            stopwatch.Reset();


            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(GenerateRandomValue());
            }
            stopwatch.Stop();
            Console.WriteLine("------");

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine("------");
            
            Encrypter encrypter = new Encrypter(5,true);

            string obsucatedString = encrypter.Encrypt("Hello world");
            Console.WriteLine(obsucatedString);

            encrypter.Decrypt(obsucatedString);

            Console.WriteLine(encrypter.Decrypt(obsucatedString));
        }


        /// <summary>
        /// Using the RNGCryptoServiceProvider generates a random number.
        /// </summary>
        /// <param name="size">Amount of bytes to generate</param>
        /// <returns>Filled byte array with random bytes</returns>
        static byte[] GenerateSecureRandomValue(int size)
        {
            byte[] data = new byte[size];

            rngCryptoServiceProvider.GetBytes(data);
            return data; 

        }

        /// <summary>
        /// Using the Random class to generate a random number
        /// </summary>
        /// <returns>a psudorandrom number</returns>
        static int GenerateRandomValue()
        {
            return random.Next(int.MinValue, int.MaxValue);
        }
    }
}
