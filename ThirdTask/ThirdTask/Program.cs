using System;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

namespace ThirdTask 
{
    internal class MyList<T> : Master<T>
    {
        private T[] array = new T[1];
        private int count = 0;
        private int pos = -1;
        public int Score
        {
            get { return count; }
        }
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
        public void Add(T item)
        {
            count++;
            Array.Resize(ref array, count);
            pos++;
            array[pos] = item;
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                action(array[i]);
            }
        }
        public T[] GetArray(MyList<T> list)
        {
            T[] arr = new T[count];
            Array.Copy(array, arr, count);
            return array;
        }
    }
    interface Master<T>
    {
        public T this[int index] { get; set; }
        int Score { get; }
        void ForEach(Action<T> action);
        void Add(T value);
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> list = new MyList<string>();
            Console.OutputEncoding = System.Text.Encoding.Default;
            list.Add("Перший");
            list.Add("Другий");
            list.Add("Третій");
            list.Add("Четвертий");
            list.Add("П'ятий");
            list.ForEach(x => Console.WriteLine(x));
            list.GetArray(list);
            Console.ReadKey();
        }
    }
}