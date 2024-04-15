using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;

namespace GBook.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(string),
        ErrorMessageResourceName = "FieldIsRequired")]
        public string? Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(string),
        ErrorMessageResourceName = "FieldIsRequired")]
        public string? Password { get; set; }

        public string? Salt { get; set; }
        public Users()
        {
            this.Messages = new HashSet<Messages>();
        }
        public ICollection<Messages>? Messages { get; set; }

    }
}