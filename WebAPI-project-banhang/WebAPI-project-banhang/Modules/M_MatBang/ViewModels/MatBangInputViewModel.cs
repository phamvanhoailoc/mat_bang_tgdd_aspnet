using System.ComponentModel.DataAnnotations;
using System;
using MediatR;
using WebAPI_project_banhang.Lib.Utils;

namespace WebAPI_project_banhang.Modules.M_MatBang.ViewModels
{
        public class MatBangInputViewModel
        {
            public int? page { get; set; }

            public int? pageSize { get; set; }

            public string? keyword { get; set; }

            public RageDate RageDate { get; set; }

            public string? tinhst { get; set; }
            public string? huyenst { get; set; }
            public string? xast { get; set; }

        }
}
