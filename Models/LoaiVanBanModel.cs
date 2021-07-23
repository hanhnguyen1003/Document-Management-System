using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class LoaiVanBanModel
    {
        private VBDbContext context = null;
        public LoaiVanBanModel()
        {
            context = new VBDbContext();
        }
        public List<LOAIVANBAN> ListAll()
        {
            var list = context.Database.SqlQuery<LOAIVANBAN>("Sp_LoaiVanBan_ListAll").ToList();
            return list;
        }  
        public int Create(decimal id, string maloai, string tenloai)

        {
            object[] parameters = 
            {
                  new SqlParameter("@ID_LOAI_VAN_BAN",id),
                new SqlParameter("@MA_LOAI_VAN_BAN",maloai),
                 new SqlParameter("@TEN_LOAI_VAN_BAN",tenloai)

            };
            int res = context.Database.ExecuteSqlCommand("Sp_LoaiVanBan_Insert @ID_LOAI_VAN_BAN,@MA_LOAI_VAN_BAN,@TEN_LOAI_VAN_BAN", parameters);
               return res;
        }

       
    }
}
