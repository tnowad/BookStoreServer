using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string PasswordSalt { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public void SetPassword(string password, string salt)
        {
            PasswordHash = password;
            PasswordSalt = salt;
        }

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }

}

