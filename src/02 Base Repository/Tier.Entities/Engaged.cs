using System.ComponentModel.DataAnnotations;

namespace EntityPhoto
{
    public class Engaged
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        public virtual Address MakingOf { get; set; }
    }
}
