using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_project_banhang.Modules.M_TieuChi.Models
{
    public class TieuChi
    {
        [Key]
        [Column("matc")]
        public int MaTC { get; set; }

        [Column("tentc")]
        public string TenCT { get; set; }

        [Column("tenltc")]
        public string Tenltc { get; set; }

    }
}
