namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Book(string title, string author, DateTime year, string countryOfEdition = "")
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public DateTime Year { get; set; } = year;
    public string CountryOfEdition { get; set; } = countryOfEdition;

    public static List<Book> GetListOfBooksByAuthor(List<Book> listOfBooks, string author)
    {
        return listOfBooks.Where(book => book.Author == author).ToList();
    }
}