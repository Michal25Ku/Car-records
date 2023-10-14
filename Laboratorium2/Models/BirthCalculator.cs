namespace Laboratorium2.Models
{
    public class BirthCalculator
    {
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }

        public bool IsValid()
        {
            return FirstName != null && BirthDate != null;
        }

        public int Birth()
        {
            var years = (DateTime.Now - BirthDate);

            return 1;
        }
    }
}
