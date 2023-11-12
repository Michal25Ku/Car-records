namespace Laboratorium3.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentTime() => DateTime.Now;
    }
}
