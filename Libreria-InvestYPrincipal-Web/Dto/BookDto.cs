using System;

namespace Libreria_InvestYPrincipal_Web.Dto
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
        public string AuthorName { get; set; }
    }
}
