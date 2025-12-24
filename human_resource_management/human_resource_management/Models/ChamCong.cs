namespace human_resource_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
        [Key]
        public int maChamCong { get; set; }

        public int maNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayCham { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
