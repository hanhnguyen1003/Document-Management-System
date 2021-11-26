using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class VBSearchController : Controller
    {
        private VBDbContext db=new VBDbContext();
        // GET: Admin/VBSearch
        public ActionResult Index(string searchstring,string searchby,DateTime? searchto,DateTime? searchfr,decimal noiphathanhID = 0,decimal loaivanbanID = 0)
        {
            
            var noiphathanh = from ph in db.NOI_PHAT_HANH select ph;
            var loaivanban = from l in db.LOAIVANBANs select l;
            ViewBag.noiphathanhID = new SelectList(noiphathanh, "ID_NOI_PHAT_HANH", "TEN_NOI_PHAT_HANH");
            ViewBag.loaivanbanID = new SelectList(loaivanban, "ID_LOAI_VAN_BAN", "TEN_LOAI_VAN_BAN");
           
            
  

            var vanban = db.VANBANs.ToList();

            if (!String.IsNullOrEmpty(searchstring))
            {
                vanban = vanban.Where(v => v.SO_VAN_BAN.Contains(searchstring)).ToList();

            }
            if (!String.IsNullOrEmpty(searchby))
            {
                vanban = vanban.Where(vtry => vtry.TRICH_YEU.Contains(searchby)).ToList();

            }
            if (!String.IsNullOrEmpty(searchto.ToString()) && !String.IsNullOrEmpty(searchfr.ToString()))
            {
              
                vanban = vanban.Where(t => t.NGAY_KY >= searchto && t.NGAY_KY <= searchfr).ToList();


            }
          
            if (noiphathanhID != 0)
            {
               
                vanban = db.VANBANs.Where(x => x.ID_NOI_PHAT_HANH == noiphathanhID).ToList();
               
            }
            
            if (loaivanbanID != 0)
            {
                vanban = vanban.Where(vbl => vbl.ID_LOAI_VAN_BAN == loaivanbanID).ToList();
            }
            return View(vanban);
        }
        public ActionResult ViewDetails(decimal id = 0)
        {

            VANBAN vanban = db.VANBANs.Find(id);

            return View(vanban);

        }



    }
}