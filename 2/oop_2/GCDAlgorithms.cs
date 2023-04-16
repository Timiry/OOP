using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_2
{
    public class GCDAlgorithms
    {
        // Алгоритм Евклида для двух чисел
        public static int FindGCDEuclid(int a, int b)
        {
            if (a == 0) return b;
            while (b != 0)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

        // Перегрузки функции для 3, 4 и 5 параметров
        public static int FindGCDEuclid(int a, int b, int c)
        {
            return FindGCDEuclid(a, FindGCDEuclid(b, c));
        }

        public static int FindGCDEuclid(int a, int b, int c, int d)
        {
            return FindGCDEuclid(a, FindGCDEuclid(b, c, d));
        }

        public static int FindGCDEuclid(int a, int b, int c, int d, int e)
        {
            return FindGCDEuclid(a, FindGCDEuclid(b, c, d, e));
        }

        // Перегрузка для неопределенного числа параметров + нахождение времени выполнения
        public static int FindGCDEuclid(out long time, params int[] values)
        {
            time = 0;
            Stopwatch sw = new Stopwatch(); sw.Start();

            int res = values[0];
            foreach (var v in values)
            {
                res = FindGCDEuclid(res, v);
            }

            sw.Stop();
            time = sw.ElapsedTicks;
            return res;
        }

        // Алгоритм Штейна для двух чисел
        static public int FindGCDStein(int u, int v)
        {
            int k;
            if (u == 0 || v == 0)
                return u | v;           
            for (k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }
            while ((u & 1) == 0)
                u >>= 1;          
            do
            {
                while ((v & 1) == 0)  // Loop x
                    v >>= 1;
                // Now u and v are both odd, so diff(u, v) is even.
                //   Let u = min(u, v), v = diff(u, v)/2. 
                if (u < v)
                {
                    v -= u;
                }
                else
                {
                    int diff = u - v;
                    u = v;
                    v = diff;
                }
                v >>= 1;
                // Step 5.
                // Repeat steps 3–4 until u = v, or (one more step) 
                // until u = 0.
            } while (v != 0);
            u <<= k;
            return u;
        }

        // Перегрузка для неопределенного числа параметров + нахождение времени выполнения
        public static int FindGCDStein(out long time, params int[] values)
        {
            time = 0;
            Stopwatch sw = new Stopwatch(); sw.Start();

            int res = values[0];
            foreach (var v in values)
            {
                res = FindGCDStein(res, v);
            }

            sw.Stop();
            time = sw.ElapsedTicks;
            return res;
        }
    }
}
