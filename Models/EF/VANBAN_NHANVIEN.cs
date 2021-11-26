namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VANBAN_NHANVIEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal VANBAN_NHANVIEN_Id { get; set; }

        public decimal? ID_VAN_BAN { get; set; }

        public decimal? ID_NHAN_VIEN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual VANBAN VANBAN { get; set; }
    }
}
