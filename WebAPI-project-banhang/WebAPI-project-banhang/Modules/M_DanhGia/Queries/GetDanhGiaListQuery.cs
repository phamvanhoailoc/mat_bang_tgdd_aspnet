using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using WebAPI_project_banhang.Modules.M_DanhGia.ViewModels;
using WebAPI_project_banhang.Modules.M_DanhGia.Repositories;

namespace WebAPI_project_banhang.Modules.M_DanhGia.Queries
{
    public class GetDanhGiaListQuery : IRequest<GetDanhGiaListViewModel>
    {
        public FilterDanhGiaViewModel _filterDanhGiaViewModel { get; set; }

        public GetDanhGiaListQuery(FilterDanhGiaViewModel filterDanhGiaViewModel)
        {
            _filterDanhGiaViewModel = filterDanhGiaViewModel;
        }
    }
    public class GetSieuThiListQueryHandler : IRequestHandler<GetDanhGiaListQuery, GetDanhGiaListViewModel>
    {
        public IDanhGiaRepositories _iDanhGiaRepositories;

        public GetSieuThiListQueryHandler(IDanhGiaRepositories iDanhGiaRepositories)
        {
            _iDanhGiaRepositories = iDanhGiaRepositories;
        }
        public async Task<GetDanhGiaListViewModel> Handle(GetDanhGiaListQuery request, CancellationToken cancellationToken)
        {
            if(request._filterDanhGiaViewModel.page == 0 || 
                request._filterDanhGiaViewModel.page == null || 
                request._filterDanhGiaViewModel.pageSize == null || 
                request._filterDanhGiaViewModel.pageSize == 0) 
                throw new ArgumentException("page or pagesize not is 0 or null");

            string fromDate = request._filterDanhGiaViewModel?.RageDate?.fromDate.ToString() ?? "";
            string toDate = request._filterDanhGiaViewModel?.RageDate?.toDate.ToString() ?? "";

            GetDanhGiaListViewModel getDanhGiaListViewModel = new GetDanhGiaListViewModel();

            var countRecordTask = _iDanhGiaRepositories.CountRecordDanhGiaAsync(request._filterDanhGiaViewModel, fromDate, toDate);
            var filterDanhGiaTask = _iDanhGiaRepositories.FilterDanhGiaAsync(request._filterDanhGiaViewModel, fromDate, toDate);

            // Sử dụng Task.WhenAll để thực hiện đồng thời cả lệnh gọi ADO.NET và Entity Framework
            await Task.WhenAll(countRecordTask, filterDanhGiaTask);

            getDanhGiaListViewModel.TotalCount = countRecordTask.Result;

            getDanhGiaListViewModel.DanhGia = filterDanhGiaTask.Result;

            return getDanhGiaListViewModel;
        }
    }
}

