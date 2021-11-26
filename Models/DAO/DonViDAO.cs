using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DonViDAO
    {
        VBDbContext db = null;
        public DonViDAO()
        {
            db = new VBDbContext();
        }
        public List<DONVI> ListAll()
        {
            return db.DONVIs.ToList();
        }
    }
}
