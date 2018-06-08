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
    public class eChartController : Controller
    {
        private eChartContext db = new eChartContext();
        private eChartService eChartService = new eChartService();
        // GET: /eChart/
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
             //   return PartialView("_listAllChartPartial", db.eCharts.ToList());
                return PartialView("_listAllChartPartial", eChartService.Index());
            }

            return View(db.eCharts.ToList());
        }

        // GET: /eChart/
        public ActionResult SearchAjax(eChart chart)
        {
            List <eChart> charts = new List<eChart>();
            charts = db.eCharts.Where(c => c.ChartNo == chart.ChartNo).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_searcheChartListResult", charts);
            }

            return View("Details", charts);
                        
        }
        public ActionResult eChartHome()
        {
            ViewBag.Message = "Find a Chart!";
           
           return View();
        }

        // GET: /eChart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eChart echart = db.eCharts.Find(id);
            if (echart == null)
            {
                return HttpNotFound();
            }
            return View(echart);
        }
       

        // GET: /eChart/Details/5
        public ActionResult TabDetails(int? id)
        {
            eChartViewModel chartViewModel = new eChartViewModel();//new line
            List<Treatment> treatments = new List<Treatment>();//new line
            List<TreatmentItems> treatmentitems = new List<TreatmentItems>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eChart echart = db.eCharts.Find(id);
            if (echart == null)
            {
                return HttpNotFound();
            }
            chartViewModel.chart = echart;// new line
         
            treatments = db.Treatments.Where(chartno => chartno.ChartNo == id).ToList();//new line
            treatmentitems = db.TreatmentItems.Where(treatment => treatment.TreatmentNo == id).ToList();//new line

            chartViewModel.treatments = treatments;//new line
            chartViewModel.treatmentItems = treatmentitems;
            return View("eChartHomeNew", chartViewModel); // new line
            
           //old line before viewmode- return PartialView("_eChartDetailsPartial", echart);
            
        }

        // GET: /eChart/Create
        public ActionResult Create()
        {
            ViewBag.Message = "Create a new Chart!";
            return View();
        }

        // POST: /eChart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ChartNo,PatientFirstName,PatientLastName,PatientEmail,PatientPhoneNo,Sex,PatientBirthDate,AppointmentDate,PatientAddress")] eChart echart)
        {
            if (ModelState.IsValid)
            {
                db.eCharts.Add(echart);
                db.SaveChanges();
               // return RedirectToAction("Details", new { id = echart.ChartNo });
                return RedirectToAction("TabDetails", new { id = echart.ChartNo });
             //  return RedirectToAction("Index");
               // ViewData["chartlist"] = echart;
                //return RedirectToAction("eChartHome");
             //   return View("eChartHome", echart);
            }

            return View(echart);
        }

        // GET: /eChart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eChart echart = db.eCharts.Find(id);
            if (echart == null)
            {
                return HttpNotFound();
            }
            return View(echart);
        }

        // POST: /eChart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ChartNo,PatientFirstName,PatientLastName,PatientEmail,PatientPhoneNo,Sex,PatientBirthDate,AppointmentDate,PatientAddress")] eChart echart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(echart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(echart);
        }

        // GET: /eChart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eChart echart = db.eCharts.Find(id);
            if (echart == null)
            {
                return HttpNotFound();
            }
            return View(echart);
        }

        // POST: /eChart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eChart echart = db.eCharts.Find(id);
            db.eCharts.Remove(echart);
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
