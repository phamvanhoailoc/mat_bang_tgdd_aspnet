using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using WebAPI_project_banhang.Modules.M_TieuChi.ViewModels;
using WebAPI_project_banhang.Modules.M_TieuChi.Repositories;
using WebAPI_project_banhang.Modules.M_TieuChi.Models;
using System.Collections.Generic;

namespace WebAPI_project_banhang.Modules.M_TieuChi.Queries
{
    public class GetTieuChiQuery : IRequest<OutputTieuChiViewModel>
    {
        public InputTieuChiViewModel _inputTieuChiViewModel { get; set; }

        public GetTieuChiQuery(InputTieuChiViewModel inputTieuChiViewModel)
        {
            _inputTieuChiViewModel = inputTieuChiViewModel;
        }
    }
    public class GetTieuChiQueryHandler : IRequestHandler<GetTieuChiQuery, OutputTieuChiViewModel>
    {
        public ITieuChiRepositories _iTieuChiRepositories;
        public GetTieuChiQueryHandler(ITieuChiRepositories iTieuChiRepositories)
        {
            _iTieuChiRepositories = iTieuChiRepositories;
        }
        public async Task<OutputTieuChiViewModel> Handle(GetTieuChiQuery request, CancellationToken cancellationToken)
        {
            OutputTieuChiViewModel getTieuChiViewModel = new OutputTieuChiViewModel();

            if (request._inputTieuChiViewModel.IdLoaiTieuChi.ToString() == null || request._inputTieuChiViewModel.IdLoaiTieuChi < 0) throw new ArgumentException("id not is < 0 or null");

            List<TieuChi> sieuthi = await _iTieuChiRepositories.GetListTieuChi(request._inputTieuChiViewModel);

            if (sieuthi == null) throw new ArgumentException("is not tieu chi by id = " + request._inputTieuChiViewModel.IdLoaiTieuChi);

            getTieuChiViewModel.TieuChis = sieuthi;

            return getTieuChiViewModel;
        }
    }
}
