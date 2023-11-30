using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_project_banhang.Modules.M_User.Models
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "username is required")]
        [MaxLength(100, ErrorMessage = "username must be between 6 and 100 characters")]
        [MinLength(6, ErrorMessage = "username must be between 6 and 100 character")]
        [Column("user_name")]
        public string UserName { get; set; }

        [Column("info")]
        public string Info { get; set; }

        [Required(ErrorMessage = "HashPassword is required")]
        [MaxLength(200, ErrorMessage = "HashPassword must be between 6 and 100 characters")]
        [MinLength(6, ErrorMessage = "HashPassword must be between 6 and 100 character")]
        [Column("hash_password")]
        public string HashPassword { get; set; }

        [Required(ErrorMessage = "CreatedAt is required")]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
