using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BookShop_BL.Model
{
    public class Cart : IEnumerable
    {
        public Client Client { get; set; }
        public Dictionary<Book, int> Books { get; set; }

        public decimal Price => GetAll().Sum(b => b.Price);

        public Cart(Client client)
        {
            Client = client;
            Books = new Dictionary<Book, int>();
        }

        public void Add(Book book)
        {
            if (Books.TryGetValue(book, out int count))
            {
                Books[book] = ++count;
            }
            else
            {
                Books.Add(book, 1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var book in Books.Keys)
            {
                for (int i = 0; i < Books[book]; i++)
                {
                    yield return book;
                }
            }
        }

        public List<Book> GetAll()
        {
            var result = new List<Book>();
            foreach (Book i in this)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
