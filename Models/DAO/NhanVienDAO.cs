using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class NhanVienDAO
    {
        VBDbContext db = null;
        public NhanVienDAO()
        {
            db = new VBDbContext();
        }
        public List<NHANVIEN> ListAll()
        {
            return db.NHANVIENs.ToList();
        }
      
    }
}
