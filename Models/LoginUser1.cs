using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Login.Models
{
    public class LoginUser1
    {
        [Key] 
        public int UserID { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string? UserNAME1 { get; set; }
        [Required]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        [MinLength(5)]
        public string? Password11 { get; set; }

        //public string? nuOFC { get; set; }
        
        
    }
}
