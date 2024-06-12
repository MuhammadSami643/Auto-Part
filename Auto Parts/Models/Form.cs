using System.ComponentModel.DataAnnotations;

namespace Auto_Parts.Models
{
    public class Form
    {
        [Key]
        [MaxLength(20)]
        public String Name { get; set; }
        [MaxLength(30)]
        public Char Email { get; set; }
        [MaxLength(3)]
        public int Age { get; set; }

        [MaxLength(13)]
        public Char Password { get; set; }

    }
}
