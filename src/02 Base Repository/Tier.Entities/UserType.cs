using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhoto
{
    public enum Types{
        test1 = 1,
        test2 = 2,
        test3 = 3,
        test4 = 4
    }
    public class UserType
    {

        [InverseProperty("Type")]
        public ICollection<User> Users { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Required"), Display(Name = "Test Enum")]
        public Types Type { get; set; }
    }
}
