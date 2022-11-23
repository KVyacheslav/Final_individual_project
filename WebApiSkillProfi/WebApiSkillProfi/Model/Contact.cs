using System.ComponentModel.DataAnnotations;

namespace WebApiSkillProfi.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string ImageUrl { get; set; }


        public static Contact CreateNullContact()
        {
            return new Contact
            {
                Id = -1,
                Url = "Null",
                ImageUrl = "Null"
            };
        }
    }
}
