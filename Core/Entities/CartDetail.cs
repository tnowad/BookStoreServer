using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CartDetail
    {
        [Key]
        [Column(Order = 0)]
        public Guid CartId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid BookId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(CartId))]
        public virtual Cart Cart { get; set; } = null!;

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; } = null!;
    }
}


