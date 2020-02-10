using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHHAHashMap
{
    /// <summary>
    /// This is a custom implementation of the collection type HashTable.
    /// A HashTable stores data in pairs that are retrievable at will with relatively fast access times.
    /// 
    /// At best O(1), at worst O(N).
    /// </summary>
    /// <typeparam name="KeyType"></typeparam>
    /// <typeparam name="DataType"></typeparam>
    public class HashMap<KeyType, DataType> : IEnumerable
    {
        /// <summary>
        /// Indexer that can be used just like in any other native collection, as long as the types match
        /// </summary>
        /// <param name="key">Key used to select a bucket to retrieve data from. Type must match with <see cref="KeyType"/> supplied during creation</param>
        /// <returns>Whatever is in the matching bucket to the key supplied. Can be null</returns>
        public DataType this[KeyType key]
        {
            get => Get(key);
            set => Add(key, value);
        }

        /// <summary>
        /// Amount of buckets used. As some hashes may collide, there may be more elements in the collection than indexes used. While the collection is still able retrieve the data, there will be a performance slow down proportional to the difference in indexes used and element count.
        /// </summary>
        private int indexUsage;
        /// <summary>
        /// The amount of elements in the collection.
        /// </summary>
        private int elementCount;
        /// <summary>
        /// The amount of buckets used to store elements
        /// </summary>
        private int capacity;
        /// <summary>
        /// Array of buckets used to store elements. While capacity may seem like a hard-cap, it is not. Whenever there is a hash-collision, the collection uses a variation of a linked list to differentiate and store the said element.
        /// </summary>
        private LinkedPair<KeyType, DataType>[] buckets;
        /// <summary>
        /// List of all keys in the collection. Novelty method also implemented in most other collections
        /// </summary>
        private List<KeyType> keys;

        /// <summary>
        /// Creates a <see cref="HashMap{KeyType, DataType}"/> of the supplied types and with a set capacity.
        /// </summary>
        /// <param name="capacity">non-negative number specifying the bucket count of the collection.</param>
        public HashMap(int capacity)
        {
            this.capacity = capacity;
            indexUsage = 0;
            elementCount = 0;

            buckets = new LinkedPair<KeyType, DataType>[capacity];
            keys = new List<KeyType>();
        }

        /// <summary>
        /// Calculates the bucket index of a key
        /// </summary>
        /// <param name="key">Key to calculate bucket index of</param>
        /// <returns>Bucket index</returns>
        private uint CalculateIndex(KeyType key)
        {
            uint hash = (uint)key.GetHashCode();
            uint index = hash % (uint)capacity;
            return index;
        }

        /// <summary>
        /// Resizes the <see cref="buckets"/> by a specified amount
        /// </summary>
        /// <param name="deltaCapacity">Amount to change the bucket array of. Can be negative if shrinking the bucket array is desired.</param>
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
                    pair.SetPrevious(null); // Not sure if necessary, or if the garbage collector knows that it is to be freed.
                    pair.SetNext(null); //     ^
                }
            }
        }

        /// <summary>
        /// Load factor is the amount of indexes used divided by the amount of indexes available (buckets)
        /// </summary>
        /// <returns>Usage percentage of indexes</returns>
        public float GetLoadFactor()
        {
            return indexUsage / (float)capacity;
        }

        /// <summary>
        /// Returns the amount of elements in the collection
        /// </summary>
        /// <returns>Element count</returns>
        public int Count()
        {
            return elementCount;
        }

        /// <summary>
        /// Returns keys of all elements in collection
        /// </summary>
        /// <returns>Readonly collection of keys</returns>
        public ICollection<KeyType> GetKeys()
        {
            return keys.AsReadOnly();
        }

        /// <summary>
        /// Adds a new element to the collection with a specified key
        /// </summary>
        /// <param name="key">Key of new element</param>
        /// <param name="data">Element to add</param>
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
                LinkedPair<KeyType, DataType> pair = buckets[index].GetLinkedPairWithKeyInList(key);
                if(pair != null)
                {
                    pair.SetData(data);
                }
                else
                {
                    pair = new LinkedPair<KeyType, DataType>(key, data, buckets[index]); // Automatically sets next as the previous element in bucket
                    buckets[index].SetPrevious(pair);
                    buckets[index] = pair;
                    elementCount++;
                }
            }
        }

        /// <summary>
        /// Gets element with a specified key. Returns null if no matched element is found
        /// </summary>
        /// <param name="key">Key of requested element</param>
        /// <returns>Matched element if it exists, otherwise null</returns>
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

        /// <summary>
        /// Remove key and matching data from collection
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

                    if(previous == null && next == null) // Matched pair is the only pair in the bucket
                    {
                        buckets[index] = null;
                        keys.Remove(key);
                        elementCount--;
                        indexUsage--;
                        return true;
                    }
                    else if(previous == null) // Matched pair is at the beginning of the bucket list
                    {
                        buckets[index] = next;
                        match.SetNext(null);
                        next.SetPrevious(null);
                        elementCount--;
                        return true;
                    }
                    else if(next == null) // Matched pair is at the end of the bucket list
                    {
                        match.SetPrevious(null);
                        previous.SetNext(null);
                        elementCount--;
                        return true;
                    }
                    else // Matched pair is in the middle of the bucket list
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

        /// <summary>
        /// Get enumerator of the collection. Part of the <see cref="IEnumerable"/> interface
        /// </summary>
        /// <returns>Enumerator of collection</returns>
        public IEnumerator GetEnumerator()
        {
            return new HashMapEnumerator(this);
        }

        /// <summary>
        /// Enumerator class for the collection.
        /// 
        /// This class's sole purpose is to iterate through the <see cref="HashMap{KeyType, DataType}"/> collection. It is self-contained and does not write anything to the <see cref="HashMap{KeyType, DataType}"/>.
        /// </summary>
        private class HashMapEnumerator : IEnumerator
        {
            /// <summary>
            /// All buckets in supplied <see cref="HashMap{KeyType, DataType}"/>
            /// </summary>
            private LinkedPair<KeyType, DataType>[] buckets;
            /// <summary>
            /// Index of the current bucket
            /// </summary>
            private int bucketIndex;
            /// <summary>
            /// Enumerator of the current bucket (See <see cref="LinkedPair{KeyType, DataType}.LinkedPairEnumerator"/>)
            /// </summary>
            private IEnumerator bucketEnumerator = null;

            public object Current { get => bucketEnumerator.Current; }

            public HashMapEnumerator(HashMap<KeyType, DataType> map)
            {
                buckets = map.buckets;
                bucketIndex = 0;
                FindNextPopulatedBucket();
            }

            /// <summary>
            /// Finds the next bucket that contains elements after <see cref="bucketIndex"/>
            /// </summary>
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

            /// <summary>
            /// Part of the <see cref="IEnumerator"/> interface
            /// </summary>
            public void Reset()
            {
                bucketIndex = 0;
                FindNextPopulatedBucket();
            }

            /// <summary>
            /// Part of the <see cref="IEnumerator"/> interface
            /// </summary>
            /// <returns>Next element in collection</returns>
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
