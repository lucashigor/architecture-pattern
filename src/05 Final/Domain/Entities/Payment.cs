using System;

namespace Domain
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal? Value { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime? PaidDate { get; set; }

        public decimal? PaidValue { get; set; }

        public int PaymentPlan_Id { get; set; }

        public virtual PaymentPlan PaymentPlan { get; set; }
    }
}