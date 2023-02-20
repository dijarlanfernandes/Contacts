using ContactsManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Data
{
    public class ContactContext:DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options):base(options){}
                public DbSet<ContactModel> Contacts { get; set; }
                public DbSet<UserModel> Users { get; set; }
                public DbSet<RoleModel> roles { get; set; }
    }
}
