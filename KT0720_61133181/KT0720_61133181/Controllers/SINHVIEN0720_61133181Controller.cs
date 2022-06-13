using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT0720_61133181.Models;

namespace KT0720_61133181.Controllers
{
    public class SINHVIEN0720_61133181Controller : Controller
    {
        private KT0720_61133181Entities db = new KT0720_61133181Entities();
        string LayMaNV()
        {
            var maMax = db.SINHVIENs.ToList().Select(n => n.MaSV).Max();
            int maSV = int.Parse(maMax.Substring(2)) + 1;
            string SV = String.Concat("000", maSV.ToString());
            return "SV" + SV.Substring(maSV.ToString().Length - 1);
        }
        public ActionResult TimKiem_61133181()
        {
            var sinhViens = db.SINHVIENs.Include(n => n.LOP);
            return View(sinhViens.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem_61133181(string maSV)
        {

            //var nhanViens = db.NhanViens.SqlQuery("exec NhanVien_DS '"+maNV+"' ");
            var sinhViens = db.SINHVIENs.SqlQuery("SELECT * FROM SINHVIEN WHERE MaSV='" + maSV + "'");
            //var sinhViens = db.SINHVIENs.Where(abc =>abc.MaSV==maSV);
            return View(sinhViens.ToList());
        }
        [HttpGet]


        // GET: SINHVIEN0720_61133181
        public ActionResult Index()
        {
            var sINHVIENs = db.SINHVIENs.Include(s => s.LOP);
            return View(sINHVIENs.ToList());
        }

        // GET: SINHVIEN0720_61133181/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // GET: SINHVIEN0720_61133181/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop");
            return View();
        }

        // POST: SINHVIEN0720_61133181/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.SINHVIENs.Add(sINHVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", sINHVIEN.MaLop);
            return View(sINHVIEN);
        }

        // GET: SINHVIEN0720_61133181/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", sINHVIEN.MaLop);
            return View(sINHVIEN);
        }

        // POST: SINHVIEN0720_61133181/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sINHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.LOPs, "MaLop", "TenLop", sINHVIEN.MaLop);
            return View(sINHVIEN);
        }

        // GET: SINHVIEN0720_61133181/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // POST: SINHVIEN0720_61133181/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            db.SINHVIENs.Remove(sINHVIEN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
