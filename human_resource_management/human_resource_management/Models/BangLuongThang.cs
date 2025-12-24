namespace human_resource_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangLuongThang")]
    public partial class BangLuongThang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BangLuongThang()
        {
            ChiTietBangLuongs = new HashSet<ChiTietBangLuong>();
        }

        [Key]
        public int maBangLuongThang { get; set; }

        public int thang { get; set; }

        public int nam { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayTao { get; set; }

        [StringLength(100)]
        public string nguoiTao { get; set; }

        public bool trangThai { get; set; }

        [StringLength(500)]
        public string ghiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietBangLuong> ChiTietBangLuongs { get; set; }
    }
}
