using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_File_System.Models;

namespace WebAPI_project_banhang.Modules.M_File_System.Repositories
{
    public interface IUploadRepository
    {
        Task Create(List<FileUpload> fileUpload);
        Task<bool> Delete(string idFile);

    }
}
