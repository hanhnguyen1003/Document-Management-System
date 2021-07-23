namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRANGTHAICONGVIEC")]
    public partial class TRANGTHAICONGVIEC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANGTHAICONGVIEC()
        {
            CONGVIECs = new HashSet<CONGVIEC>();
        }

        [Key]
        public decimal ID_TRANG_THAI { get; set; }

        [StringLength(200)]
        public string TEN_TRANG_THAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGVIEC> CONGVIECs { get; set; }
    }
}
