using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModalBootstrap.Models;

namespace ModalBootstrap.Controllers
{
    public class TreatmentController : Controller
    {
        private eChartContext db = new eChartContext();

        // GET: /Treatment/
        public ActionResult Index()
        {
            var treatments = db.Treatments.Include(t => t.eChart);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_indexTreatmentsPartial", treatments.ToList());
            }
            else
              return View(treatments.ToList());
        }

        public ActionResult CreateIndexTreatments([Bind(Include="TreatmentNo,TreatmentStatus,InitialVisit,LastVisit,NextVisit,ChartNo")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Treatments.Add(treatment);
                db.SaveChanges();
                var treatments = db.Treatments.Where(t => t.ChartNo == treatment.ChartNo);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_indexTreatmentsPartial", treatments.ToList());
                }
                else
                    return View(treatments.ToList());
            }

            ViewBag.ChartNo = new SelectList(db.eCharts, "ChartNo", "PatientFirstName", treatment.ChartNo);
           // return View(treatment);
            return PartialView("_createTreatmentPartial", treatment);
           
        }

        // GET: /Treatment/Details/5
        public ActionResult Details(int? id)
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
           
           // List<SelectListItem> item = new SelectList(db.eCharts, "ChartNo");
            ViewBag.ChartNo = new SelectList(db.eCharts, "ChartNo", "PatientFirstName");
             if (Request.IsAjaxRequest())
            {
                return PartialView("_createTreatmentPartial");
            }
            else

                 return PartialView("_createTreatmentPartial");

            // Date 6/5/2015 working
            /*
            List<eChart> list = new List<eChart>();
            list.Add(new eChart() { ChartNo = 2 });
            list.Add(new eChart() { ChartNo = 3 });
            ViewData["ChartNo"] = new SelectList(list, "ChartNo", "ChartNo");
            return PartialView("_createTreatmentPartial");
             * */
            // Date 6/5/2015 working

        }

        // POST: /Treatment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TreatmentNo,TreatmentStatus,InitialVisit,LastVisit,NextVisit,ChartNo")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Treatments.Add(treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChartNo = new SelectList(db.eCharts, "ChartNo", "PatientFirstName", treatment.ChartNo);
           // return View(treatment);
            return PartialView("_createTreatmentPartial", treatment);
        }

        // GET: /Treatment/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ChartNo = new SelectList(db.eCharts, "ChartNo", "PatientFirstName", treatment.ChartNo);
            return View(treatment);
        }
        // GET: /Treatment/Edit/5
        public ActionResult AjaxEdit(int? id)
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
            ViewBag.ChartNo = new SelectList(db.eCharts, "ChartNo", "PatientFirstName", treatment.ChartNo);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_createTreatmentPartial");
            }
            else
                return View(treatment);
        }
        // POST: /Treatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TreatmentNo,TreatmentStatus,InitialVisit,LastVisit,NextVisit,ChartNo")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChartNo = new SelectList(db.eCharts, "ChartNo", "PatientFirstName", treatment.ChartNo);
            return View(treatment);
        }

        // GET: /Treatment/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
