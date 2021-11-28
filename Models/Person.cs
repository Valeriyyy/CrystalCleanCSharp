using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
