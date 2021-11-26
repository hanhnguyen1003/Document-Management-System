using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Models.ViewModel
{
   public class VB_Loai_NoiPhatHanh
    {
        public decimal id { get; set; }

        public string sovanban { get; set; }
        public string noiphathanh { get; set; }
        public string loaivanban { get; set;}
        public string trichyeu { get; set; }
        public string nguoiky { get; set; }
        public DateTime ngayky { get; set; }
        public string filedinhkem { get; set; }
        
       
        public List<VANBAN> VANBANs { get; set; }

        


    }

    
}
