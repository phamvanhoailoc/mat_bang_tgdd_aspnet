using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_project_banhang.Modules.M_DanhGia.Models
{
    public class DanhGia
    {
        [Key]
        [Column("maddg")]
        public int? Maddg { get; set; }

        [Column("vitri")]
        public string? vitri { get; set; }

        [Column("ngaytl")]
        public DateTime? ngaytl { get; set; }

        [Column("tght")]
        public DateTime? tght { get; set; }
        [Column("ngaydg")]
        public DateTime? ngaydg { get; set; }
        [Column("tenmb")]
        public string? tenmb { get; set; }
    }
}
