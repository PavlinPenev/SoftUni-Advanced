using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListyIteratorTask
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int currentIndex;
        
        public ListyIterator(params  T[] list)
        {
            Create(list);
        }

        public List<T> Elements { get; set; }

        private void Create(params T[] list)
        {
            Elements = list.ToList();
            currentIndex = 0;
        }

        public bool Move()
        {
            if (Elements.Count > 0)
            {
                if (currentIndex == Elements.Count - 1)
                {
                    return false;
                }
                else
                {
                    currentIndex++;
                    return true;
                }
            }

            return false;
        }

        public void Print()
        {
            if (Elements.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }
            Console.WriteLine(Elements[currentIndex]);
        }

        public void PrintAll()
        {
            foreach (var element in Elements)
            {
                Console.Write(element + " ");   
            }

            Console.WriteLine();
        }

        public bool HasNext()
        {
            if (Elements.Count == 0)
            {
                return false;
            }

            return currentIndex + 1 < Elements.Count ? true : false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                yield return Elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
