using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class NoiPhatHanhDAO
    {
        VBDbContext db = null;
        public NoiPhatHanhDAO()
        {
            db = new VBDbContext();
        }
        public List<NOI_PHAT_HANH> ListAll()
        {
            return db.NOI_PHAT_HANH.ToList();
        }
    }
}
