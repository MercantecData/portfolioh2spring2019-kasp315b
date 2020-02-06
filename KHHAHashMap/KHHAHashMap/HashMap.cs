using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHHAHashMap
{
    public class HashMap<KeyType, DataType> : IEnumerable
    {
        public DataType this[KeyType key]
        {
            get => Get(key);
            set => Add(key, value);
        }

        private int indexUsage;
        private int elementCount;
        private int capacity;
        private LinkedPair<KeyType, DataType>[] buckets;
        private List<KeyType> keys;

        public HashMap(int capacity)
        {
            this.capacity = capacity;
            indexUsage = 0;
            elementCount = 0;

            buckets = new LinkedPair<KeyType, DataType>[capacity];
            keys = new List<KeyType>();
        }

        private uint CalculateIndex(KeyType key)
        {
            uint hash = (uint)key.GetHashCode();
            uint index = hash % (uint)capacity;
            return index;
        }

        public void Resize(int deltaCapacity)
        {
            indexUsage = 0;
            elementCount = 0;
            capacity += deltaCapacity;
            LinkedPair<KeyType, DataType>[] oldBuckets = buckets;
            buckets = new LinkedPair<KeyType, DataType>[capacity];

            for(int i = 0; i < oldBuckets.Length; i++)
            {
                for(LinkedPair<KeyType, DataType> pair = oldBuckets[i]; pair != null; pair = pair.GetNext())
                {
                    this[pair.GetKey()] = pair.GetData();
                }
            }
        }

        public float GetLoadFactor()
        {
            return indexUsage / (float)capacity;
        }

        public int Count()
        {
            return elementCount;
        }

        public ICollection<KeyType> GetKeys()
        {
            return keys.AsReadOnly();
        }

        public void Add(KeyType key, DataType data)
        {
            if(data == null)
            {
                Remove(key);
                return;
            }

            uint index = CalculateIndex(key);

            if(buckets[index] == null)
            {
                buckets[index] = new LinkedPair<KeyType, DataType>(key, data);
                indexUsage++;
                elementCount++;
                keys.Add(key);
            }
            else
            {
                LinkedPair<KeyType, DataType> pair = buckets[index].GetLastLinkedPairInLink();
                if(pair != null)
                {
                    pair.SetData(data);
                }
                else
                {
                    pair = new LinkedPair<KeyType, DataType>(buckets[index], key, data);
                    buckets[index].SetPrevious(pair);
                    buckets[index] = pair;
                    elementCount++;
                }
            }
        }

        public DataType Get(KeyType key)
        {
            uint index = CalculateIndex(key);

            if(buckets[index] == null)
            {
                return default;
            }
            else
            {
                LinkedPair<KeyType, DataType> match;

                match = buckets[index].GetLinkedPairWithKeyInListForwardSearch(key);
                if(match == null)
                {
                    return default;
                }
                else
                {
                    return match.GetData();
                }
            }
        }

        public bool Remove(KeyType key)
        {
            uint index = CalculateIndex(key);

            if(buckets[index] == null)
            {
                return false;
            }
            else
            {
                LinkedPair<KeyType, DataType> previous, next, match;

                match = buckets[index].GetLinkedPairWithKeyInListForwardSearch(key);
                if(match == null)
                {
                    return false;
                }
                else
                {
                    previous = match.GetPrevious();
                    next = match.GetNext();

                    if(previous == null && next == null)
                    {
                        buckets[index] = null;
                        keys.Remove(key);
                        elementCount--;
                        indexUsage--;
                        return true;
                    }
                    else if(previous == null)
                    {
                        buckets[index] = next;
                        match.SetNext(null);
                        next.SetPrevious(null);
                        elementCount--;
                        return true;
                    }
                    else if(next == null)
                    {
                        match.SetPrevious(null);
                        previous.SetNext(null);
                        elementCount--;
                        return true;
                    }
                    else
                    {
                        previous.SetNext(next);
                        next.SetPrevious(previous);
                        match.SetNext(null);
                        match.SetPrevious(null);
                        elementCount--;
                        return true;
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new HashMapEnumerator(this);
        }

        private class HashMapEnumerator : IEnumerator
        {
            private LinkedPair<KeyType, DataType>[] buckets;
            private int bucketIndex;
            private IEnumerator bucketEnumerator = null;

            public object Current { get => bucketEnumerator.Current; }

            public HashMapEnumerator(HashMap<KeyType, DataType> map)
            {
                buckets = map.buckets;
                bucketIndex = 0;
                FindNextPopulatedBucket();
            }

            private void FindNextPopulatedBucket()
            {
                while(++bucketIndex < buckets.Length)
                {
                    if (buckets[bucketIndex] != null)
                    {
                        bucketEnumerator = buckets[bucketIndex].GetEnumerator();
                        return;
                    }
                }

                bucketEnumerator = null;
            }

            public void Reset()
            {
                bucketIndex = 0;
                FindNextPopulatedBucket();
            }

            public bool MoveNext()
            {
                if (bucketEnumerator.MoveNext())
                {
                    return true;
                }
                else
                {
                    FindNextPopulatedBucket();
                    return bucketEnumerator != null;
                }
            }
        }
    }
}
