using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    public static class Generator
    {
        /// <summary>
        /// Genereates array with distinct elements and size of array is <paramref name="n"/>-<paramref name="skip"/>.
        /// Array contains every number except two numbers from set
        /// </summary>
        /// <param name="n"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public static (IEnumerable<byte> Generated, IEnumerable<byte> Skipped) GenerateArray(byte n, byte skip = 2)
        {
            if (n < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(n),"Parameter 'n' must be between 2 and byte.MaxValue");
            }
            
            if (skip >= n)
            {
                throw new ArgumentException(nameof(skip),"Parameter 'skip' must be less than 'n'");
            }

            byte[] numbersSet = new byte[n + 1];
            for (int i = 0; i <= n; i++)
            {
                numbersSet[i] = (byte)i;
            }

            LinkedList<byte> list = new LinkedList<byte>(numbersSet);
            byte counter = 0;
            byte[] res = new byte[n - skip + 1];
            Random rnd = new Random();
            do
            {
                byte currentIndex = (byte) rnd.Next(n + 1);
                var item = list.Find(currentIndex);
                if (item != null)
                {
                    res[counter] = item.Value;
                    list.Remove(item);
                    counter++;
                }
            } while (counter < n - skip + 1);

            return (res, list.ToArray());
        }

    }
}