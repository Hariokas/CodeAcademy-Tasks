namespace CodeAcademyNET8.Advanced___OOP.Classes.Asynchronous;

internal class AsyncAwait
{
    private int _progress;

    public Task StartProgress()
    {
        _progress = 0;

        var progressTaskList = new List<Task>
        {
            PrintProgress(),
            IncrementProgress()
        };

        return Task.WhenAll(progressTaskList);
    }

    private async Task PrintProgress()
    {
        while (_progress < 100)
        {
            Console.WriteLine($"Progress: {_progress}");
            await Task.Delay(3000);
        }

        Console.WriteLine("Done!");
    }

    private async Task IncrementProgress()
    {
        while (_progress < 100)
        {
            _progress += 10;
            await Task.Delay(1000);
        }
    }

}