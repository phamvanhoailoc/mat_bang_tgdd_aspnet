using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Models;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels
{
    
    public class GetSieuThiListViewModel
    {
        public List<SieuThi> sieuThi { get; set; }
        public int TotalCount { get; set; }
    }
}
