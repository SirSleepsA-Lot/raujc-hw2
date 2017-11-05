using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{

    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int lastEmpty = 0;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
        }

        public IEnumerator<X> GetEnumerator()
        {
            for (int i = 0; i < lastEmpty; i++)
            {
                yield return _internalStorage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Add(X item)
        {
            if (_internalStorage.Length < lastEmpty + 1)
            {
                X[] _oldIntStr = new X[_internalStorage.Length];
                for (int i = 0; i < lastEmpty; i++)
                {
                    _oldIntStr[i] = _internalStorage[i];
                }

                _internalStorage = new X[2 * (lastEmpty + 1)];

                for (int i = 0; i < lastEmpty; i++)
                {
                    _internalStorage[i] = _oldIntStr[i];
                }
            }
            _internalStorage[lastEmpty] = item;
            lastEmpty++;
        }

        public bool Remove(X item)
        {
            if (item == null) return false;
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index >= lastEmpty || index < 0)
            {
                return false;
                throw new IndexOutOfRangeException();

            }

            for (int i = index; i < lastEmpty - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            lastEmpty--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index >= lastEmpty || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(X item)
        {
            int index = -1;

            for (int i = 0; i < lastEmpty; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    index = i;
                }
            }

            return index;
        }

        public int Count
        {
            get
            {
                return lastEmpty;
            }
        }

        public void Clear()
        {
            _internalStorage = new X[4];
            lastEmpty = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < lastEmpty; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<object> genericList;

        public GenericListEnumerator(GenericList<object> genericList)
        {
            this.genericList = genericList;
        }

        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }


    }

}
