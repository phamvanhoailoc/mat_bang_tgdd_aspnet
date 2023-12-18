using MediatR;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_MatBang.Commands;
using WebAPI_project_banhang.Modules.M_MatBang.Queries;
using WebAPI_project_banhang.Modules.M_MatBang.ViewModels;

namespace WebAPI_project_banhang.Modules.M_MatBang.Services
{
    public class MatBangService : IMatBangService
    {
        private readonly ISender _sender;

        public MatBangService(ISender sender)
        {
            _sender = sender;
        }

        public Task<bool> CreateMatBang(CreateMatBangInputViewModel createMatBangInputViewModel)
        {
            return _sender.Send(new CreateMatBangCommand(createMatBangInputViewModel));
        }

        public Task<MatBangOutputViewModel> GetMatBangList(MatBangInputViewModel matBangInputViewModel)
        {
            return _sender.Send(new GetMatBangListQuery(matBangInputViewModel));
        }
    }
}
