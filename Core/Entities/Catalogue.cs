using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Catalogue
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<BookCatalogue> BookCatalogues { get; set; } = new List<BookCatalogue>();
    }
}


