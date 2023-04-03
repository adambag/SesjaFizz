using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzz
    {

        [Display(Name = "Rok urodzenia")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [Range(1899, 2022, ErrorMessage = "Wartość {0} musi znajdować się w przedziale od {1} do {2}")]
        public int Year { get; set; }

        [Display(Name = "Imię użytkownika")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [StringLength(100, ErrorMessage = "{0} może zawierać maksymalnie {1} znaków.")]
        public string UserName { get; set; }


    }
}
