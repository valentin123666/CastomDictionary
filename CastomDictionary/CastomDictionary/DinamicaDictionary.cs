using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastomDictionary
{
    class DinamicaDictionary <T, R> : IEnumerable<T>,IEnumerable<R>
    {
        private void ThrowIfInvalidARY(int index)
        {
            if ((index < 0) || (index >= CountAry))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
        private void ThrowIfInvalidKEY(int index)
        {
            if ((index < 0) || (index >= CountKey))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private T[] _internalArray;
        private R[] _internalKey;

        public int CountAry { get; private set; }
        public int CountKey { get; private set; }

        private const int DefauultCapacity = 100;

        private int CapacityKey;
        private int CapacitiArrey;

        public DinamicaDictionary(int _capacityKey = DefauultCapacity, int _capacitiArrey = DefauultCapacity)
        {
            CapacitiArrey = _capacitiArrey;
            CapacityKey = _capacityKey;

            _internalArray = new T[_capacitiArrey];
            _internalKey = new R[_capacityKey];
        }

        private void ResizeAry()
        {
            CapacitiArrey += DefauultCapacity;
            T[] arrey = new T[CountAry];
            for ( var i = 0; i <CountAry; i++)
            {
                arrey[i] = _internalArray[i];
            }
            arrey = _internalArray;
        }
        private void ResizeKey()
        {
            CapacityKey += DefauultCapacity;
            R[] arrey = new R[CountKey];
            for (var i= 0; i <CountKey; i++)
            {
                arrey[i] = _internalKey[i];
            }
            arrey = _internalKey;
        }

        private void Add(R Key, T Item)
        {
            if(_internalArray.Length==CountAry)
            {
                ResizeAry();
            }
            if(_internalKey.Length==CountKey)
            {
                ResizeKey();
            }
            _internalArray[CountAry] = Item;
            CountAry++;
            _internalKey[CountKey] = Key;
            CountKey++;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < CountAry; i++)
            {
                yield return _internalArray[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<R> GetEnumeratorKey()
        {
            for (int i = 0; i < CountAry; i++)
            {
                yield return _internalKey[i];
            }
        }
        IEnumerator IEnumerable.GetEnumeratorKey()
        {
            return GetEnumeratorKey();
        }

    }
}
