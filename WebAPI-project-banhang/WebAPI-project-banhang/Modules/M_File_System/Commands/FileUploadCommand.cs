using MediatR;
using System.Threading.Tasks;
using System.Threading;
using WebAPI_project_banhang.Modules.M_File_System.Models;
using WebAPI_project_banhang.Modules.M_File_System.ViewModels;
using WebAPI_project_banhang.Modules.M_File_System.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.IO;
using static WebAPI_project_banhang.Modules.M_File_System.Variable;
using WebAPI_project_banhang.Lib.Utils;
using System.Net.Http.Headers;
using System.Linq;
using System.Drawing;

namespace WebAPI_project_banhang.Modules.M_File_System.Commands
{
    public class FileUploadCommand : IRequest<List<ResFileUpload>>
    {
        public FileUploadViewModel _fileUploadViewModel { get; set; }

        public FileUploadCommand(FileUploadViewModel fileUploadViewModel)
        {
            _fileUploadViewModel = fileUploadViewModel;
        }
    }

    public class FileUploadCommandHandler : IRequestHandler<FileUploadCommand, List<ResFileUpload>>
    {
        private readonly IUploadRepository _uploadRepository;

        public FileUploadCommandHandler(IUploadRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;
        }
        public async Task<List<ResFileUpload>> Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            if (request._fileUploadViewModel.file.Count == 0) { 
               throw new ArgumentException("Invalid images");
            }

            List<FileUpload> files = new List<FileUpload>();
            for (int i = 0; i < request._fileUploadViewModel.file.Count; i++) { 
                var file = request._fileUploadViewModel.file[i];

                //kiểm tra size file
                if (file.Length > 10000000) throw new ArgumentException("Max size is 10MB");

                //kiểm tra type có giống với type đã khai báo
                var viewType = UploadFile.ParseViewType(file.ContentType);
                if (viewType !=  request._fileUploadViewModel.type) throw new ArgumentException("Type different from description");

                var fileExt = Path.GetExtension(file.FileName);

                var fileNameOld = file.FileName;

                //biến đổi tên file và lưu file vào đường dẫn chỉ định
                var fileName = UploadFile.UploadFileDirect(file);

                files.Add(new FileUpload
                {
                    client_filename = fileNameOld,
                    server_filename = fileName,
                    file_ext = fileExt,
                    file_group = "default",
                    file_size = file.Length,
                    file_type = file.ContentType,
                    filepath = IMAGE.FILEPATH,
                    view_type = viewType,
                    user_create = request._fileUploadViewModel.UserId,
                    time_create = DateTime.Now
                });
            }
            await _uploadRepository.Create(files);

            //map dữ liệu cho ui sử dụng
            List<ResFileUpload> resfiles = files.Select(file => new ResFileUpload
            {
                id = file.server_filename,
                name = file.server_filename,
                path = $"{Variable.URL_PUB_MAIN_API}/{UploadFile.FileDirectory}/{file.server_filename}",
                size = file.file_size
            }).ToList();
            
            return resfiles;
        }

    }
}
