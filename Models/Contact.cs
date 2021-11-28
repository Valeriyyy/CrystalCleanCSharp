using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class Contact
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public Guid? Client { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Client? ClientNavigation { get; set; }
    }
}
