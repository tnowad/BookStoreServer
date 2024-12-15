using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountPrice { get; set; }

        [Required]
        [MaxLength(255)]
        public string Author { get; set; } = string.Empty;

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
        [Required]
        public DateTime PublishDate { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

        public virtual ICollection<BookCatalogue> BookCatalogues { get; set; } = new List<BookCatalogue>();
    }
}


