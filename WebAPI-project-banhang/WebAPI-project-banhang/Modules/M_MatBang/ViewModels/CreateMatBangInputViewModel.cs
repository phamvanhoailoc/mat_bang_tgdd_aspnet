using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_project_banhang.Modules.M_MatBang.ViewModels
{
    public class CreateMatBangInputViewModel
    {
        public string? MaChiPhi { get; set; }
        [Required(ErrorMessage = "TenMB is required")]
        public string? TenMB { get; set; }
        public string? DcMB { get; set; }
        public string? TinhMB { get; set; }
        public string? HuyenMB { get; set; }
        public string? XaMB { get; set; }
        public double? dientichMB { get; set; }
        public double? thetichMB { get; set; }
        public int? phaplymb { get; set; }
        public int? hethonggiaothongmb { get; set; }
        public int? pcccmb { get; set; }
        public DateTime? ngayCN { get; set; }
    }
}
