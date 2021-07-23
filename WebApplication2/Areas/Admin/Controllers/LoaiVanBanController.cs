using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.EF;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class LoaiVanBanController : Controller
    {
        // GET: Admin/LoaiVanBan
        public ActionResult Index()
        {
            var iplLoaiVanBan = new LoaiVanBanModel();
            var model = iplLoaiVanBan.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Create(LOAIVANBAN collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var model = new LoaiVanBanModel();
                    int res = model.Create(collection.ID_LOAI_VAN_BAN,collection.MA_LOAI_VAN_BAN, collection.TEN_LOAI_VAN_BAN);
                    if(res>0)
                    return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "~~~~~~");
                    }
                }
                return View(collection);

            }
            catch
            {
                return View();
            }

          
        }


    }
}