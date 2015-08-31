using Guestbook.Models;
using System.Data.Entity;

namespace Guestbook.DAL
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext()
            : base("GuestbookContext")
        {
        }

        public DbSet<GuestbookEntry> GuestbookEntries { get; set; }
    }
}