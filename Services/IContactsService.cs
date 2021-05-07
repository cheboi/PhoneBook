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
        public Task<Contacts> GetContactBYPhoneNumber(int PhoneNumber);
        public Task<int> CreateContactsAsync(Contacts contacts);
        public Task<int> UpdateContactsAsync(Contacts contacts);
        public Task<int> DeleteContactAsync(Contacts contacts);
    }
}
