using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHHAHashMap
{
    /// <summary>
    /// Key-Data pair with <see cref="LinkedList{T}"/>-like capabilities
    /// </summary>
    /// <typeparam name="KeyType"></typeparam>
    /// <typeparam name="DataType"></typeparam>
    public class LinkedPair<KeyType, DataType> : IComparable, IEnumerable
    {
        private LinkedPair<KeyType, DataType> previous = null;
        private LinkedPair<KeyType, DataType> next = null;
        private KeyType key = default;
        private DataType data = default;
        /// <summary>
        /// Whether or not the <see cref="DataType"/> can be compared through the <see cref="IComparable"/> interface
        /// </summary>
        private bool isDataComparable = false;

        public LinkedPair()
        {
            DetermineDataComparable();
        }

        public LinkedPair(KeyType key, DataType data) : this()
        {
            this.key = key;
            this.data = data;
        }

        public LinkedPair(KeyType key, DataType data, LinkedPair<KeyType, DataType> next) : this()
        {
            this.key = key;
            this.data = data;
            this.next = next;
        }

        public LinkedPair(LinkedPair<KeyType, DataType> previous, KeyType key, DataType data) : this()
        {
            this.key = key;
            this.data = data;
            this.previous = previous;
        }

        public LinkedPair(KeyType key, DataType data, LinkedPair<KeyType, DataType> previous, LinkedPair<KeyType, DataType> next) : this()
        {
            this.key = key;
            this.data = data;
            this.previous = previous;
            this.next = next;
        }

        /// <summary>
        /// Get key of the <see cref="LinkedPair{KeyType, DataType}"/>
        /// </summary>
        /// <returns></returns>
        public KeyType GetKey()
        {
            return key;
        }

        /// <summary>
        /// Replace key and return the old one
        /// </summary>
        /// <param name="newKey">Replacement key</param>
        /// <returns>Old key</returns>
        public KeyType ReplaceKey(KeyType newKey)
        {
            KeyType oldKey = key;
            key = newKey;
            return oldKey;
        }

        /// <summary>
        /// Replace the key
        /// </summary>
        /// <param name="newKey">New key</param>
        public void SetKey(KeyType newKey)
        {
            key = newKey;
        }

        /// <summary>
        /// Get the data of the <see cref="LinkedPair{KeyType, DataType}"/>
        /// </summary>
        /// <returns></returns>
        public DataType GetData()
        {
            return data;
        }

        /// <summary>
        /// Replace then return the old data
        /// </summary>
        /// <param name="newData">Replacement data</param>
        /// <returns>Old data</returns>
        public DataType ReplaceData(DataType newData)
        {
            DataType oldData = data;
            data = newData;
            return oldData;
        }

        /// <summary>
        /// Replace the data
        /// </summary>
        /// <param name="newData">New Data</param>
        public void SetData(DataType newData)
        {
            data = newData;
        }

        /// <summary>
        /// Get next linked <see cref="LinkedPair{KeyType, DataType}"/>. Can be null
        /// </summary>
        /// <returns></returns>
        public LinkedPair<KeyType, DataType> GetNext()
        {
            return next;
        }

        /// <summary>
        /// Replace next link
        /// </summary>
        /// <param name="newNext">New next pair</param>
        /// <returns>Old next pair</returns>
        public LinkedPair<KeyType, DataType> ReplaceNext(LinkedPair<KeyType, DataType> newNext)
        {
            LinkedPair<KeyType, DataType> oldNext = next;
            next = newNext;
            return oldNext;
        }

        /// <summary>
        /// Replace next link
        /// </summary>
        /// <param name="newNext">New next pair</param>
        public void SetNext(LinkedPair<KeyType, DataType> newNext)
        {
            next = newNext;
        }

        /// <summary>
        /// Get the previous linked <see cref="LinkedPair{KeyType, DataType}"/>. Can be null
        /// </summary>
        /// <returns></returns>
        public LinkedPair<KeyType, DataType> GetPrevious()
        {
            return previous;
        }

        /// <summary>
        /// Replace previous link
        /// </summary>
        /// <param name="newPrevious">New previous pair</param>
        /// <returns>Old previous pair</returns>
        public LinkedPair<KeyType, DataType> ReplacePrevious(LinkedPair<KeyType, DataType> newPrevious)
        {
            LinkedPair<KeyType, DataType> oldPrevious = previous;
            previous = newPrevious;
            return oldPrevious;
        }

        /// <summary>
        /// Replace previous link
        /// </summary>
        /// <param name="newPrevious">New previous pair</param>
        public void SetPrevious(LinkedPair<KeyType, DataType> newPrevious)
        {
            previous = newPrevious;
        }

        /// <summary>
        /// Gets the last pair in the linked list
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the first pair in the linked list
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Searches for a <see cref="LinkedPair{KeyType, DataType}"/> with a specified key that is linked with this one
        /// </summary>
        /// <param name="key">Search key</param>
        /// <returns>Matched pair. Can be null</returns>
        public LinkedPair<KeyType, DataType> GetLinkedPairWithKeyInList(KeyType key)
        {
            LinkedPair<KeyType, DataType> pair = GetLinkedPairWithKeyInListForwardSearch(key);
            if (pair == null) pair = GetLinkedPairWithKeyInListBackwardSearch(key);
            return pair;
        }

        /// <summary>
        /// Searches for a <see cref="LinkedPair{KeyType, DataType}"/> with a specified key that is linked with this one, only searching forwards in the list
        /// </summary>
        /// <param name="key">Search key</param>
        /// <returns>Mathed pair. Can be null</returns>
        public LinkedPair<KeyType, DataType> GetLinkedPairWithKeyInListForwardSearch(KeyType key)
        {
            if (this.key.Equals(key)) return this;

            for(LinkedPair<KeyType, DataType> next = this.GetNext(); next != null; next = next.GetNext())
            {
                if (next.key.Equals(key)) return next;
            }

            return null;
        }

        /// <summary>
        /// Search for a <see cref="LinkedPair{KeyType, DataType}"/> with a specified key that is linked with this one, only searching backwards in the list
        /// </summary>
        /// <param name="key">Search key</param>
        /// <returns>Matched pair. Can be null</returns>
        public LinkedPair<KeyType, DataType> GetLinkedPairWithKeyInListBackwardSearch(KeyType key)
        {
            if (this.key.Equals(key)) return this;

            for(LinkedPair<KeyType, DataType> previous = this.GetPrevious(); previous != null; previous = previous.GetPrevious())
            {
                if (previous.key.Equals(key)) return previous;
            }

            return null;
        }

        /// <summary>
        /// Determines whether or not the <see cref="DataType"/> is using the <see cref="IComparable"/> interface.
        /// </summary>
        private void DetermineDataComparable()
        {
            isDataComparable = typeof(IComparable).IsAssignableFrom(typeof(DataType));
        }

        /// <summary>
        /// Part of the <see cref="IComparable"/> interface. Fails if the <see cref="DataType"/> doesn't implement it.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(object o)
        {
            if (!isDataComparable) throw new NotSupportedException("Given data type is not comparable");
            return CompareTo((LinkedPair<KeyType, DataType>)o);
        }

        /// <summary>
        /// Wrapper for <see cref="CompareTo(object)"/>. Same fail condition
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public int CompareTo(LinkedPair<KeyType, DataType> pair)
        {
            if (!isDataComparable) throw new NotSupportedException("Given data type is not comparable");
            return ((IComparable)GetData()).CompareTo(pair);
        }

        /// <summary>
        /// Get an enumerator for the list. Part of the <see cref="IEnumerable"/> interface.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return new LinkedPairEnumerator(this);
        }

        /// <summary>
        /// Enumerator class for the list.
        /// 
        /// This class's sole purpose is to iterate through the <see cref="LinkedPair{KeyType, DataType}"/> list. It is self-contained and does not write anything to the <see cref="LinkedPair{KeyType, DataType}"/>.
        /// </summary>
        private class LinkedPairEnumerator : IEnumerator
        {
            /// <summary>
            /// First pair in list
            /// </summary>
            public LinkedPair<KeyType, DataType> firstPairInList;
            /// <summary>
            /// Current pair in iteration of the list
            /// </summary>
            public LinkedPair<KeyType, DataType> currentPairInList;

            public object Current { get => currentPairInList; }

            public LinkedPairEnumerator(LinkedPair<KeyType, DataType> pair)
            {
                firstPairInList = pair.GetFirstLinkedPairInList();
                currentPairInList = firstPairInList;
            }

            /// <summary>
            /// Gets next pair in list. Part of <see cref="IEnumerator"/> interface
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                return currentPairInList.GetNext() != null;
            }

            /// <summary>
            /// Part of <see cref="IEnumerator"/> interface
            /// </summary>
            public void Reset()
            {
                currentPairInList = firstPairInList;
            }
        }

    }
}
