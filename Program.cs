using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HashTable Project");
            MyMapNode<int, string> hash = new MyMapNode<int, string>(5);
            string input = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] array = input.Split(' ');
            int i = 0;
            foreach (var value in array)
            {
                hash.Add(i, value);
                i++;
            }
            Console.WriteLine("Frequency of words in given string is :");
            hash.FindFrequency("paranoid");
            hash.FindFrequency("because");
            hash.FindFrequency("are");
            hash.FindFrequency("but");
            hash.Remove(18);
            Console.ReadKey();
        }
    }
}
