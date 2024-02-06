using System.Text;
using Microsoft.Extensions.Configuration;

namespace RestaurantSystem;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>();

        var configuration = builder.Build();


        var restaurant = new RestaurantProject(configuration);
        restaurant.Run();
    }
}