using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecondTask
{
    class MyDictionary<TKey, TValue> : Multics<TKey, TValue>, Enumerable<TKey, TValue>
    {
        int position = -1;
        private TKey[] clue;
        private TValue[] sense;
        private int count = 0;
        TValue Multics<TKey, TValue>.this[TKey key]
        {
            get
            {
                int index = 0;
                for (int i = 0; i < clue.Length; i++)
                {
                    if (key.Equals(clue[i]))
                    {
                        index = i;
                    }
                }
                return sense[index];
            }
        }
        public void Reset()
        {
            position = -1;
        }
        public int Count
        {
            get { return count; }
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < clue.Length; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(clue[i], sense[i]);
            }
        }
        IEnumerator Enumerable<TKey, TValue>.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public void Add(TKey key, TValue value)
        {
            count++;
            Array.Resize(ref clue, count);
            clue[count - 1] = key;
            Array.Resize(ref sense, count);
            sense[count - 1] = value;
        }
        public bool MoveNext()
        {
            position++;
            return (position < clue.Length);
        }
    }
    interface Scribe<TKey, TValue>
    {
        public bool MoveNext();
        public object Current();
        public void Reset();
    }
    interface Enumerable<TKey, TValue>
    {
        IEnumerator GetEnumerator();
    }
    interface Multics<TKey, TValue>
    {
        public void Add(TKey key, TValue value);
        public TValue this[TKey index]
        {
            get;
        }
        public int Count { get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            MyDictionary<int, string> dictionary = new MyDictionary<int, string>();
            dictionary.Add(1, "Один");
            dictionary.Add(2, "Два");
            dictionary.Add(3, "Три");
            dictionary.Add(4, "Чотири");
            dictionary.Add(5, "П'ять");
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine($"Кількість: {dictionary.Count}");
            Console.WriteLine();
            foreach (KeyValuePair<int, string> ele in dictionary)
            {
                Console.WriteLine($"Значення = {ele.Value}, Токен = {ele.Key}");
            }
            Console.ReadLine();
        }
    }
}