using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirthTask
{
    class MyClass<T> where T : new()
    {
        public static T FactoryMethod()
        {
            return new T();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            var num = MyClass<int>.FactoryMethod();
            Console.WriteLine($"Вид: {num} \nЗначення: {num.GetType()}");
            Console.WriteLine();
            Console.OutputEncoding = System.Text.Encoding.Default;
            var word = MyClass<double>.FactoryMethod();
            Console.WriteLine($"Вид: {word} \nЗначення: {word.GetType()}");
            Console.ReadKey();
        }
    }
}