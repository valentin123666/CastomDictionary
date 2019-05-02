using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<int, string>();
            dic.Add(124, "r");
            dic.Add(125, "q");
            dic.Add(126, "w");
            dic.Add(127, "a");
            dic.Add(128, "s");
            dic.Add(129, "d");
            dic.
            string s;
           // Console.WriteLine(  dic.TryGetValue(1, out s));
            //Console.WriteLine(s);

            foreach(var g in dic)
            {
                Console.WriteLine(g);
            }
            Console.ReadKey();
        }
    }
}
