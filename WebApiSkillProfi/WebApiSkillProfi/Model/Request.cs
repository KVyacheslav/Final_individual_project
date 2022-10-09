using System.ComponentModel.DataAnnotations;
using WebApiSkillProfi.Interfaces;

namespace WebApiSkillProfi.Model
{
    public class Request : IRequest
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


        public static Request CreateNullRequest()
        {
            return new Request
            {
                Id = -1,
                Created = new DateTime(0),
                Name = "Null",
                Message = "Заявка не найдена",
                Contact = "Null"
            };
        }
    }
}
