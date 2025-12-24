namespace human_resource_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maNV { get; set; }

        [Required]
        [StringLength(50)]
        public string tenTK { get; set; }

        [Required]
        [StringLength(255)]
        public string matKhau { get; set; }

        [Required]
        [StringLength(50)]
        public string vaiTro { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
