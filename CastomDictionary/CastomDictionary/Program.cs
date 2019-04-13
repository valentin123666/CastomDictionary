using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastomDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var _dic = new DinamicaDictionary<int, string>();
            _dic.Add(127, "dd");
            _dic.Add(121, "ss");
            _dic.Add(124, "GG");
            _dic.Add(112, "ww");

            _dic.Add(122, "ee");
            Console.WriteLine(_dic.IndexOf("EE"));

            foreach(var f in _dic)
            {
                Console.WriteLine(f);
            }
            Console.ReadKey();
        }
    }
}
