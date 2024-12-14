using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
    }
}


