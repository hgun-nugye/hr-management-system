namespace human_resource_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietBangLuong")]
    public partial class ChiTietBangLuong
    {
        [Key]
        public int maChiTiet { get; set; }

        public int maBangLuongThang { get; set; }

        public int maNV { get; set; }

        public decimal luongThucNhan { get; set; }

        public virtual BangLuongThang BangLuongThang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
