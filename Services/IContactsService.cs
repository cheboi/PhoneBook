using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public interface IContactsService
    {
        public Task<List<Contacts>> GetAllContacts();
        public Task<Contacts> GetContactById(int Id);
        public Task<int> CreateContactsAsync(Contacts contacts);
        public Task<int> UpdateContactsAsync(Contacts contacts);
        public Task<int> DeleteContactsAsync(Contacts contacts);
    }
}
