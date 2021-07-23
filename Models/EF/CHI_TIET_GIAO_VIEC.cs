namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHI_TIET_GIAO_VIEC
    {
        [Key]
        public decimal ID_CHI_TIET { get; set; }

        public decimal ID_NHAN_VIEN { get; set; }

        public decimal ID_CONG_VIEC { get; set; }

        public DateTime NGAY_BAT_DAU { get; set; }

        public DateTime NGAY_HET_HAN { get; set; }

        public float TY_LE_HOAN_THANH { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual CONGVIEC CONGVIEC { get; set; }
    }
}
