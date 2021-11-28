using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class MigrationsLock
    {
        public int Index { get; set; }
        public int? IsLocked { get; set; }
    }
}
