using System.ComponentModel.DataAnnotations;

namespace WebSkillProfi.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
