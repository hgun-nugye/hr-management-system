namespace human_resource_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDong")]
    public partial class HopDong
    {
        [Key]
        public int maHD { get; set; }

        public int maNV { get; set; }

        public byte loaiHD { get; set; }

        public decimal heSoLuong { get; set; }

        public decimal luongCoBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayKetThuc { get; set; }

        public bool trangThai { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
