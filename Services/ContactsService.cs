using PhoneBook.Domain;
using PhoneBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsService( IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }
        public async Task<int> CreateContactsAsync(Contacts contacts)
        {
            return await _contactsRepository.CreateAsync(contacts);
        }

        public async Task<int> DeleteContactsAsync(Contacts contacts)
        {
            return await _contactsRepository.DeleteAsync(contacts);
        }

        public async Task<List<Contacts>> GetAllContacts()
        {
            return await _contactsRepository.GetAllAsync();
        }

        public async Task<Contacts> GetContactById(int id)
        {
            return await _contactsRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateContactsAsync(Contacts contacts)
        {
            return await _contactsRepository.UpdateAsync(contacts);
        }

    }
}
