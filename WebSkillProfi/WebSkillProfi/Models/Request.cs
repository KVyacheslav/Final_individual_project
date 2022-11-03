using System.ComponentModel.DataAnnotations;

namespace WebSkillProfi.Models
{
    public class Request
    {
        [Key, Display(Name = "Номер заявки")]
        public int Id { get; set; }

        [Display(Name = "Время заявки")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required, Display(Name = "Имя")]
        public string Name { get; set; }

        [Required, Display(Name = "Текст заявки")]
        public string Message { get; set; }

        [Display(Name = "Статус заявки")]
        public string Status { get; set; } = "Получена";

        [EmailAddress]
        [Required, Display(Name = "Контакты")]
        public string Contact { get; set; }
    }
}
