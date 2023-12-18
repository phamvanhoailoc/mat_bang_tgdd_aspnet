using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebAPI_project_banhang.Modules.M_MatBang.ViewModels
{
    public class CreateMatBangInputViewModel
    {
        public int? MaChiPhi { get; set; }

        public string? TenMB { get; set; }

        public string? DcMB { get; set; }

        public string? TinhMB { get; set; }

        public string? HuyenMB { get; set; }

        public string? XaMB { get; set; }

        public double? dientichMB { get; set; }

        public double? thetichMB { get; set; }

        public DateTime? ngayCN { get; set; }
    }
}
