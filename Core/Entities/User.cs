using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{

    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }
}

