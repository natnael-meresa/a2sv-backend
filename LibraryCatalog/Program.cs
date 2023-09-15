class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library() {Name="NewLibrary", Address="Bole"};

        Book book1 = new Book("Programming with c#", "Natnael Meresa", "978-0-06-112008-4", 2021);
        Book book2 = new Book("Programming with go", "Natnael Meresa", "978-0-06-112008-4", 2023);

        MediaItem mediaItem1 = new MediaItem("Inception", "DVD", 148);
        MediaItem mediaItem2 = new MediaItem("Thriller", "CD", 42);

        library.AddBook(book1);
        library.AddBook(book2);


        library.AddMediaItem(mediaItem1);
        library.AddMediaItem(mediaItem2);

        library.PrintCatalog();

    }
}