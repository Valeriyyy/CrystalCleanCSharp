using System;
using System.Collections.Generic;

namespace crystalClean.Models
{
    public partial class Job
    {
        public Job()
        {
            LineItems = new HashSet<LineItem>();
        }

        public Guid Id { get; set; }
        public Guid Client { get; set; }
        public Guid Location { get; set; }
        public int OrderNumber { get; set; }
        public string? Status { get; set; }
        public decimal? EstimatedPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Tip { get; set; }
        public string? Notes { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Client ClientNavigation { get; set; } = null!;
        public virtual Location LocationNavigation { get; set; } = null!;
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
