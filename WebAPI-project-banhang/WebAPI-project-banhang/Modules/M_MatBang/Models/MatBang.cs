using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_project_banhang.Modules.M_MatBang.Models
{
    public class MatBang
    {
        [Key]
        [Column("mamb")]
        public int MaMB { get; set; }

        [Column("machiphi")]
        public int? MaChiPhi { get; set; }

        [Column("tenmb")]
        public string? TenMB { get; set; }

        [Column("dcmb")]
        public string? DcMB { get; set; }

        [Column("tinhmb")]
        public string? TinhMB { get; set; }

        [Column("huyenmb")]
        public string? HuyenMB { get; set; }

        [Column("xamb")]
        public string? XaMB { get; set; }

        [Column("dtmb")]
        public double? dientichMB { get; set; }

        [Column("ttmb")]
        public double? thetichMB { get; set; }

        [Column("ngayCN")]
        public DateTime? ngayCN { get; set; }
    }
}
