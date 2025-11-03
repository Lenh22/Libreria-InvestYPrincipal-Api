using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApiClassic.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        [StringLength(50, ErrorMessage = "El género no puede exceder 50 caracteres")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        [Range(1, 1000, ErrorMessage = "El número de páginas debe estar entre 1 y 1000")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "La editorial es obligatoria")]
        [StringLength(100, ErrorMessage = "La editorial no puede exceder 100 caracteres")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "El ISBN es obligatorio")]
        [StringLength(20, ErrorMessage = "El ISBN no puede exceder 20 caracteres")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, 99999, ErrorMessage = "El precio debe estar entre 1 y 99999")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El idioma es obligatorio")]
        [StringLength(50, ErrorMessage = "El idioma no puede exceder 50 caracteres")]
        public string Language { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
