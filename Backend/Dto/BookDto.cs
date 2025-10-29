using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_InvestYPrincipal_Api.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        
        [Range(1, 1000, ErrorMessage = "El número de páginas debe estar entre 1 y 1000")]

        public int Pages { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }

        [Range(1, 99999, ErrorMessage = "El precio debe estar entre 1 y 99999")]
        [Column(TypeName = "decimal(10,2)")]

        public decimal Price { get; set; }
        public string Language { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } // Para los GET
    }
    public class CreateBookDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Range(1, 1000, ErrorMessage = "El número de páginas debe estar entre 1 y 1000")]

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "La editorial es obligatoria")]
        public string Publisher { get; set; } = string.Empty;

        [Required(ErrorMessage = "El ISBN es obligatorio")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, 99999, ErrorMessage = "El precio debe estar entre 1 y 99999")]
        [Column(TypeName = "decimal(10,2)")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "El idioma es obligatorio")]
        public string Language { get; set; } = string.Empty;

        [Required(ErrorMessage = "El autor es obligatorio")]
        public int AuthorId { get; set; }
    }
    public class UpdateBookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Range(1, 1000, ErrorMessage = "El número de páginas debe estar entre 1 y 1000")]

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "La editorial es obligatoria")]
        public string Publisher { get; set; } = string.Empty;

        [Required(ErrorMessage = "El ISBN es obligatorio")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, 99999, ErrorMessage = "El precio debe estar entre 1 y 99999")]
        [Column(TypeName = "decimal(10,2)")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "El idioma es obligatorio")]
        public string Language { get; set; } = string.Empty;

        [Required(ErrorMessage = "El autor es obligatorio")]
        public int AuthorId { get; set; }        
    }
}
