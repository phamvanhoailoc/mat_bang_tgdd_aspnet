using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using MediatR;
using WebAPI_project_banhang.Modules.M_User.Models;

namespace WebAPI_project_banhang.Modules.M_User.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "username is required")]
        [MaxLength(100, ErrorMessage = "username must be between 6 and 100 characters")]
        [MinLength(6, ErrorMessage = "username must be between 6 and 100 character")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "HashPassword is required")]
        [MaxLength(200, ErrorMessage = "HashPassword must be between 6 and 100 characters")]
        [MinLength(6, ErrorMessage = "HashPassword must be between 6 and 100 character")]
        public string HashPassword { get; set; }

        [Required(ErrorMessage = "CreatedAt is required")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
