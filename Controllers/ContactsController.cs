using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    public class ContactsController : Controller
    {
        public readonly IContactsService _contactsService;
        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _contactsService.GetAllContacts());
        }
    }
}
