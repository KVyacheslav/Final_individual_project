using System.ComponentModel.DataAnnotations;

namespace WebSkillProfi.Model
{
    public class Request
    {
        [Key, Display(Name = "Номер заявки")]
        public int Id { get; set; }

        [Required, Display(Name = "Время заявки")]
        public DateTime Created { get; set; }

        [Required, Display(Name = "Имя")]
        public string Name{ get; set; }

        [Required, Display(Name = "Текст заявки")]
        public string Message { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required, Display(Name = "Контакты")]
        public string Contact { get; set; }
    }
}
