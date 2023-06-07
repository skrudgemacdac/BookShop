namespace BookShop_BL.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Author} - {Price}";
        }

        public override int GetHashCode()
        {
            return BookId;
        }

        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                return BookId.Equals(book.BookId);
            }

            return false;
        }
    }
}
