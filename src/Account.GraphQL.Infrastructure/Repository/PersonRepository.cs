using Account.GraphQL.Application.Repository;
using Account.GraphQL.Domain.Domain;
using Npgsql;

namespace Account.GraphQL.Infrastructure.Repository
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public PersonRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public Task<IEnumerable<PersonEntity>> ListPersonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonEntity?> GetPersonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreatePersonAsync(PersonEntity person)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonByIdAsync(int id, PersonEntity person)
        {
            throw new NotImplementedException();
        }

        public Task DeletePersonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
