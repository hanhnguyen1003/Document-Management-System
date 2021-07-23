namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONGVIEC")]
    public partial class CONGVIEC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONGVIEC()
        {
            CHI_TIET_GIAO_VIEC = new HashSet<CHI_TIET_GIAO_VIEC>();
        }

        [Key]
        public decimal ID_CONG_VIEC { get; set; }

        public decimal ID_DO_QUAN_TRONG { get; set; }

        public decimal ID_TAP_TIN { get; set; }

        public decimal ID_NHAN_VIEN { get; set; }

        public decimal ID_LINH_VUC { get; set; }

        public decimal ID_TRANG_THAI { get; set; }

        [Required]
        [StringLength(50)]
        public string TIEU_DE { get; set; }

        public DateTime NGAY_HET_HAN { get; set; }

        public DateTime HAN_XU_LY { get; set; }

        public float TY_LE_HOAN_THANH { get; set; }

        [Required]
        [StringLength(200)]
        public string NOI_DUNG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_GIAO_VIEC> CHI_TIET_GIAO_VIEC { get; set; }

        public virtual TRANGTHAICONGVIEC TRANGTHAICONGVIEC { get; set; }

        public virtual LINHVUC LINHVUC { get; set; }

        public virtual FILEDINHKEM FILEDINHKEM { get; set; }

        public virtual DOQUANTRONG DOQUANTRONG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
