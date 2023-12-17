using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_MatBang.Models;
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

        public Task<MatBangOutputViewModel> GetMatBangList(MatBangInputViewModel matBangInputViewModel)
        {
            return _sender.Send(new GetMatBangListQuery(matBangInputViewModel));
        }
    }
}
