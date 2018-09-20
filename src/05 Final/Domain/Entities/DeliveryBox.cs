using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class DeliveryBox
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}