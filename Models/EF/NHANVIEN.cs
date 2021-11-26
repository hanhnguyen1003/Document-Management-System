namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            CHI_TIET_GIAO_VIEC = new HashSet<CHI_TIET_GIAO_VIEC>();
            CONGVIECs = new HashSet<CONGVIEC>();
            VANBAN_NHANVIEN = new HashSet<VANBAN_NHANVIEN>();
            NHANVIENBUTPHEs = new HashSet<NHANVIENBUTPHE>();
            LICHLAMVIECs = new HashSet<LICHLAMVIEC>();
        }

        [Key]
        public decimal ID_NHAN_VIEN { get; set; }

        public decimal ID_DON_VI { get; set; }

        public decimal ID_VAI_TRO { get; set; }

        [Required]
        [StringLength(30)]
        public string MA_NHAN_VIEN { get; set; }

        [Required]
        [StringLength(50)]
        public string HO_TEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SDT { get; set; }

        public DateTime NGAY_SINH { get; set; }

        [Required]
        [StringLength(30)]
        public string DIA_CHI { get; set; }

        [Required]
        [StringLength(10)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(10)]
        public string PASSWORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_GIAO_VIEC> CHI_TIET_GIAO_VIEC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGVIEC> CONGVIECs { get; set; }

        public virtual DONVI DONVI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VANBAN_NHANVIEN> VANBAN_NHANVIEN { get; set; }

        public virtual VAITRO VAITRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIENBUTPHE> NHANVIENBUTPHEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHLAMVIEC> LICHLAMVIECs { get; set; }
    }
}
