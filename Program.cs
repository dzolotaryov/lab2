using System;
using System.Diagnostics;

/*
 Создать абстрактный класс Number c виртуальными методами, реализующими арифметические операции. На его основе реализовать классы Integer и Real.

 Создать класс Series (набор), содержащий массив/параметризованную коллекцию объектов этих классов в динамической памяти.

 Предусмотреть возможность вывода характеристик объектов списка.
*/

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var integer = new Integer(10);
            var real = new Real(10.0);
            Console.WriteLine(integer);
            Console.WriteLine(real);

            try
            {
                var zerodiv = integer / new Integer(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Debug.Assert(new Integer(5).Equals(new Integer(3) + new Integer(2)));
            Debug.Assert(new Integer(1) == new Integer(3) - new Integer(2));
            Debug.Assert(!Equals(new Integer(7), new Integer(3) * new Integer(2)));
            Debug.Assert(new Integer(1) != new Integer(3) / new Integer(2));
            Console.WriteLine("All Integer assertions passed");

            Debug.Assert(new Real(5.0).Equals(new Real(3.0) + new Real(2.0)));
            Debug.Assert(new Real(1.0) == new Real(3.0) - new Real(2.0));
            Debug.Assert(!Equals(new Real(7.0), new Real(3.0) - new Real(2.0)));
            Debug.Assert(new Real(1.0) != new Real(3.0) / new Real(2.0));
            Console.WriteLine("All Real assertions passed");

            var series = new Series();
            series.Add(integer);
            series.Add(integer);
            series.Add(integer);
            series.Add(real);
            Console.WriteLine(series);

            Debug.Assert(series == series);
            series.RemoveAt(0);
            series.Remove(integer);

            series.Clear();
            Console.WriteLine(series);
        }
    }
}
