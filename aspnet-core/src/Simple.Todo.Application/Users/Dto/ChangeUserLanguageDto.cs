using System.ComponentModel.DataAnnotations;

namespace Simple.Todo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}