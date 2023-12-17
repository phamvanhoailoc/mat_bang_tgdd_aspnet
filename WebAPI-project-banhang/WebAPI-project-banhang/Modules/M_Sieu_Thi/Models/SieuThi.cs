using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Models
{
    public class SieuThi
    {
        [Key]
        [Column("mast")]
        public int MaST { get; set; }

        [Column("tenst")]
        public string TenST { get; set; }

        [Column("dcst")]
        public string DcST { get; set; }

        [Column("NguoiCN")]
        public int NguoiCN { get; set; }
    }
}
