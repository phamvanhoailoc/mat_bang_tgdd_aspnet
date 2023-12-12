using System.ComponentModel.DataAnnotations;

namespace WebAPI_project_banhang.Modules.M_TieuChi.ViewModels
{
    public class InputTieuChiViewModel
    {
        [Required(ErrorMessage = "IdLoaiTieuChi is required")]
        public int IdLoaiTieuChi { get; set; }
    }
}
