using System;
using System.ComponentModel;

namespace Guestbook.Models
{
    public class GuestbookEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

        [DisplayName("Date Posted")]
        public DateTime DatePosted { get; set; }
    }
}