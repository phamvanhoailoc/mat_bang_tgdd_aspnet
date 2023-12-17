using MediatR;
using System.Threading.Tasks;
using System.Threading;
using WebAPI_project_banhang.Modules.M_MatBang.ViewModels;
using WebAPI_project_banhang.Modules.M_MatBang.Repositories;
using System;

namespace WebAPI_project_banhang.Modules.M_MatBang.Queries
{
    public class GetMatBangListQuery : IRequest<MatBangOutputViewModel>
    {
        public MatBangInputViewModel _matBangInputViewModel { get; set; }

        public GetMatBangListQuery(MatBangInputViewModel matBangInputViewModel)
        {
            _matBangInputViewModel = matBangInputViewModel;
        }
    }
    public class GetSieuThiListQueryHandler : IRequestHandler<GetMatBangListQuery, MatBangOutputViewModel>
    {
        public IGetMatBangListRepositories _getMatBangListRepositories;

        public GetSieuThiListQueryHandler(IGetMatBangListRepositories getMatBangListRepositories)
        {
            _getMatBangListRepositories = getMatBangListRepositories;
        }
        public async Task<MatBangOutputViewModel> Handle(GetMatBangListQuery request, CancellationToken cancellationToken)
        {
            if (request._matBangInputViewModel.page == 0 ||
                request._matBangInputViewModel.page == null ||
                request._matBangInputViewModel.pageSize == null ||
                request._matBangInputViewModel.pageSize == 0)
                throw new ArgumentException("page or pagesize not is 0 or null");

            string fromDate = request._matBangInputViewModel?.RageDate?.fromDate.ToString() ?? "";
            string toDate = request._matBangInputViewModel?.RageDate?.toDate.ToString() ?? "";

            MatBangOutputViewModel matBangOutputViewModel = new MatBangOutputViewModel();

            var countRecordTask = _getMatBangListRepositories.CountRecordMatBangAsync(request._matBangInputViewModel, fromDate, toDate);
            var filterSieuThiTask = _getMatBangListRepositories.FilterMatBangAsync(request._matBangInputViewModel, fromDate, toDate);

            await Task.WhenAll(countRecordTask, filterSieuThiTask);

            matBangOutputViewModel.TotalCount = countRecordTask.Result;

            matBangOutputViewModel.matbang = filterSieuThiTask.Result;

            return matBangOutputViewModel;
        }
    }
}