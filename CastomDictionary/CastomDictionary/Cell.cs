﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastomDictionary
{
    class Cell<Tkey, Tvalue>
    {
        public  Cell  ( Tkey key, Tvalue value)
        {
            this.Key = key;
            this.Value = value;
        }
        public Tkey Key { get; private set; }
        public Tvalue Value { get; private set; }
    }
}
