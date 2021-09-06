using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly Stack<T> box;

        public Box()
        {
            box = new Stack<T>();
        }

        public int Count
        {
            get => box.Count;
        }

        public void Add(T item)
        {
            box.Push(item);
        }

        public T Remove()
            => box.Pop();

    }
}
