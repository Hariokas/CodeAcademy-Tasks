namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class Library
{
    public List<Book> Books { get; set; } = new();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void PrintBooks()
    {
        foreach (var book in Books)
            Console.WriteLine(book);
    }

    public TimeSpan GetReadingTime(Book book)
    {
        return TimeSpan.FromHours((double)book.Pages / 50);
    }
}