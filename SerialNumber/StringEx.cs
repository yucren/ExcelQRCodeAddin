using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialNumber
{
   public static class StringEx
    {

        public static void WriteLine<T>(this T t)
        {
            Console.WriteLine(t.ToString());
        }
        public static void Write<T>(this T t)
        {
            Console.Write(t.ToString());
        }
    }
}
