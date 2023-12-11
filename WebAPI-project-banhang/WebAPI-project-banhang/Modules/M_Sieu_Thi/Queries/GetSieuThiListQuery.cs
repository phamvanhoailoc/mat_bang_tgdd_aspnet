using MediatR;
using System.Threading.Tasks;
using System.Threading;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Repositories;
using System;

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
        public async Task<GetSieuThiListViewModel> Handle(GetSieuThiListQuery request, CancellationToken cancellationToken)
        {
            if(request._filterSieuThiViewModel.page == 0 || 
                request._filterSieuThiViewModel.page == null || 
                request._filterSieuThiViewModel.pageSize == null || 
                request._filterSieuThiViewModel.pageSize == 0) 
                throw new ArgumentException("page or pagesize not is 0 or null");

            string fromDate = request._filterSieuThiViewModel?.RageDate?.fromDate.ToString() ?? "";
            string toDate = request._filterSieuThiViewModel?.RageDate?.toDate.ToString() ?? "";

            GetSieuThiListViewModel getSieuThiListViewModel = new GetSieuThiListViewModel();

            var countRecordTask = _getSieuThiRepositories.CountRecordSieuThiAsync(request._filterSieuThiViewModel, fromDate, toDate);
            var filterSieuThiTask = _getSieuThiRepositories.FilterSieuThiAsync(request._filterSieuThiViewModel, fromDate, toDate);

            // Sử dụng Task.WhenAll để thực hiện đồng thời cả lệnh gọi ADO.NET và Entity Framework
            await Task.WhenAll(countRecordTask, filterSieuThiTask);

            getSieuThiListViewModel.TotalCount = countRecordTask.Result;

            getSieuThiListViewModel.sieuThi = filterSieuThiTask.Result;

            return getSieuThiListViewModel;
        }
    }
}

