using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class BookCatalogue
    {
        [Key]
        [Column(Order = 0)]
        public Guid BookId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid CatalogueId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; } = null!;

        [ForeignKey(nameof(CatalogueId))]
        public virtual Catalogue Catalogue { get; set; } = null!;
    }
}


