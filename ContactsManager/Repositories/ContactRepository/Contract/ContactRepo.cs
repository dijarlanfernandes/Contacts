using ContactsManager.Data;
using ContactsManager.Models;
using ContactsManager.Repositories.ContactRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Repositories.ContactRepository.Contract
{
    public class ContactRepo : IContactRepo
    {
        private readonly ContactContext _context;

        public ContactRepo(ContactContext context)
        {
            _context = context;
        }

        public async Task DeleteContactByIdAsync(string id)
        {
            var deleteContact = await GetContactByIdAsync(id);
            _context.Contacts.Remove(deleteContact);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactModel>> GetAllContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<ContactModel> GetContactByIdAsync(string id)
        {
            if (id == null) new Exception("Id not found");
            var contactid = await _context.Contacts.FirstOrDefaultAsync(x => x.Id ==id);           
            return contactid;            
        }

        public async Task<ContactModel> InsertContact(ContactModel contact)
        {
            if (contact == null) new Exception("contact not found");
            var contacts = await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contacts.Entity;
        }

        public async Task<ContactModel> UpdateContact(ContactModel contact)
        {

            if(GetContactByIdAsync(contact.Id) == null) new Exception("not found");
            var updateContact =  _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

            return updateContact.Entity;
        }
    }
}
