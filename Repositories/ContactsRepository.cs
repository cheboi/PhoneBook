using Dapper;
using Microsoft.Extensions.Configuration;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Repositories
{
    public class ContactsRepository : BaseRepository, IContactsRepository
    {
        public ContactsRepository(IConfiguration configuration)
            :base(configuration)
        { }
        public  async Task<int> CreateAsync(Contacts entity)
        {
            try
            {
                var query = "INSERT INTO Contacts (Name, PhoneNumber,) VALUES (@Name, @PhoneNumber,)";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("PhoneNumber", entity.PhoneNumber, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Contacts entity)
        {
            {
                try
                {
                    var query = "DELETE FROM Contacts WHERE Id = @Id";

                    var parameters = new DynamicParameters();
                    parameters.Add("Id", entity.Id, DbType.Int32);

                    using (var connection = CreateConnection())
                    {
                        return (await connection.ExecuteAsync(query, parameters));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public async Task<List<Contacts>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM Contacts";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Contacts>(query)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Contacts> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Contacts WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Contacts>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Contacts entity)
        {
            try
            {
                var query = "UPDATE Contacts set Name = @Name, PhoneNumber = @PhoneNumber";
                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("PhoneNumber", entity.PhoneNumber, DbType.String);
                parameters.Add("Id", entity.Id, DbType.Int32);
                using (var connection = CreateConnection())
                {
                    return await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {

                throw new Exception( ex.Message, ex);
            }
        }
    }
}
