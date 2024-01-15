namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class Movie
{
    private double _rating;

    public string Title { get; set; }
    public string Genre { get; set; }

    public double Rating
    {
        get => Math.Round(_rating, 2);
        set
        {
            if (value is >= 0 and <= 10)
                _rating = value;
        }
    }

    public bool IsWatchable => Rating > 5;
}