using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class ClientOnly
    {
        public ClientOnly()
        {
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public string? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
