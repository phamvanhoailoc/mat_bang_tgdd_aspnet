using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_project_banhang.Lib.Utils;
using WebAPI_project_banhang.Modules.M_File_System.Repositories;
using WebAPI_project_banhang.Modules.M_File_System.ViewModels;

namespace WebAPI_project_banhang.Modules.M_File_System.Commands
{
    public class FileDeleteCommand : IRequest<bool>
    {
        public FileDeleteViewModel _fileDeleteViewModel { get; set; }

        public FileDeleteCommand(FileDeleteViewModel fileDeleteViewModel)
        {
            _fileDeleteViewModel = fileDeleteViewModel;
        }
    }
    public class FileDeleteCommandHandler : IRequestHandler<FileDeleteCommand, bool>
    {
        private readonly IUploadRepository _uploadRepository;

        public FileDeleteCommandHandler(IUploadRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;
        }
        public async Task<bool> Handle(FileDeleteCommand request, CancellationToken cancellationToken)
        {

            if (request._fileDeleteViewModel.id_file.Count == 0) throw new ArgumentException("Invalid id file");

            foreach (var item in request._fileDeleteViewModel.id_file)
            {
                bool DeleteFile = await _uploadRepository.Delete(item);

                if (DeleteFile != true) throw new ArgumentException("Không tìm thấy file trong database");

                bool DeleteURL = await UploadFile.DeleteFile(item);

                if(DeleteURL != true) throw new ArgumentException("Không tìm thấy file trong thư mục");

            }
            return await Task.FromResult(true);

        }
    }
}
