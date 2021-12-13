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
            Console.WriteLine("Hash table demo"); //() []
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To be or not to be");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "to");
            hash.Add("5", "be");
            hash.frequencyOfWords("0");
            string hash5 = hash.Get("5");
            Console.WriteLine("5th index value: " + hash5);
            string hash2 = hash.Get("2");
            Console.WriteLine("2th index value: " + hash2);
            hash.Add("6", "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations");
            hash.frequencyOfWords("6");
           
            Console.ReadKey();
        }
    }
}
