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
            _dic.Add(156, "ww");
            _dic.Add(122, "ee");
            _dic.Remove(112);
            //  Console.WriteLine(_dic.IndexOf(,"ww"));
            // _dic.Insert(2, 166, "pidor");
            Console.WriteLine( "{0} проверка", _dic[127]);
            foreach(var KeyValue in _dic)
            {
                Console.WriteLine(KeyValue.Key+"-"+KeyValue.Value);

            }
            Console.ReadKey();
        }
    }
}
