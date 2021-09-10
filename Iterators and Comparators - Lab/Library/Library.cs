using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public readonly SortedSet<Book> books;

        private class LibraryIterator : IEnumerator<Book>
        {
            private SortedSet<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new SortedSet<Book>(books, new BookComparator());
            }
            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public Book Current => books.ToList()[currentIndex];

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
