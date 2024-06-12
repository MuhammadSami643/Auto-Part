using System.ComponentModel.DataAnnotations;

namespace Auto_Parts.Models
{
    public class FormDto
    {
        public static string Name { get; set; }
        [Required]
        public Char Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Char Password { get; set; }
    }
}
