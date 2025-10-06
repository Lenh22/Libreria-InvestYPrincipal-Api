using System.ComponentModel.DataAnnotations;

namespace Libreria_InvestYPrincipal_Api.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]
        [StringLength(50, ErrorMessage = "La nacionalidad no puede exceder 50 caracteres")]
        public string Nationality { get; set; } = string.Empty;
    }

    public class AuthorCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]
        [StringLength(50, ErrorMessage = "La nacionalidad no puede exceder 50 caracteres")]
        public string Nationality { get; set; } = string.Empty;
    }

    public class AuthorUpdateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]
        [StringLength(50, ErrorMessage = "La nacionalidad no puede exceder 50 caracteres")]
        public string Nationality { get; set; } = string.Empty;
    }
}
