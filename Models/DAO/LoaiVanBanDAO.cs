using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class LoaiVanBanDAO
    {
        VBDbContext db = null;
        public LoaiVanBanDAO()
        {
            db = new VBDbContext();
        }
        public List<LOAIVANBAN> ListAll()
        {
            return db.LOAIVANBANs.ToList();
        }
    }
}
