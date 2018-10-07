using DoE.Lsm;
using System;
using System.Linq;
using static System.Console;


namespace Lsm.Tests.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] b;
            string[] a = new string[]{ "0", "Requisitions", "1", "Reports", "2", "Validations" };

            b = new string[a.Length];

            for(int s =0; s < a.Length; s++)
            {
                if (s % 2 != 0)
                {
                    if( string.IsNullOrEmpty(b[((s == 0) ? 0 : (s-1))]))
                    {
                        b[s - 1] = a[s];
                    }else
                    {
                        b[s] = a[s];
                    }
                }
                continue;
            }


            int index = 3;
            WriteLine(string.IsNullOrEmpty(b[index]) ? b[index + 1] : b[index]);

            //for (int y = 0; y < b.Length; y++)
            //{
            //    WriteLine(b[y]);
            //}





            ReadLine();
        }
    }
}
