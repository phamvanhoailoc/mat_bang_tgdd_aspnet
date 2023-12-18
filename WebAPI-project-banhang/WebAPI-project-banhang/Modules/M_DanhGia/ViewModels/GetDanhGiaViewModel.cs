using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Models;
using WebAPI_project_banhang.Modules.M_DanhGia.Models;

namespace WebAPI_project_banhang.Modules.M_DanhGia.ViewModels
{
    
    public class GetDanhGiaListViewModel
    {
        public List<DanhGia> DanhGia { get; set; }
        public int TotalCount { get; set; }
    }
}
