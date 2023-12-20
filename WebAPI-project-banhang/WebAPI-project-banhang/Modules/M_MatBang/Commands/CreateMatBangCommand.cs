using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using WebAPI_project_banhang.Modules.M_MatBang.ViewModels;
using WebAPI_project_banhang.Modules.M_MatBang.Repositories;

namespace WebAPI_project_banhang.Modules.M_MatBang.Commands
{
    public class CreateMatBangCommand : IRequest<bool>
    {
        public CreateMatBangInputViewModel _createMatBangInputViewModel { get; set; }

        public CreateMatBangCommand(CreateMatBangInputViewModel createMatBangInputViewModel)
        {
            _createMatBangInputViewModel = createMatBangInputViewModel;
        }
    }
    public class CreateMatBangCommandHandler : IRequestHandler<CreateMatBangCommand, bool>
    {
        public IGetMatBangListRepositories _getMatBangListRepositories;
        public CreateMatBangCommandHandler(IGetMatBangListRepositories getMatBangListRepositories)
        {
            _getMatBangListRepositories = getMatBangListRepositories;
        }
        public async Task<bool> Handle(CreateMatBangCommand request, CancellationToken cancellationToken)
        {
            bool result = await _getMatBangListRepositories.CreateMatBang(request._createMatBangInputViewModel);
            return result;
        }
    }
}
