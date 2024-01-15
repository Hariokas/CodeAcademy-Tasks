namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class Playlist
{
    public List<Song> Songs { get; set; } = new();

    public void AddSong(Song song)
    {
        Songs.Add(song);
    }

    public void RemoveSong(Song song)
    {
        Songs.Remove(song);
    }

    public void PrintSongs()
    {
        foreach (var song in Songs)
            Console.WriteLine(song);
    }
}