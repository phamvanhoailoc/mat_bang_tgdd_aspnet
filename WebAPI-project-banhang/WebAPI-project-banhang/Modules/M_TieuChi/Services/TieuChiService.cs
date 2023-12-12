using MediatR;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_TieuChi.Queries;
using WebAPI_project_banhang.Modules.M_TieuChi.ViewModels;

namespace WebAPI_project_banhang.Modules.M_TieuChi.Services
{
    public class TieuChiService : ITieuChiService
    {
        private readonly ISender _sender;

        public TieuChiService(ISender sender)
        {
            _sender = sender;
        }
        public Task<OutputTieuChiViewModel> GetListTieuChi(InputTieuChiViewModel inputTieuChiViewModel)
        {
            return _sender.Send(new GetTieuChiQuery(inputTieuChiViewModel));
        }
    }
}
