using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class NHANVIENBUTPHEDAO
    {
        VBDbContext db = null;
        public NHANVIENBUTPHEDAO()
        {
            db = new VBDbContext();
        }
        public List<NHANVIENBUTPHE> ListAll()
        {
            return db.NHANVIENBUTPHEs.ToList();
        }


        public decimal Insert(NHANVIENBUTPHE entity)

        {
            db.NHANVIENBUTPHEs.Add(entity);
            db.SaveChanges();

            return entity.ID_BUT_PHE;
        }
    }
}
