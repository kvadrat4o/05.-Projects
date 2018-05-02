using BashSoft.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.DataStructures
{
    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T: IComparable<T>
    {
        private const int DEFAULT_SIZE = 16;

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;

        public int Size => this.size;

        public int Capacity => this.innerCollection.Length;

        public T this[int index]
        {
            get
            {
                if (index >= this.Size)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.innerCollection[index];
            }
        }

        public SimpleSortedList(int capacity, IComparer<T> comparison)
        {
            this.comparison = comparison;
            InitializeInnerCollection(capacity);
        }
        
        public SimpleSortedList(int capacity):this(capacity, Comparer<T>.Create((x, y) => x.CompareTo(y)))
        {

        }

        public SimpleSortedList(IComparer<T> comparison)
            : this(DEFAULT_SIZE, comparison)
        {
        }

        public SimpleSortedList():this(DEFAULT_SIZE)
        {
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeCapacity);
            }
            this.innerCollection = new T[capacity];
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            if (this.innerCollection.Length == this.size)
            {
                this.Resize();
            }
            this.innerCollection[size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            if (this.size + collection.Count >= this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var element in collection)
            {
                this.innerCollection[this.size] = element;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;

            while (this.size + collection.Count >= newSize)
            {
                newSize *= 2;
            }
            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.size);
            this.innerCollection = newCollection;
        }

        public string JoinWith(string joiner)
        {
            var sb = new StringBuilder();
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var element in this)
            {
                sb.Append(element)
                    .Append(joiner);
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString().TrimEnd(',');
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerCollection.GetEnumerator();
        }

        private void Resize()
        {
            T[] newCollection = new T[this.size * 2];
            Array.Copy(this.innerCollection, newCollection, this.size);
            this.innerCollection = newCollection;
        }

        public bool Remove(T element)
        {
            bool hasBeenRemoved = false;

            int indexOfRemovedElement = 0;

            if (element != null)
            {
                for (int i = 0; i < this.size; i++)
                {
                    if (this.innerCollection[i].Equals(element))
                    {
                        indexOfRemovedElement = i;
                        this.innerCollection[i] = default(T);
                        hasBeenRemoved = true;
                        break;
                    }
                }

                if (hasBeenRemoved)
                {
                    for (int i = indexOfRemovedElement; i < this.size; i++)
                    {
                        this.innerCollection[i] = this.innerCollection[i + 1];
                    }
                    this.size--;
                }
                this.innerCollection[this.size] = default(T);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return hasBeenRemoved;
        }
    }
}
