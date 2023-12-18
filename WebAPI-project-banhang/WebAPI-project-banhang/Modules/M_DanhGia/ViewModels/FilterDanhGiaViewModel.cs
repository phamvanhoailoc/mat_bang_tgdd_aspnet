using System;
using WebAPI_project_banhang.Lib.Utils;

namespace WebAPI_project_banhang.Modules.M_DanhGia.ViewModels
{
    public class FilterDanhGiaViewModel
    {
        public int? page { get; set; }

        public int? pageSize { get; set; }

        public string? keyword { get; set; }

        public RageDate RageDate { get; set;}

        public string? tinhst { get; set; }


    }
}
