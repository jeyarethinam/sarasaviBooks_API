namespace sarasavi_books.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Publication { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }


    }
}
