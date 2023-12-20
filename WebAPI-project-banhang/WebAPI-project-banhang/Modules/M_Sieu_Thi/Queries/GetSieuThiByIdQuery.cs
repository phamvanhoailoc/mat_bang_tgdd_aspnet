using MediatR;
using System.Threading.Tasks;
using System.Threading;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Repositories;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Models;
using System;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Queries
{
    public class GetSieuThiByIdQuery : IRequest<OutputGetSieuThiByIdViewModel>
    {
        public int _id { get; set; }

        public GetSieuThiByIdQuery( int id)
        {
            _id = id;
        }
    }
    public class GetSieuThiByIdQueryHandler : IRequestHandler<GetSieuThiByIdQuery, OutputGetSieuThiByIdViewModel>
    {
        public ISieuThiRepositories _getSieuThiRepositories;
        public GetSieuThiByIdQueryHandler(ISieuThiRepositories getSieuThiRepositories)
        {
            _getSieuThiRepositories = getSieuThiRepositories;
        }
        public async Task<OutputGetSieuThiByIdViewModel> Handle(GetSieuThiByIdQuery request, CancellationToken cancellationToken)
        {
            OutputGetSieuThiByIdViewModel getSieuThiByIdViewModel = new OutputGetSieuThiByIdViewModel();

            if(request._id.ToString() == null || request._id < 0) throw new ArgumentException("id not is < 0 or null");

            SieuThiById sieuthi = await _getSieuThiRepositories.GetSieuThiById(request._id);

            if (sieuthi == null) throw new ArgumentException("is not sieu thi by id = " + request._id);

            getSieuThiByIdViewModel.SieuThi = sieuthi;

            return getSieuThiByIdViewModel;
        }
    }
}
