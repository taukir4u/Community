using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunityFinal.Models;

namespace CommunityFinal.Controllers
{
    public class CreateCenterController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /CreateCenter/
        public ActionResult Index()
        {
            var createcenters = db.CreateCenters.Include(c => c.ADistrict).Include(c => c.AUpazila);
            return View(createcenters.ToList());
        }

        // GET: /CreateCenter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateCenter createcenter = db.CreateCenters.Find(id);
            if (createcenter == null)
            {
                return HttpNotFound();
            }
            return View(createcenter);
        }

        // GET: /CreateCenter/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            ViewBag.UpazilaId = new SelectList(db.Upazilas, "Id", "Name");
            return View();
        }

        // POST: /CreateCenter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CenterId,Name,Code,Password,DistrictId,UpazilaId")] CreateCenter createcenter)
        {
            if (ModelState.IsValid)
            {
                db.CreateCenters.Add(createcenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", createcenter.DistrictId);
            ViewBag.UpazilaId = new SelectList(db.Upazilas, "Id", "Name", createcenter.UpazilaId);
            return View(createcenter);
        }

        // GET: /CreateCenter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateCenter createcenter = db.CreateCenters.Find(id);
            if (createcenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", createcenter.DistrictId);
            ViewBag.UpazilaId = new SelectList(db.Upazilas, "Id", "Name", createcenter.UpazilaId);
            return View(createcenter);
        }

        // POST: /CreateCenter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CenterId,Name,Code,Password,DistrictId,UpazilaId")] CreateCenter createcenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createcenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", createcenter.DistrictId);
            ViewBag.UpazilaId = new SelectList(db.Upazilas, "Id", "Name", createcenter.UpazilaId);
            return View(createcenter);
        }

        // GET: /CreateCenter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateCenter createcenter = db.CreateCenters.Find(id);
            if (createcenter == null)
            {
                return HttpNotFound();
            }
            return View(createcenter);
        }

        // POST: /CreateCenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateCenter createcenter = db.CreateCenters.Find(id);
            db.CreateCenters.Remove(createcenter);
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CreateCenter u)
        {
            if (ModelState.IsValid)
            {

                var v = db.CreateCenters.Where(a => a.Code.Equals(u.Code) && a.Password.Equals(u.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["LoggedCenterID"] = v.CenterId.ToString();
                    Session["LoggedName"] = v.Name;
                    return RedirectToAction("Index", "DoctorEntry");
                }
            }
            return View();
        }

        ////public ActionResult AfterLogin()
        ////{
        ////    if (Session["LoggedCenterID"] != null)
        ////    {
        ////        return View("Index", "DoctorEntry");
        ////    }
        ////    else
        ////    {
        ////        return RedirectToAction("Login");
        ////    }
        ////}
        public ActionResult Logout()
        {
            Session["LoggedCenterID"] = null;
            Session["LoggedName"] = null;
            return RedirectToAction("Login");


        }
    }
}
