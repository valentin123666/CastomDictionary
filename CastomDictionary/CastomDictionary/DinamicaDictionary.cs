using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastomDictionary
{
    class DinamicaDictionary <R, T> :IEnumerable<Cell<R,T>>
        {
        public int ElemantKey { get; private set; }
        public int Count { get; private set; }

        private const int DefauultCapacity = 100;
        private const string ErrorArgumentMessage = "Incorrect argument";
        private const string ErrorKeyJustExistMessage = "Item with this key alreedy exist";
        private const string ErrorNullMessage = "Argument is null";

        private Cell<R, T>[] _cellArray;

        private int Capacity;
        private void ThrowIfInvalid(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
        public DinamicaDictionary(int _capascity = DefauultCapacity)
        {
            Capacity = _capascity;
            _cellArray = new Cell<R, T>[Capacity];      
        }

        private void ResizeAry()
        {
            Capacity += DefauultCapacity;
            Cell<R,T>[] arrey = new Cell<R,T>[Count];
            for ( var i = 0; i <Count; i++)
            {
                arrey[i] = _cellArray[i];
            }
            arrey =_cellArray;
        }
        public void Add(R key, T values)
        {
            if (key == null)
                throw new ArgumentNullException(ErrorNullMessage, "key");

            if (ContainsKey(key))
                throw new ArgumentNullException(ErrorKeyJustExistMessage, "key");

            if (Count >= Capacity)
                ResizeAry();
            
            _cellArray[Count] = new Cell<R, T>(key, values); 
           Count++;
        }

        private T r;
        public bool TryGetValue (R key, out T value)
        {
            
            if (key == null)
                throw new ArgumentNullException(ErrorNullMessage, "key");
            if (ContainsKey(key))
            {
                int index = KeyOf(key);
                value = _cellArray[index].Value;
            }
            else

                value = r;

            return ContainsKey(key);
        }
        public bool ContainsKey(R key)
        {
            var flag = false;
                                          
             for(var i =0; i<Count; i++)
            { 
                    if (IsKeysEqual(_cellArray[i].Key,key))
                    {
                        flag = true;
                        return flag;
                    }
                }            
            return flag;
        }
        public bool ConteunsValues(T values)
        {
            var flag = false;
            for (var i=0; i<Count; i++)
            {
               
                if (IsValuesEqual(_cellArray[i].Value, values))
                {
                    flag = true;
                    break;                 
                } 
                    }
            return flag;
        }

        public void Remove(R key)
        {
            var item = 0;

            item = KeyOf(key);
            
            if (item == -1)
                throw new ArgumentNullException(ErrorArgumentMessage, "key");

            for(var i=item;i<Count;i++)
            {
                _cellArray[i] = _cellArray[i + 1];
            }
            _cellArray[Count] = default(Cell<R, T>);
            Count--;
        }

        private void RemoveInternal (int item)
        {
            for(var i=item-1; i<Count;i++)
            {
                _cellArray[i] = _cellArray[i + 1];
            }
            _cellArray[Count] = default(Cell<R, T>);
            Count--;
        }

        public int IndexOf (R key, T values)
        {
            for(var i =0; i<Count; i++)
            {
                if (IsValuesEqual(_cellArray[i].Value,values)&&IsKeysEqual(_cellArray[i].Key,key))
                {
                    return (i+1);
                }
            }
            return -1;
        }
        private int KeyOf(R key)
        {
            for (var i = 0; i < Count; i++)
            {
                if ( IsKeysEqual(_cellArray[i].Key, key))
                {
                    return (i);
                }
            }
            return -1;
        }

        public T this[R key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    int index = 0;
                    index = KeyOf(key);
                    return _cellArray[index].Value;
                }
                else
                    throw new OutOfMemoryException();
            }
            set
            {
                if (ContainsKey(key))
                {
                    int index = 0;
                    index = KeyOf(key);
                    _cellArray[index] = new Cell<R, T>(key, value); 
                }
                else
                    throw new OutOfMemoryException();
            }          
        }

        private bool IsKeysEqual(R key1, R key2)
        {
            return key1.Equals(key2) && key1.GetHashCode() == key2.GetHashCode();
        }

        private bool IsValuesEqual (T values1,T values2)
        {
            return values1.Equals(values2) && values1.GetHashCode() == values2.GetHashCode();
        }

        public IEnumerator<Cell<R,T>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _cellArray[i];
            }
       }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
   

    }
}
