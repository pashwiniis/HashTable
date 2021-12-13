using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];

        }
        public void frequencyOfWords(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    foundItem = item;
                    string str = foundItem.Value.ToString();
                    Console.WriteLine("found data = " + str);

                    string[] arr = str.Split(' ');
                    Dictionary<string, int> dict = new Dictionary<string, int>();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (dict.ContainsKey(arr[i]))
                        {
                            dict[arr[i]] = dict[arr[i]] + 1;
                        }
                        else
                        {
                            dict.Add(arr[i], 1);
                        }
                    }
                    foreach (KeyValuePair<String, int> entry in dict)
                    {
                        Console.WriteLine(entry.Key + " - " +
                                          entry.Value);

                    }
                }
            }
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);  // |-5| =5 |3|=3 |-3|=3
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        public void Remove(MyMapNode<int, string> hash, string word)
        {
            for (int key = 0; key < hash.size; key++)
            {
                if (hash.Get(key).Equals(word))
                {
                    hash.Remove(key);
                    Console.WriteLine("Removed " + word + " from paragraph");
                }
            }
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        protected int GetArrayPosition(K key)
        {


            int position = key.GetHashCode() % size;

            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public class KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }

        }
    }
}
