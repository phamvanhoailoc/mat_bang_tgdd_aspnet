using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Models
{
    public class SieuThiById
    {
        [Key]
        [Column("mast")]
        public int MaST { get; set; }

        [Column("tenst")]
        public string TenST { get; set; }

        [Column("dcst")]
        public string DcST { get; set; }

        [Column("dmhh")]
        public string DmHH { get; set; }

        [Column("sbntST")]
        public decimal SbntST { get; set; }

        [Column("sbnlST")]
        public decimal SbnlST { get; set; }

        [Column("NguoiCN")]
        public int NguoiCN { get; set; }
    }
}
