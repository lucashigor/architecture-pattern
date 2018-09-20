using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Couple
    {
        [Key]
        public int Id { get; set; }

        public virtual Engaged Engaged1 { get; set; }
        public virtual Engaged Engaged2 { get; set; }
}
}
