using System.ComponentModel.DataAnnotations;

namespace WebApplication_Login.Models
{
    public class Create
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string? UserName { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string? Password { get; set; }
        [MaxLength(10)]
        public string? Phone { get; set; }
    }
}
