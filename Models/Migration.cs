using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class Migration
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Batch { get; set; }
        public DateTime? MigrationTime { get; set; }
    }
}
