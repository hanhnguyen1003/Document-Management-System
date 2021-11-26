using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class VanBanCreateDto
    {
        [DisplayName("Mã văn bản:")]
        public decimal ID_VAN_BAN { get; set; }
        [DisplayName("Nơi phát hành:")]
        public decimal ID_NOI_PHAT_HANH { get; set; }
        [DisplayName("Loại văn bản:")]
        public decimal? ID_LOAI_VAN_BAN { get; set; }
        [DisplayName("Số văn bản:")]
        public string SO_VAN_BAN { get; set; }
        [DisplayName("Trích yếu:")]
        public string TRICH_YEU { get; set; }
        [DisplayName("Người ký:")]
        public string NGUOI_KY { get; set; }
        [DisplayName("Ngày ký:")]
        public DateTime NGAY_KY { get; set; }
        [DisplayName("Trạng thái xử lý:")]
        public string TRANG_THAI_XU_LY { get; set; }
        [DisplayName("Ngày gởi:")]
        public DateTime? NGAY_GOI { get; set; }
        [DisplayName("Ngày nhận:")]
        public DateTime? NGAY_NHAN { get; set; }
        [DisplayName("File đính kèm:")]
        public string FILE_DINH_KEM { get; set; }
        public string noiphathanh { get; set; }
        public string loaivanban { get; set; }
        public decimal idBP { get; set; }
        public string noidungBP { get; set; }
        public List<decimal> NhanVienIds { get; set; }
        public List<VANBAN> VANBANs { get; set; }
    }
}
