namespace RestaurantSystem.Services.Interfaces;

internal interface IEmailRepository
{
    void SendEmail(string to, string subject, string body);
}