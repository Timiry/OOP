using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_1
{
    internal class TypeConvertions
    {
        // 1) Неявное преобразование простых и ссылочных типов
        /* Таблица неявных преобразований:
        sbyte   >> short, int, long, float, double или decimal
        byte    >> short, ushort, int, uint, long, float, double или decimal
        short   >> int, long, float, double или decimal
        ushort  >> int, uint, long, ulong, float, double или decimal
        int     >> long, float, double или decimal
        uint    >> long, ulong, float, double или decimal
        long    >> float, double или decimal
        char    >> ushort, int, uint, long, ulong, float, double или decimal
        float   >> double
        ulong   >> float, double или decimal
        */

        public static void ImplicitConversions()
        {
            short smallNum = 8888;
            double bigNum = smallNum;

            SecondClass obj_1 = new SecondClass();
            FirstClass obj_2 = obj_1;
        }

        // 2) Явное преобразование простых и ссылочных типов
        /* Таблица явных преобразований:
        sbyte   >> byte, ushort, uint, ulong или char
        byte    >> Sbyte или char
        short   >> sbyte, byte, ushort, uint, ulong или char
        ushort  >> sbyte, byte, short или char
        int     >> sbyte, byte, short, ushort, uint, ulong или char
        uint    >> sbyte, byte, short, ushort, int или char
        long    >> sbyte, byte, short, ushort, int, uint, ulong или char
        ulong   >> sbyte, byte, short, ushort, int, uint, long или char
        char    >> sbyte, byte или short
        float   >> sbyte, byte, short, ushort, int, uint, long, ulong, char или decimal
        double  >> sbyte, byte, short, ushort, int, uint, long, ulong, char, float или decimal
        decimal >> sbyte, byte, short, ushort, int, uint, long, ulong, char, float или double
        */

        public static void ExplicitConversions()
        {
            float bigNum = 123.456f;
            short smallNum = (short)bigNum;

            SecondClass obj_1 = new SecondClass();
            FirstClass obj_2 = obj_1;
            SecondClass obj_3 = (SecondClass)obj_2;
        }

        // 3) Вызов и обработка исключения преобразования типов
        public static void ExeptionExample()
        {
            try
            {
                double a = 10000000;
                double b = 70000000;
                short c = checked((short)(a * b));
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // 4) Безопасное приведение ссылочных типов с помощью операторов as и is
        public static void AsIsConversion()
        {
            FirstClass obj_1 = new FirstClass();
            SecondClass obj_2 = new SecondClass();

            if (obj_1 is SecondClass)
            {
                obj_1 = obj_1 as SecondClass;
            }
            else
            {
                Console.WriteLine("Преобразование невозможно");
            }
        }

        // 5) Пользовательское преобразование типов Implicit, Explicit

        public class FirstClass
        {
            public string Name { get; set; }
            public static explicit operator string(FirstClass obj) // explicit
            {
                return obj.Name;
            }
        }

        public class SecondClass : FirstClass
        {
            public int ID { get; set; }

            public static implicit operator SecondClass(int x)  // implicit
            {
                return new SecondClass { ID = x };
            }
        }

        // 6) Преобразование с помощью класса Convert и преобразование строки в число
        //    с помощью методов Parse, TryParse класса System.Int32.

        public static void ConvertParseTryParseExamples()
        {
            double a = 12.34;
            decimal b = Convert.ToDecimal(a);

            string str = "123";
            int c = int.Parse(str);

            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            bool result = int.TryParse(input, out var num);
            if (result == true)
                Console.WriteLine($"Преобразование прошло успешно. Число: {num}");
            else
                Console.WriteLine("Преобразование завершилось неудачно");
        }



    }
}
