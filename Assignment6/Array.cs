using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : ICollection<T> 
    {
        private T[] _Array { get; }

        
        public int Count
        {
            get;
            private set;
        }
        public bool IsReadOnly => false;

        public T this[int key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        private T GetValue(int index)
        {
            return _Array[index];
        }
        
        private void SetValue(int index, T value)
        {
            _Array[index] = value;
        }
        public Array(int length)
        {
            if (length < 0)
                throw new IndexOutOfRangeException();

            _Array = new T[length];           
        }
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            if(Count < _Array.Length)
            {
                _Array[Count] = item;
                Count++;
            }
        }

        public void Clear()
        {
            for(int i = 0; i < Count; i++)
            {
                _Array[i] = default;
            }
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
                return false;

            for(int i = 0; i < Count; i++)
            {
                if(_Array[i].Equals(item))
                {
                    return true;
                }               
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > Count - 1)
                throw new IndexOutOfRangeException(nameof(Count));

            Array.Copy(_Array, 0, array, arrayIndex, Count);
        }
      
        public bool Remove(T item)
        {
            if (item == null)
                return false;

            bool found = false;

            int i = 0;

            for(i = 0; i < Count; i++)
            {
                if(_Array[i].Equals(item))
                {
                    found = true;
                    break;
                }
            }

            if(found)
            {
                for(i = i+1; i < Count; i++)
                {
                    _Array[i - 1] = _Array[i];                    
                }

                Count--;
            }

            return found;
        }

        class MyIterable : IEnumerator<T>
        {
            Array<T> array;
            int index = -1;
            public MyIterable(Array<T> array)
            {
                this.array = array;
            }
            public T Current {
                get {

                    if (index < 0)
                        throw new IndexOutOfRangeException(nameof(T));
                    else
                    {
                        return array._Array[index];
                    }
                }           
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if(index < array.Count - 1)
                {
                    index++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyIterable(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
