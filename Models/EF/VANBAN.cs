namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("VANBAN")]
    public partial class VANBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VANBAN()
        {
            BUTPHEs = new HashSet<BUTPHE>();
            VANBAN_NHANVIEN = new HashSet<VANBAN_NHANVIEN>();
        }

        [Key]
        [DisplayName("Mã văn bản:")]
        public decimal ID_VAN_BAN { get; set; }
        [DisplayName("Nơi phát hành:")]
        public decimal ID_NOI_PHAT_HANH { get; set; }
        [DisplayName("Loại văn bản:")]
        public decimal? ID_LOAI_VAN_BAN { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Số văn bản:")]
        public string SO_VAN_BAN { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Trích yếu:")]
        public string TRICH_YEU { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Người ký:")]
        public string NGUOI_KY { get; set; }
        [DisplayName("Ngày ký:")]
        public DateTime NGAY_KY { get; set; }

        [StringLength(20)]
        [DisplayName("Trạng thái xử lý:")]
        public string TRANG_THAI_XU_LY { get; set; }
        [DisplayName("Ngày gởi:")]
        public DateTime? NGAY_GOI { get; set; }
        [DisplayName("Ngày nhận:")]
        public DateTime? NGAY_NHAN { get; set; }

        [StringLength(200)]
        [DisplayName("File đính kèm:")]
        public string FILE_DINH_KEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BUTPHE> BUTPHEs { get; set; }

        public virtual LOAIVANBAN LOAIVANBAN { get; set; }

        public virtual NOI_PHAT_HANH NOI_PHAT_HANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VANBAN_NHANVIEN> VANBAN_NHANVIEN { get; set; }
    }
}
