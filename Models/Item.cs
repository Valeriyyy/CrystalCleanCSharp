using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class Item
    {
        public Item()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? DefaultPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
