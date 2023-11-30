using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_File_System.Commands;
using WebAPI_project_banhang.Modules.M_File_System.Models;
using WebAPI_project_banhang.Modules.M_File_System.ViewModels;
using WebAPI_project_banhang.Modules.M_User.ViewModels;
using WebAPI_project_banhang.Modules.M_Users.Commands;

namespace WebAPI_project_banhang.Modules.M_File_System.Services
{
    public class FileService : IFileService
    {
        private readonly ISender _sender;

        public FileService(ISender sender)
        {
            _sender = sender;
        }

        public async Task FileDelete(FileDeleteViewModel body)
        {
            await _sender.Send(new FileDeleteCommand(body));
        }

        public async Task<List<ResFileUpload>> FileUpload(FileUploadViewModel body)
        {
            return await _sender.Send(new FileUploadCommand(body));
        }
    }
}
