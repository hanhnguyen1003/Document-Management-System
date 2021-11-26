using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class ButPheDAO
    {
        private VBDbContext vb = null;
        public ButPheDAO()
        {
            vb = new VBDbContext();
        }
        public decimal Insert(BUTPHE entity)

        {
            vb.BUTPHEs.Add(entity);
            vb.SaveChanges();

            return entity.ID_VAN_BAN;
        }

        public List<VBhasBP> ListBP(decimal vanbanID, decimal nhanvienID,decimal butpheNVID)
        {

            //var model = from a in vb.VANBANs
            //            join b in vb.BUTPHEs on a.ID_VAN_BAN equals b.ID_VAN_BAN

            //            join d in vb.NHANVIENs on a.ID_NHAN_VIEN equals d.ID_NHAN_VIEN
            //            select new VBhasBP()
            //            {
            //                ngayBP = b.THOI_GIAN_BD,
            //                nguoiBP = d.HO_TEN,
            //                noidungBP = b.NOI_DUNG_BUT_PHE,

            //            };
            //return model.ToList();
            return new List<VBhasBP>();
        }


        public List<BUTPHE> ListAll()
        {
            return vb.BUTPHEs.ToList();
        }



    }
}
