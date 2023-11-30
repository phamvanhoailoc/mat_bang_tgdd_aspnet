using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_File_System.Models;
using WebAPI_project_banhang.Modules.M_File_System.ViewModels;

namespace WebAPI_project_banhang.Modules.M_File_System.Services
{
    public interface IFileService
    {
        Task<List<ResFileUpload>> FileUpload(FileUploadViewModel body);
        Task FileDelete(FileDeleteViewModel body);
    }
}
