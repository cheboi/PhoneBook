using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain;
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
        public async Task<IActionResult> Details(int id)
        {
            return View(await _contactsService.GetContactById(id));
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(Contacts contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactsService.CreateContactsAsync(contacts);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(contacts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Contacts contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbContacts = await _contactsService.GetContactById(id);
                    if (await TryUpdateModelAsync<Contacts>(dbContacts))
                    {
                        await _contactsService.UpdateContactsAsync(dbContacts);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");   
            }
            return View(contacts);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbContacts = await _contactsService.GetContactById(id);
                if (dbContacts != null)
                {
                    await _contactsService.DeleteContactsAsync(dbContacts);
                }

            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to delete.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
    
}
