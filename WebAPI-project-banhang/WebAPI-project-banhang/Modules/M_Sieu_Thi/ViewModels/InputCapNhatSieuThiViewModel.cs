using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels
{
    public class InputCapNhatSieuThiViewModel
    {
        [Required(ErrorMessage = "SbntST is required")]
        public decimal SbntST { get; set; }
        [Required(ErrorMessage = "SbnlST is required")]
        public decimal SbnlST { get; set; }

        [Required(ErrorMessage = "NguoiCN is required")]
        public int NguoiCN { get; set; }
    }
}
