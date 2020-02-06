using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHHAHashMap
{
    public class LinkedPair<KeyType, DataType> : IComparable, IEnumerable
    {
        private LinkedPair<KeyType, DataType> previous = null;
        private LinkedPair<KeyType, DataType> next = null;
        private KeyType key = default;
        private DataType data = default;
        private bool isDataComparable = false;

        public LinkedPair()
        {
            DetermineDataComparable();
        }

        public LinkedPair(KeyType key, DataType data)
        {
            this.key = key;
            this.data = data;
            DetermineDataComparable();
        }

        public LinkedPair(KeyType key, DataType data, LinkedPair<KeyType, DataType> next)
        {
            this.key = key;
            this.data = data;
            this.next = next;
            DetermineDataComparable();
        }

        public LinkedPair(LinkedPair<KeyType, DataType> previous, KeyType key, DataType data)
        {
            this.key = key;
            this.data = data;
            this.previous = previous;
            DetermineDataComparable();
        }

        public LinkedPair(KeyType key, DataType data, LinkedPair<KeyType, DataType> previous, LinkedPair<KeyType, DataType> next)
        {
            this.key = key;
            this.data = data;
            this.previous = previous;
            this.next = next;
            DetermineDataComparable();
        }

        public KeyType GetKey()
        {
            return key;
        }

        public KeyType ReplaceKey(KeyType newKey)
        {
            KeyType oldKey = key;
            key = newKey;
            return oldKey;
        }

        public void SetKey(KeyType newKey)
        {
            key = newKey;
        }

        public DataType GetData()
        {
            return data;
        }

        public DataType ReplaceData(DataType newData)
        {
            DataType oldData = data;
            data = newData;
            return oldData;
        }

        public void SetData(DataType newData)
        {
            data = newData;
        }

        public LinkedPair<KeyType, DataType> GetNext()
        {
            return next;
        }

        public LinkedPair<KeyType, DataType> ReplaceNext(LinkedPair<KeyType, DataType> newNext)
        {
            LinkedPair<KeyType, DataType> oldNext = next;
            next = newNext;
            return oldNext;
        }

        public void SetNext(LinkedPair<KeyType, DataType> newNext)
        {
            next = newNext;
        }

        public LinkedPair<KeyType, DataType> GetPrevious()
        {
            return previous;
        }

        public LinkedPair<KeyType, DataType> ReplacePrevious(LinkedPair<KeyType, DataType> newPrevious)
        {
            LinkedPair<KeyType, DataType> oldPrevious = previous;
            previous = newPrevious;
            return oldPrevious;
        }

        public void SetPrevious(LinkedPair<KeyType, DataType> newPrevious)
        {
            previous = newPrevious;
        }

        public LinkedPair<KeyType, DataType> GetLastLinkedPairInLink()
        {
            LinkedPair<KeyType, DataType> current = this;

            while(true)
            {
                LinkedPair<KeyType, DataType> next = current.GetNext();
                if(next == null)
                {
                    break;
                }
                else
                {
                    current = next;
                }
            }

            return current;
        }

        public LinkedPair<KeyType, DataType> GetFirstLinkedPairInList()
        {
            LinkedPair<KeyType, DataType> current = this;

            while(true)
            {
                LinkedPair<KeyType, DataType> previous = current.GetPrevious();
                if(previous == null)
                {
                    break;
                }
                else
                {
                    current = previous;
                }
            }

            return current;
        }

        public LinkedPair<KeyType, DataType> GetLinkedPairWithKeyInList(KeyType key)
        {
            LinkedPair<KeyType, DataType> pair = GetLinkedPairWithKeyInListForwardSearch(key);
            if (pair == null) pair = GetLinkedPairWithKeyInListBackwardSearch(key);
            return pair;
        }

        public LinkedPair<KeyType, DataType> GetLinkedPairWithKeyInListForwardSearch(KeyType key)
        {
            if (this.key.Equals(key)) return this;

            for(LinkedPair<KeyType, DataType> next = this.GetNext(); next != null; next = next.GetNext())
            {
                if (next.key.Equals(key)) return next;
            }

            return null;
        }

        public LinkedPair<KeyType, DataType> GetLinkedPairWithKeyInListBackwardSearch(KeyType key)
        {
            if (this.key.Equals(key)) return this;

            for(LinkedPair<KeyType, DataType> previous = this.GetPrevious(); previous != null; previous = previous.GetPrevious())
            {
                if (previous.key.Equals(key)) return previous;
            }

            return null;
        }

        private void DetermineDataComparable()
        {
            
        }

        public int CompareTo(object o)
        {
            return CompareTo((LinkedPair<KeyType, DataType>)o);
        }

        public int CompareTo(LinkedPair<KeyType, DataType> pair)
        {
            if (!isDataComparable) throw new NotSupportedException("Given data type is not comparable");
            return ((IComparable)GetData()).CompareTo(pair);
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkedPairEnumerator(this);
        }

        private class LinkedPairEnumerator : IEnumerator
        {
            public LinkedPair<KeyType, DataType> firstPairInList;
            public LinkedPair<KeyType, DataType> currentPairInList;

            public object Current { get => currentPairInList; }

            public LinkedPairEnumerator(LinkedPair<KeyType, DataType> pair)
            {
                firstPairInList = pair.GetFirstLinkedPairInList();
                currentPairInList = firstPairInList;
            }

            public bool MoveNext()
            {
                return currentPairInList.GetNext() != null;
            }

            public void Reset()
            {
                currentPairInList = firstPairInList;
            }
        }

    }
}
