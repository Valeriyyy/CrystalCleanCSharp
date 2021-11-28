using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class Client
    {
        public Client()
        {
            Contacts = new HashSet<Contact>();
            Jobs = new HashSet<Job>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public string? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
