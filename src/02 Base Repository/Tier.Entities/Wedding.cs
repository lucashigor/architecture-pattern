using System;
using System.ComponentModel.DataAnnotations;

namespace EntityPhoto
{
    public class Wedding
    {
        [Key]
        public int Id { get; set; }

        public virtual Couple Couple { get; set; }

        public virtual Address Cerimony { get; set; }
        public virtual Address Party { get; set; }

        public bool SamePlace { get; set; }

        public virtual PaymentPlan PaymentPlan { get; set; }

        public virtual DeliveryBox DeliveryBox {get; set;}

        public DateTime WeddingTime { get; set; }

        public virtual Package Package { get; set; }

        public virtual CommercialContract Contract { get; set; }

        [MaxLength(250)]
        public string ExtraInformation { get; set; }

    }
}
