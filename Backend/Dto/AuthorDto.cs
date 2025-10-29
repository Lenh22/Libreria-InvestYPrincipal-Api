using System.ComponentModel.DataAnnotations;

namespace Libreria_InvestYPrincipal_Api.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]

        public string Nationality { get; set; } = string.Empty;
    }
}
