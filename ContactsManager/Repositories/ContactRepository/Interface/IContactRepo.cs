using ContactsManager.Models;

namespace ContactsManager.Repositories.ContactRepository.Interface
{
    public interface IContactRepo
    {
        Task<IEnumerable<ContactModel>> GetAllContactsAsync(string userid);
        Task<ContactModel> GetContactByIdAsync(string id);
        Task<ContactModel> InsertContact(ContactModel contact);
        Task<ContactModel> UpdateContact(ContactModel contact);
        Task DeleteContactByIdAsync(string id);

    }
}
