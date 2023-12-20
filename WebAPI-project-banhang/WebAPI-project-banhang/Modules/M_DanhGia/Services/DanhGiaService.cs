using MediatR;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_DanhGia.Queries;
using WebAPI_project_banhang.Modules.M_DanhGia.ViewModels;


namespace WebAPI_project_banhang.Modules.M_DanhGia.Services
{
    public class DanhGiaService : IDanhGiaService
    {
        private readonly ISender _sender;

        public DanhGiaService(ISender sender)
        {
            _sender = sender;
        }

        public Task<GetDanhGiaListViewModel> getListDanhGia(FilterDanhGiaViewModel filterDanhGiaViewModel)
        {
            return _sender.Send(new GetDanhGiaListQuery(filterDanhGiaViewModel));
        }
 
    }
}
