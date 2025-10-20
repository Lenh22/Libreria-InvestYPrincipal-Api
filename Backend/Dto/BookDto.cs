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
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Range(1, 1000, ErrorMessage = "El número de páginas debe estar entre 1 y 1000")]

        public int Pages { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;

        [Range(1, 99999, ErrorMessage = "El precio debe estar entre 1 y 99999")]
        [Column(TypeName = "decimal(10,2)")]

        public decimal Price { get; set; }
        public string Language { get; set; } = string.Empty;
        public int AuthorId { get; set; } 
    }
    public class UpdateBookDto
    {
        public int Id { get; set; }               
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Range(1, 1000, ErrorMessage = "El número de páginas debe estar entre 1 y 1000")]

        public int Pages { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;

        [Range(1, 99999, ErrorMessage = "El precio debe estar entre 1 y 99999")]
        [Column(TypeName = "decimal(10,2)")]

        public decimal Price { get; set; }
        public string Language { get; set; } = string.Empty;
        public int AuthorId { get; set; }        
    }
}
