namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIENBUTPHE")]
    public partial class NHANVIENBUTPHE
    {
        [Key]
        [Column(Order = 0)]
        public decimal ID_NHAN_VIEN { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal ID_BUT_PHE { get; set; }

        [StringLength(50)]
        public string chitietbp { get; set; }

        public virtual BUTPHE BUTPHE { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
