using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class ButPheController : Controller
    {
        private VBDbContext db = new VBDbContext();
        private decimal vbID;
        private decimal nvID;
        private decimal nvBPid;

        // GET: Admin/ButPhe
        public ActionResult Index()
        {
            var model = new ButPheDAO().ListBP(vbID,nvID,nvBPid);

            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]

        public ActionResult Create(BUTPHE butphe)
        {
            if (ModelState.IsValid)
            {

                var dao = new ButPheDAO();
                decimal id = dao.Insert(butphe);
                if (id > 0)
                {
                    return RedirectToAction("Index", "ButPhe");
                }
                else
                {
                    ModelState.AddModelError("", "Them moi khong thanh cong");
                }

            }
            SetViewBag();
            return View();
        }

        public void SetViewBag(decimal? selectedId = null)
        {
            var dao = new VanBanDAO();
            

            ViewBag.ID_VAN_BAN = new SelectList(dao.ListAll(), "ID_VAN_BAN", "SO_VAN_BAN", selectedId);
            
        }


    }
}