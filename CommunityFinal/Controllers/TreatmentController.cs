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
    public class TreatmentController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /Treatment/
        public ActionResult Index()
        {
            var treatments = db.Treatments.Include(t => t.ADisease).Include(t => t.ADoctorEntry).Include(t => t.ADose).Include(t => t.AMeal).Include(t => t.AMedicine);
            return View(treatments.ToList());
        }

        // GET: /Treatment/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // GET: /Treatment/Create
        public ActionResult Create()
        {
            ViewBag.DiseaseId = new SelectList(db.Diseases, "DiseaseId", "Name");
            ViewBag.DoctorId = new SelectList(db.DoctorEntries, "DoctorId", "Name");
            ViewBag.DoseId = new SelectList(db.Doses, "DoseId", "Name");
            ViewBag.MealId = new SelectList(db.Meals, "MealId", "Name");
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name");
            return View();
        }

        // POST: /Treatment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TreatmentId,Observation,Date,DoctorId,DiseaseId,MedicineId,DoseId,MealId,Note")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Treatments.Add(treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiseaseId = new SelectList(db.Diseases, "DiseaseId", "Name", treatment.DiseaseId);
            ViewBag.DoctorId = new SelectList(db.DoctorEntries, "DoctorId", "Name", treatment.DoctorId);
            ViewBag.DoseId = new SelectList(db.Doses, "DoseId", "Name", treatment.DoseId);
            ViewBag.MealId = new SelectList(db.Meals, "MealId", "Name", treatment.MealId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", treatment.MedicineId);
            return View(treatment);
        }

        // GET: /Treatment/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiseaseId = new SelectList(db.Diseases, "DiseaseId", "Name", treatment.DiseaseId);
            ViewBag.DoctorId = new SelectList(db.DoctorEntries, "DoctorId", "Name", treatment.DoctorId);
            ViewBag.DoseId = new SelectList(db.Doses, "DoseId", "Name", treatment.DoseId);
            ViewBag.MealId = new SelectList(db.Meals, "MealId", "Name", treatment.MealId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", treatment.MedicineId);
            return View(treatment);
        }

        // POST: /Treatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TreatmentId,Observation,Date,DoctorId,DiseaseId,MedicineId,DoseId,MealId,Note")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiseaseId = new SelectList(db.Diseases, "DiseaseId", "Name", treatment.DiseaseId);
            ViewBag.DoctorId = new SelectList(db.DoctorEntries, "DoctorId", "Name", treatment.DoctorId);
            ViewBag.DoseId = new SelectList(db.Doses, "DoseId", "Name", treatment.DoseId);
            ViewBag.MealId = new SelectList(db.Meals, "MealId", "Name", treatment.MealId);
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", treatment.MedicineId);
            return View(treatment);
        }

        // GET: /Treatment/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            return View(treatment);
        }

        // POST: /Treatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Treatment treatment = db.Treatments.Find(id);
            db.Treatments.Remove(treatment);
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
