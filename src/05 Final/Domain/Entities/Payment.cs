using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public decimal? Value { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime? PaidDate { get; set; }

        public decimal? PaidValue { get; set; }

        [ForeignKey("PaymentPlan")]
        public int PaymentPlan_Id { get; set; }

        [JsonIgnore]
        public virtual PaymentPlan PaymentPlan { get; set; }
    }
}