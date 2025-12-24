namespace human_resource_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            ChamCongs = new HashSet<ChamCong>();
            ChiTietBangLuongs = new HashSet<ChiTietBangLuong>();
            HopDongs = new HashSet<HopDong>();
        }

        [Key]
        public int maNV { get; set; }

        [Required]
        [StringLength(100)]
        public string hoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaySinh { get; set; }

        public bool? gioiTinh { get; set; }

        [StringLength(255)]
        public string diaChi { get; set; }

        [StringLength(15)]
        public string dienThoai { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string chucVu { get; set; }

        [StringLength(50)]
        public string trangThaiLamViec { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayVaoLam { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayKetThucLam { get; set; }

        public int? maPB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietBangLuong> ChiTietBangLuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }

        public virtual PhongBan PhongBan { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
