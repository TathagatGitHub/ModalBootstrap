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
    public class TreatmentItemsController : Controller
    {
        private eChartContext db = new eChartContext();

        // GET: TreatmentItems
        public ActionResult Index()
        {
            var treatmentItems = db.TreatmentItems.Include(t => t.Treatment);
            return View(treatmentItems.ToList());
        }

        public ActionResult IndexAjaxFromTreatmentList(int id)
        {
            List<TreatmentItems> treatmentItems = new List<TreatmentItems>();
            treatmentItems = db.TreatmentItems.Where(t => t.TreatmentNo == id).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_indexTreatmentListPartial", treatmentItems);
            }
            else
                return View("Index", treatmentItems.ToList());
        }



        public ActionResult IndexAjax()
        {
            var treatmentItems = db.TreatmentItems.Include(t => t.Treatment);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_indexTreatmentListPartial");
            }
            else
                return View(treatmentItems.ToList());
        }

        

        
        [ValidateAntiForgeryToken]
        public ActionResult CreateIndexTreatmentsItems([Bind(Include = "TreatmentItemsNo,TreatmentNo,LOC,SURF,PROC,ProcedureDescription,DOS,DDS,COMP")] TreatmentItems treatmentItems)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentItems.Add(treatmentItems);
                db.SaveChanges();
              
                var treatmentItemsList = db.TreatmentItems.Where(t => t.TreatmentNo == treatmentItems.TreatmentNo);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_indexTreatmentListPartial", treatmentItemsList.ToList());
                }
                else
                    return View(treatmentItemsList.ToList());
            }

            ViewBag.TreatmentNo = new SelectList(db.Treatments, "TreatmentNo", "TreatmentStatus", treatmentItems.TreatmentNo);
            return View(treatmentItems);
        }
        // GET: TreatmentItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentItems treatmentItems = db.TreatmentItems.Find(id);
            if (treatmentItems == null)
            {
                return HttpNotFound();
            }
            return View(treatmentItems);
        }

        // GET: TreatmentItems/Create
        public ActionResult Create()
        {
            ViewBag.TreatmentNo = new SelectList(db.Treatments, "TreatmentNo", "TreatmentStatus");
            return View();
        }
        // GET: TreatmentItems/Create
        public ActionResult CreateAjax()
        {
            ViewBag.TreatmentNo = new SelectList(db.Treatments, "TreatmentNo", "TreatmentNo");
            if (Request.IsAjaxRequest())
            {
                return PartialView("_createTreatmentItemPartial");
            }
            else
                return PartialView("_createTreatmentItemPartial");
            
        }
        // POST: TreatmentItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentItemsNo,TreatmentNo,LOC,SURF,PROC,ProcedureDescription,DOS,DDS,COMP")] TreatmentItems treatmentItems)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentItems.Add(treatmentItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TreatmentNo = new SelectList(db.Treatments, "TreatmentNo", "TreatmentStatus", treatmentItems.TreatmentNo);
            return View(treatmentItems);
        }

        // GET: TreatmentItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentItems treatmentItems = db.TreatmentItems.Find(id);
            if (treatmentItems == null)
            {
                return HttpNotFound();
            }
            ViewBag.TreatmentNo = new SelectList(db.Treatments, "TreatmentNo", "TreatmentStatus", treatmentItems.TreatmentNo);
            return View(treatmentItems);
        }

        // POST: TreatmentItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentItemsNo,TreatmentNo,LOC,SURF,PROC,ProcedureDescription,DOS,DDS,COMP")] TreatmentItems treatmentItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TreatmentNo = new SelectList(db.Treatments, "TreatmentNo", "TreatmentStatus", treatmentItems.TreatmentNo);
            return View(treatmentItems);
        }

        // GET: TreatmentItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentItems treatmentItems = db.TreatmentItems.Find(id);
            if (treatmentItems == null)
            {
                return HttpNotFound();
            }
            return View(treatmentItems);
        }

        // POST: TreatmentItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreatmentItems treatmentItems = db.TreatmentItems.Find(id);
            db.TreatmentItems.Remove(treatmentItems);
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
