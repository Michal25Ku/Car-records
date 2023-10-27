namespace Laboratorium2.Models
{
    public class BirthCalculator
    {
        public string? FirstName { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;

        public bool IsValid()
        {
            return FirstName != null && BirthDate <= DateTime.Now;
        }

        public int Years()
        {
            TimeSpan TimeDiference = DateTime.Now - BirthDate;
            var years = (int)(TimeDiference.Days / 365.25);

            return years;
        }
    }
}
