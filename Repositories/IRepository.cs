using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByPhoneNumberAsync(int PhoneNumber);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
