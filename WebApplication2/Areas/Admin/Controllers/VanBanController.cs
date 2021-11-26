using Models;
using Models.DAO;
using Models.EF;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Areas.Admin.Models;


namespace WebApplication2.Areas.Admin.Controllers
{

    public class VanBanController : BaseController
    {
        private VBDbContext vb = new VBDbContext();
        public decimal loaiID;
        public decimal phathanhID;

        public string searchstring;


        // GET: Admin/VanBan
        public ActionResult Index()
        {

            var model = app.VanBanDAO.ListbyNoiPhatHanhandLoaiVanBan(loaiID, phathanhID);

            return View(model.ToList());

        }



        public ActionResult ViewDetails(decimal id = 0)
        {
            ViewBag.idvanban = id;
            VANBAN vanban = vb.VANBANs.Find(id);
            ViewBag.DonVis = app.DonViDAO.ListAll();
            ViewBag.NhanViens = app.NhanVienDAO.ListAll();
            return View(vanban);
        }
        public ActionResult GetNhanVien()
        {
            //return Json("hello");
            return Json(app.NhanVien.GetNhanVien(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]

        public ActionResult Create()
        {
            SetViewBag();
            ViewBag.DonVis = app.DonViDAO.ListAll();
            ViewBag.NhanViens = app.NhanVienDAO.ListAll();
            return View();
        }

        [HttpPost]
        public ActionResult GetNhanVienByDonVi(decimal id)
        {
            //if (!string.IsNullOrWhiteSpace(iddonvi.ToString()) && iddonvi.ToString().Length == 3)
            //{
            //    var repo = new NhanVienRepository();

            //    IEnumerable<SelectListItem> nhanviens = repo.GetNhanVien1(iddonvi);
            //    return Json(nhanviens, JsonRequestBehavior.AllowGet);
            //}
            //return null;
            return Json(app.NhanVien.GetNhanVien1(id));
        }
        [HttpPost]
        public ActionResult AddButPhe(BUTPHE obj,string trangthai)
        {
            return Json(app.ButPhe.AddButPhe(obj,trangthai));
        }
        [HttpPost]
        public ActionResult GetNhanVienByIdButPhe(decimal id)
        {
            return Json(app.ButPhe.GetNhanVienByIdButPhe(id));
        }
        // [HttpPost]
        //public ActionResult GetNhanVienByDonVi(decimal id)
        //{
        //    return Json(donvi.GetNhanVienByDonVi(id));
        //}


        [HttpPost]
        public ActionResult AddNhanVien(List<NHANVIENBUTPHE> objs)
        {
            List<int> result = new List<int>();
            if (objs.Count > 0)
            {
                foreach (var obj in objs)
                {
                    result.Add(app.ButPhe.AddNhanVien(obj));
                }
            }
           
            return Json(result);
        }

        [HttpPost]
        public ActionResult Create(VanBanCreateDto vanban)
        {
            if (ModelState.IsValid)
            {
                new VanBanDAO().Insert(vanban);
                //var dao = new VanBanDAO();
                //decimal id = dao.Insert(vanban);
                if (vanban != null)
                {
                    return RedirectToAction("Index", "VanBan");
                }
                else
                {
                    ModelState.AddModelError("", "Them moi khong thanh cong");
                }

            }

            SetViewBag();
            return View(vanban);
        }


        [HttpGet]
        public ActionResult Edit(decimal id)
        {
            SetViewBag();
            //ViewBag.NhanViens =app.NhanVienDAO.ListAll();
            ViewBag.NhanViens = app.NhanVien.GetNhanVienAllExceptNhanVienVanBan(id);
            ViewBag.NhanVienVanBan = app.NhanVien.GetNhanVienByVanBan(id);
            ViewBag.DonVis = app.DonViDAO.ListAll();
            var vanban = app.VanBanDAO.detail(id);
            return View(vanban);
        }
        [HttpPost]
        public ActionResult ChangeDanhSachDinhKem(decimal idvanban, string danhsachdinhkem)
        {
            return Json(app.VanBan.ChangeDanhSachDinhKem(idvanban, danhsachdinhkem));
        }
        [HttpPost]
        public ActionResult DeleteVanBan(decimal idvanban, string filedinhkem)
        {
            if (filedinhkem.Length > 0)
            {
                string[] s = filedinhkem.Split(',');
                if (s.Length > 0)
                {
                    foreach (var id in s)
                    {
                        var path = Path.Combine(Server.MapPath("~/UploadFileTest/"), id);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    }
                }
            }
            return Json(app.VanBan.DeleteVanBan(idvanban));
        }
        [HttpPost]

        public ActionResult Edit(VanBanCreateDto vanban)
        {
            return Json(app.VanBan.Edit(vanban));
        }

        public List<VANBAN> ListAll()
        {
            return vb.VANBANs.ToList();
        }



        public JsonResult LoadNV(decimal id)
        {
            var nv = vb.NHANVIENs.Where(z => z.ID_DON_VI == id).ToList();
            return Json(new SelectList(nv, "ID_NHAN_VIEN", "HO_TEN"));

        }


        public void SetViewBag(decimal? selectedId = null)
        {

            ViewBag.ID_LOAI_VAN_BAN = new SelectList(app.LoaiVanBanDAO.ListAll(), "ID_LOAI_VAN_BAN", "TEN_LOAI_VAN_BAN", selectedId);
            ViewBag.ID_NOI_PHAT_HANH = new SelectList(app.NoiPhatHanhDAO.ListAll(), "ID_NOI_PHAT_HANH", "TEN_NOI_PHAT_HANH", selectedId);
            ViewBag.ID_NHAN_VIEN = new SelectList(app.NhanVienDAO.ListAll(), "ID_NHAN_VIEN", "HO_TEN", selectedId);
            ViewBag.ID_DON_VI = new SelectList(app.DonViDAO.ListAll(), "ID_DON_VI", "TEN_DON_VI");

        }
        [HttpPost]
        //public ActionResult Upload(List<string> ls)
        //{

        //}

        public ActionResult UploadFiles(HttpPostedFileBase[] files)
        {
            int re = 0;
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadFile/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        re++;
                        //ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }
                }
            }
            return Json(re);
        }
        [HttpPost]
        public ActionResult UpLoadFile(string id)
        {

            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var stream = fileContent.InputStream;
                        var fileName = Path.GetFileName(file);
                        var path = Path.Combine(Server.MapPath("~/UploadFileTest/"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
                return Json(1);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(0);

            }
        }
        [HttpPost]
        public ActionResult RemoveFile(string id)
        {
            var path = Path.Combine(Server.MapPath("~/UploadFileTest/"), id);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return Json(1);
            }
            return Json(0);
        }
        [HttpPost]
        public ActionResult RemoveFiles(List<string> ids)
        {
            List<string> r = new List<string>();
            if (ids.Count > 0)
            {
                foreach (var id in ids)
                {
                    var path = Path.Combine(Server.MapPath("~/UploadFileTest/"), id);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                        r.Add("1");
                    }
                }

            }

            return Json(r);
        }
        public ActionResult ThayDoiTrangThaiVanBan(decimal idvanban, string trangthai)
        {
            return Json(app.VanBan.ChangeStatusVanBan(idvanban, trangthai));
        }
    }
}