using MediatR;
using System.Threading.Tasks;
using System.Threading;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Repositories;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Queries
{
    public class GetSieuThiListQuery : IRequest<GetSieuThiListViewModel>
    {
        public FilterSieuThiViewModel _filterSieuThiViewModel { get; set; }

        public GetSieuThiListQuery(FilterSieuThiViewModel filterSieuThiViewModel)
        {
            _filterSieuThiViewModel = filterSieuThiViewModel;
        }
    }
    public class GetSieuThiListQueryHandler : IRequestHandler<GetSieuThiListQuery, GetSieuThiListViewModel>
    {
        public ISieuThiRepositories _getSieuThiRepositories;

        public GetSieuThiListQueryHandler(ISieuThiRepositories getSieuThiRepositories)
        {
            _getSieuThiRepositories = getSieuThiRepositories;
        }
        public Task<GetSieuThiListViewModel> Handle(GetSieuThiListQuery request, CancellationToken cancellationToken)
        {
            return _getSieuThiRepositories.getSieuThiListRepo(request._filterSieuThiViewModel);
        }
    }
}

