using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Queries;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;
using WebAPI_project_banhang.Modules.M_Users.Queries;
using WebAPI_project_banhang.Modules.M_Users.ViewModels;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Services
{
    public class SieuThiService : ISieuThiService
    {
        private readonly ISender _sender;

        public SieuThiService(ISender sender)
        {
            _sender = sender;
        }

        public Task<GetSieuThiListViewModel> getListSieuThi(FilterSieuThiViewModel filterSieuThiViewModel)
        {
            return _sender.Send(new GetSieuThiListQuery(filterSieuThiViewModel));
        }
    }
}
