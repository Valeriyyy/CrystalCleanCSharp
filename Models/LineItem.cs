using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class LineItem
    {
        public int Id { get; set; }
        public int Item { get; set; }
        public Guid Job { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual Item ItemNavigation { get; set; } = null!;
        public virtual Job JobNavigation { get; set; } = null!;
    }
}
