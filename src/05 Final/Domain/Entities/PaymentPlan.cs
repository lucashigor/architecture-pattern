using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PaymentPlan
    {
        [Key]
        public int Id { get; set; }

        public decimal? Value { get; set; }

        public decimal? PercentualDiscount { get; set; }

        public decimal? ValueDiscount { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public decimal? ExtraValue { get; set; }
    }
}