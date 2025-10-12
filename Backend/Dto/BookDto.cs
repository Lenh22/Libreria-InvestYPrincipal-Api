namespace Libreria_InvestYPrincipal_Api.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } // Para los GET
    }
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Language { get; set; } = string.Empty;
        public int AuthorId { get; set; } 
    }
    public class UpdateBookDto
    {
        public int Id { get; set; }               
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Language { get; set; } = string.Empty;
        public int AuthorId { get; set; }        
    }
}
