using System.Collections.Generic;

namespace Domain
{
    public class PaymentPlan
    {
        public int Id { get; set; }

        public decimal? Value { get; set; }

        public decimal? PercentualDiscount { get; set; }

        public decimal? ValueDiscount { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public decimal? ExtraValue { get; set; }
    }
}