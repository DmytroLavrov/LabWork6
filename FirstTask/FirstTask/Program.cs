using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstTask
{
    public class MyList<T>
    {
        public T[] myList = null;
        public T this[int index]
        {
            get { return myList[index]; }
            set { myList[index] = value; }
        }
        public MyList(int count)
        {
            this.myList = new T[count];
        }
        public MyList()
        {
            this.myList = new T[1];
        }
        public void Add(T item)
        {
            T[] extendedList = new T[myList.Length + 3];
            extendedList[extendedList.Length - 3] = item;
            myList = extendedList;
        }
        public int Score
        {
            get
            {
                int count = 0;
                for (int i = 0; i < myList.Length; i++)
                {
                    if (myList[i].ToString() != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public int Roominess
        {
            get { return myList.Length; }

        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MyList<int> mylist = new MyList<int>(7);
            Console.OutputEncoding = System.Text.Encoding.Default;
            mylist[0] = 1;
            Console.WriteLine("Number of tokens: {0} tokens", mylist.Roominess);
            Console.WriteLine("Number of tokens: {0} tokens", mylist.Score);
            mylist.Add(15);
            Console.WriteLine("Number of tokens: {0} tokens", mylist.Roominess);
            Console.ReadLine();
        }
    }
}