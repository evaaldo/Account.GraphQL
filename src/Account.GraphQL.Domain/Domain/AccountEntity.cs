namespace Account.GraphQL.Domain.Domain
{
    public class AccountEntity
    {
        public int IdPerson { get; private set; }
        public int IdStatus { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public AccountEntity(int idPerson, int idStatus)
        {
            ValidateIdValues(idPerson, idStatus);

            IdPerson = idPerson;
            IdStatus = idStatus;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        private void ValidateIdValues(int idPerson, int idStatus)
        {
            if (idPerson <= 0)
            {
                throw new ArgumentException("IdPerson must be a positive integer.");
            }

            if (idStatus <= 0)
            {
                throw new ArgumentException("IdStatus must be a positive integer.");
            }
        }
    }
}
