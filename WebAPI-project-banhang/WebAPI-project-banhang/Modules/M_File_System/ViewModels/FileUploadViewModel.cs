using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebAPI_project_banhang.Modules.M_File_System.ViewModels
{
    public class FileUploadViewModel
    {
        public string? UserId { get; set; }
        public string type { get; set; }
        public List<IFormFile> file { get; set; }
    }
}
