using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class VBhasBP
    {
        public decimal vanbanID { get; set; }
        public string  nguoiBP { get; set; }
        public string  tenDV { get; set; }
        public DateTime? ngayBP { get; set; }
        public string  noidungBP { get; set; } 
        public List<BUTPHE> BUTPHEs { get; set; }

    }
}
