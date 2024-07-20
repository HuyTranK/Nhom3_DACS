using PagedList;
using Sneaker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sneaker.Controllers
{
    public class ManagerController : Controller
    {
        private DataYikesDataContext dbcontext;
        DataYikesDataContext db = new DataYikesDataContext();

        // Correctly define the constructor
        public ManagerController()
        {
            dbcontext = new DataYikesDataContext();
        }
        public ActionResult SanPham(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.SanPhams.ToList().OrderBy(n => n.MaSP).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ChiTietSanPham(int id)
        {
            SanPham SanPham = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            ViewBag.MaSP = SanPham.MaSP;
            if (SanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(SanPham);
        }
        public ActionResult XoaSanPham(int id)
        {
            SanPham SanPham = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            ViewBag.MaSP = SanPham.MaSP;
            if (SanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(SanPham);
        }
        [HttpPost, ActionName("XoaSanPham")]
        public ActionResult XacNhanXoa(int id)
        {
            SanPham SanPham = db.SanPhams.FirstOrDefault(n => n.MaSP == id);
            ViewBag.MaSP = SanPham.MaSP;
            if (SanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SanPhams.DeleteOnSubmit(SanPham);
            db.SubmitChanges();
            return RedirectToAction("SanPham");
        }
        public ActionResult SuaSanPham(int id)
        {
            SanPham SanPham = db.SanPhams.FirstOrDefault(n => n.MaSP == id);
            if (SanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaThuongHieu = new SelectList(db.ThuongHieus.ToList().OrderBy(n => n.TenThuongHieu), "MaThuongHieu", "TenThuongHieu", SanPham.MaThuongHieu);
            return View(SanPham);
        }
        [HttpPost]
        public ActionResult SuaSanPham(SanPham SanPham)
        {
            SanPham itemm = db.SanPhams.FirstOrDefault(n => n.MaSP == SanPham.MaSP);
            itemm.TenSP = SanPham.TenSP;
            itemm.GiaBan = SanPham.GiaBan;
            itemm.MoTa = SanPham.MoTa;
            db.SubmitChanges();
            return RedirectToAction("SanPham");
        }
        public ActionResult ThuongHieu(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.ThuongHieus.ToList().OrderBy(n => n.MaThuongHieu).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ThemThuongHieu()
        {
            return View();
        }
        public ActionResult SuaThuongHieu(int id)
        {
            ThuongHieu item = db.ThuongHieus.SingleOrDefault(n => n.MaThuongHieu == id);
            return View(item);
        }
        [HttpPost]
        public ActionResult SuaThuongHieu(ThuongHieu ThuongHieu)
        {
            ThuongHieu itemm = db.ThuongHieus.SingleOrDefault(n => n.MaThuongHieu == ThuongHieu.MaThuongHieu);
            itemm.TenThuongHieu = ThuongHieu.TenThuongHieu;
            db.SubmitChanges();
            return RedirectToAction("ThuongHieu");
        }
        public ActionResult ChiTietThuongHieu(int id)
        {
            ThuongHieu item = db.ThuongHieus.SingleOrDefault(n => n.MaThuongHieu == id);
            ViewBag.MaThuongHieu = item.MaThuongHieu;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(item);
        }
        public ActionResult XoaThuongHieu(int id)
        {
            ThuongHieu item = db.ThuongHieus.SingleOrDefault(n => n.MaThuongHieu == id);
            ViewBag.MaThuongHieu = item.MaThuongHieu;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(item);
        }
        [HttpPost, ActionName("XoaThuongHieu")]
        public ActionResult XacNhanXoa1(int id)
        {
            ThuongHieu item = db.ThuongHieus.SingleOrDefault(n => n.MaThuongHieu == id);
            ViewBag.MaThuongHieu = item.MaThuongHieu;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ThuongHieus.DeleteOnSubmit(item);
            db.SubmitChanges();
            return RedirectToAction("ThuongHieu");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemThuongHieu(ThuongHieu item)
        {
            db.ThuongHieus.InsertOnSubmit(item);
            db.SubmitChanges();
            return RedirectToAction("ThuongHieu");
        }
        public ActionResult KhachHang(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.KhachHangs.ToList().OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult XoaKH(int id)
        {
            KhachHang item = db.KhachHangs.SingleOrDefault(n => n.MaKH == id);
            ViewBag.MaKH = item.MaKH;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(item);
        }
        [HttpPost, ActionName("XoaKH")]
        public ActionResult XacNhanXoa2(int id)
        {
            KhachHang item = db.KhachHangs.SingleOrDefault(n => n.MaKH == id);
            ViewBag.MaKH = item.MaKH;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHangs.DeleteOnSubmit(item);
            db.SubmitChanges();
            return RedirectToAction("KhachHang");
        }
        public ActionResult ChiTietKH(int id)
        {
            KhachHang item = db.KhachHangs.SingleOrDefault(n => n.MaKH == id);
            ViewBag.MaKH = item.MaKH;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(item);
        }
        public ActionResult SuaKH(int id)
        {
            KhachHang item = db.KhachHangs.SingleOrDefault(n => n.MaKH == id);
            return View(item);
        }
        [HttpPost]
        public ActionResult SuaKH(KhachHang kh)
        {
            KhachHang itemm = db.KhachHangs.SingleOrDefault(n => n.MaKH == kh.MaKH);
            itemm.HoTen = kh.HoTen;
            itemm.TaiKhoan = kh.TaiKhoan;
            itemm.MatKhau = kh.MatKhau;
            itemm.Email = kh.Email;
            itemm.DiaChiKH = kh.DiaChiKH;
            itemm.DienThoaiKH = kh.DienThoaiKH;
            db.SubmitChanges();
            return RedirectToAction("KhachHang");
        }
        public ActionResult DonDatHang(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.DonDatHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SuaDDH(int id)
        {
            DonDatHang item = db.DonDatHangs.SingleOrDefault(n => n.MaDonHang == id);
            return View(item);
        }
        [HttpPost]
        public ActionResult SuaDDH(DonDatHang ddh)
        {
            DonDatHang itemm = db.DonDatHangs.SingleOrDefault(n => n.MaDonHang == ddh.MaDonHang);
            db.SubmitChanges();
            return RedirectToAction("DonDatHang");
        }
        public ActionResult ChiTietDH(int id)
        {
            ChiTietDatHang item = db.ChiTietDatHangs.FirstOrDefault(n => n.MaDonHang == id);
            ViewBag.MaDonHang = item.MaDonHang;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(item);
        }
        public ActionResult XoaDDH(int id)
        {
            DonDatHang item = db.DonDatHangs.SingleOrDefault(n => n.MaDonHang == id);
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(item);
        }

        [HttpPost, ActionName("XoaDDH")]
        public ActionResult XacNhanXoa3(int id)
        {
            DonDatHang item = db.DonDatHangs.SingleOrDefault(n => n.MaDonHang == id);
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DonDatHangs.DeleteOnSubmit(item);
            db.SubmitChanges();
            return RedirectToAction("DonDatHang");
        }
        [HttpGet]
        public ActionResult ThemSanPham()
        {
            ViewBag.ThuongHieuList = new SelectList(dbcontext.ThuongHieus, "MaThuongHieu", "TenThuongHieu");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSanPham(SanPham model, HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                if (fileupload != null && fileupload.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileupload.FileName);
                    string directoryPath = Server.MapPath("~/Assets/Images/Products");

                    // Ensure the directory exists
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string filePath = Path.Combine(directoryPath, fileName);
                    fileupload.SaveAs(filePath);

                    model.AnhDD =  fileName;
                }

                dbcontext.SanPhams.InsertOnSubmit(model);
                dbcontext.SubmitChanges();

                return RedirectToAction("Index", "Manager");
            }

            ViewBag.ThuongHieuList = new SelectList(dbcontext.ThuongHieus, "MaThuongHieu", "TenThuongHieu");
            return View(model);
        }

        // GET: Manager
        public ActionResult Index()
        {
            //if (Session["Quyen"] == null && Session["TaiKhoan"]==null)
            //{
            //    return RedirectToAction("Login", "Member");
            //}
            if(Session["Quyen"] != null && Session["TaiKhoan"] != null)
            {
                if (Session["Quyen"].ToString() == "Admin" || Session["Quyen"].ToString() == "Manager")
                    return View();
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Member");
            }
        }
    }
}