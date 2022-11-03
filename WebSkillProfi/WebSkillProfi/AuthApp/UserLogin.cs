using System.ComponentModel.DataAnnotations;

namespace WebSkillProfi.AuthApp
{
    public class UserLogin
    {
        [Required, MaxLength(20)]
        public string UserName{ get; set; }

        [Required, DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}
