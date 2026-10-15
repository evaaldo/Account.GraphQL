using System.Text.RegularExpressions;

namespace Account.GraphQL.Domain.Domain
{
    public class PersonEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime Birthdate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public PersonEntity(string name, string email, DateTime birthdate)
        {
            ValidateBirthDate(birthdate);
            ValidateEmail(email);

            Name = name;
            Email = email;
            Birthdate = birthdate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        private void ValidateBirthDate(DateTime birthdate)
        {
            if (birthdate > DateTime.UtcNow)
            {
                throw new ArgumentException("Birthdate cannot be in the future.");
            }

            if (birthdate > DateTime.Now - TimeSpan.FromDays(365 * 18))
            {
                throw new ArgumentException("Person must be at least 18 years old.");
            }
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                throw new ArgumentException("Invalid email address.");
            }
        }
    }
}
