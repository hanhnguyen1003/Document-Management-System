using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class VanBanDAO
    {
        private VBDbContext vb = null;
        public VanBanDAO()
        {
            vb = new VBDbContext();
        }
        public List<VanBanCreateDto> ListbyNoiPhatHanhandLoaiVanBan(decimal loaivanbanID, decimal noiphathanhID)
        {

            var model = from a in vb.VANBANs
                        join b in vb.NOI_PHAT_HANH on a.ID_NOI_PHAT_HANH equals b.ID_NOI_PHAT_HANH
                        join c in vb.LOAIVANBANs on a.ID_LOAI_VAN_BAN equals c.ID_LOAI_VAN_BAN
                        select new VanBanCreateDto()
                        {
                            ID_VAN_BAN = a.ID_VAN_BAN,
                            SO_VAN_BAN = a.SO_VAN_BAN,
                            noiphathanh = b.TEN_NOI_PHAT_HANH,
                            loaivanban = c.TEN_LOAI_VAN_BAN,
                            TRICH_YEU = a.TRICH_YEU,
                            NGAY_KY = a.NGAY_KY,
                            NGUOI_KY = a.NGUOI_KY,
                            FILE_DINH_KEM = a.FILE_DINH_KEM
                        };
            return model.ToList();
        }



        public decimal Insert(VanBanCreateDto vanban)
        {

            var van_ban = new VANBAN();
            van_ban.ID_LOAI_VAN_BAN = vanban.ID_LOAI_VAN_BAN;
            van_ban.ID_NOI_PHAT_HANH = vanban.ID_NOI_PHAT_HANH;
            van_ban.SO_VAN_BAN = vanban.SO_VAN_BAN;
            van_ban.NGAY_KY = vanban.NGAY_KY;
            van_ban.NGAY_NHAN = vanban.NGAY_NHAN;
            van_ban.NGAY_GOI = vanban.NGAY_GOI;
            van_ban.TRICH_YEU = vanban.TRICH_YEU;
            van_ban.TRANG_THAI_XU_LY = vanban.TRANG_THAI_XU_LY;
            van_ban.NGUOI_KY = vanban.NGUOI_KY;
            van_ban.ID_VAN_BAN = vanban.ID_VAN_BAN;
            van_ban.FILE_DINH_KEM = vanban.FILE_DINH_KEM;
            vb.VANBANs.Add(van_ban);
            vb.SaveChanges();
            List<VANBAN_NHANVIEN> vbnv = new List<VANBAN_NHANVIEN>();
            foreach (var item in vanban.NhanVienIds)
            {
                var NhanVien_VB = new VANBAN_NHANVIEN();
                NhanVien_VB.VANBAN_NHANVIEN_Id = CheckTrungId(new Random().Next(1, 20));
                NhanVien_VB.ID_NHAN_VIEN = item;
                NhanVien_VB.ID_VAN_BAN = vanban.ID_VAN_BAN;
                vbnv.Add(NhanVien_VB);
            }

            vb.VANBAN_NHANVIEN.AddRange(vbnv);
            vb.SaveChanges();

            return van_ban.ID_VAN_BAN;
        }

        public decimal Insert(BUTPHE entity)
        {
            vb.BUTPHEs.Add(entity);
            vb.SaveChanges();

            return entity.ID_VAN_BAN;
        }


        public decimal Edit(VanBanCreateDto vban)
        {
            
            var van_ban = vb.VANBANs.FirstOrDefault(n => n.ID_VAN_BAN == vban.ID_VAN_BAN);
            //var van_ban = vb.VANBANs.SingleOrDefault(n => n.ID_VAN_BAN == vban.ID_VAN_BAN);
            van_ban.ID_LOAI_VAN_BAN = vban.ID_LOAI_VAN_BAN;
            van_ban.ID_NOI_PHAT_HANH = vban.ID_NOI_PHAT_HANH;
            van_ban.SO_VAN_BAN = vban.SO_VAN_BAN;
            van_ban.NGAY_KY = vban.NGAY_KY;
            van_ban.NGAY_NHAN = vban.NGAY_NHAN;
            van_ban.NGAY_GOI = vban.NGAY_GOI;
            van_ban.TRICH_YEU = vban.TRICH_YEU;
            van_ban.TRANG_THAI_XU_LY = vban.TRANG_THAI_XU_LY;
            van_ban.NGUOI_KY = vban.NGUOI_KY;
            van_ban.FILE_DINH_KEM = vban.FILE_DINH_KEM;
                    
            vb.SaveChanges();

            var removed = vb.VANBAN_NHANVIEN.Where(n => n.ID_VAN_BAN == van_ban.ID_VAN_BAN);
            vb.VANBAN_NHANVIEN.RemoveRange(removed);

            List<VANBAN_NHANVIEN> vbnv = new List<VANBAN_NHANVIEN>();
            foreach (var item in vban.NhanVienIds)
            {
                var NhanVien_VB = new VANBAN_NHANVIEN();
                NhanVien_VB.VANBAN_NHANVIEN_Id = CheckTrungId(new Random().Next(1, 20));
                NhanVien_VB.ID_NHAN_VIEN = item;
                NhanVien_VB.ID_VAN_BAN = vban.ID_VAN_BAN;
                vbnv.Add(NhanVien_VB);
            }

            vb.VANBAN_NHANVIEN.AddRange(vbnv);
            vb.SaveChanges();

            return vban.ID_VAN_BAN;
        }

        public VANBAN detail(decimal id)
        {
            return vb.VANBANs.Find(id);
        }
        

        
        public List<VANBAN> ListAll()
        {
            return vb.VANBANs.ToList();
        }

        public List<NHANVIEN> ListCheck()
        {
            return vb.NHANVIENs.Where(x=>x.ID_NHAN_VIEN==-1).ToList();
        }
        private decimal CheckTrungId(decimal id)
        {
            var result = vb.VANBANs.Where(n => n.ID_VAN_BAN == id);
            if(result != null)
            {
                return (id + new Random().Next(1, 99));
            }
            else
            {
                return id;
            }
        }
    }
}