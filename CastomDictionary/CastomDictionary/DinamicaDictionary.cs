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
        private T[] _values;
        private R[] _keys;

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
        public void Add(R Key, T Item)
        {
            if (Key == null)
                throw new ArgumentNullException(ErrorNullMessage, "key");

            if (ContainsKey(Key))
                throw new ArgumentNullException(ErrorKeyJustExistMessage, "key");

            if (Count >= Capacity)
                ResizeAry();
            
            _cellArray[Count] = new Cell<R, T>(Key, Item); 
            Count++;
        }

        public bool ContainsKey(R key)
        {
            var flag = false;
            for ( var i=0; i<Count; i++)
            {
                if(key.Equals(_cellArray[i]))
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }

        public void RemoveIntermal (int item)
        {
            for(var i=item; i<Count;i++)
            {
                _cellArray[i] = _cellArray[i + 1];
            }
            _cellArray[Count] = default(Cell<R, T>);
            Count--;
        }

        public int IndexOf (T item)
        {
            for(var i =0; i<Count; i++)
            {
                if (item.Equals(_cellArray[i]))
                {
                    return (i+1);
                }
            }
            return -1;
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
