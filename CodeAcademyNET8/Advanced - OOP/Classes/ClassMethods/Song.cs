namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public int Length { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}, Artist: {Artist}, Album: {Album}, Length: {Length}";
    }
}