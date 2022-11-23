using System.ComponentModel.DataAnnotations;
using WebApiSkillProfi.Model;

namespace WebApiSkillProfi.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }


        public static Service CreateNullRequest()
        {
            return new Service
            {
                Id = -1,
                Title = "Null",
                Description = "Null"
            };
        }
    }
}
