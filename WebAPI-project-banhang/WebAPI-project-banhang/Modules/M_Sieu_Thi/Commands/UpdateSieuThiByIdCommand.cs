using MediatR;
using System.Threading.Tasks;
using System.Threading;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Repositories;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Models;
using System;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Commands
{
    public class UpdateSieuThiByIdCommand : IRequest<bool>
    {
        public int _id { get; set; }
        public InputCapNhatSieuThiViewModel _inputCapNhatSieuThiViewModel { get; set; }

        public UpdateSieuThiByIdCommand(InputCapNhatSieuThiViewModel inputCapNhatSieuThiViewModel, int id)
        {
            _inputCapNhatSieuThiViewModel = inputCapNhatSieuThiViewModel;
            _id = id;
        }
    }
    public class UpdateSieuThiByIdCommandHandler : IRequestHandler<UpdateSieuThiByIdCommand, bool>
    {
        public ISieuThiRepositories _getSieuThiRepositories;
        public UpdateSieuThiByIdCommandHandler(ISieuThiRepositories getSieuThiRepositories)
        {
            _getSieuThiRepositories = getSieuThiRepositories;
        }
        public async Task<bool> Handle(UpdateSieuThiByIdCommand request, CancellationToken cancellationToken)
        {
            if(request._id.ToString() == null || request._id < 0) 
                throw new ArgumentException("id not is < 0 or null");

            if(request._inputCapNhatSieuThiViewModel.SbnlST < 0 || 
                request._inputCapNhatSieuThiViewModel.SbntST < 0) 
                throw new ArgumentException("SbnlST and SbntST not is < 0 ");

            bool result = await _getSieuThiRepositories.UpdateSieuThiById(request._inputCapNhatSieuThiViewModel,request._id);
            return result;
        }
    }
}
