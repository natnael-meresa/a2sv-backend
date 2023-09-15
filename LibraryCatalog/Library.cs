public class Library
{

    public required string Name { get; set; }
    public required string Address { get; set; }

    private List<Book> books;
    private List<MediaItem> mediaItems;

    public Library() {
        books = new List<Book>();
        mediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book) {
        books.Add(book);
    }

    public void RemoveBook(Book book) {
        books.Remove(book);
    }

    public void AddMediaItem(MediaItem item) {
        mediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item) {
        mediaItems.Remove(item);
    }

     public void PrintCatalog()
    {
        Console.WriteLine($"Library: {Name}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine("Catalog:");

        Console.WriteLine("Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }

        Console.WriteLine("Media Items:");
        foreach (var item in mediaItems)
        {
            Console.WriteLine($"{item.Title} ({item.MediaType})");
        }
    }
}