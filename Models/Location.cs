using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class Location
    {
        public Location()
        {
            Jobs = new HashSet<Job>();
        }

        public Guid Id { get; set; }
        public string? Address { get; set; }
        public string? Unit { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? GateCode { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
