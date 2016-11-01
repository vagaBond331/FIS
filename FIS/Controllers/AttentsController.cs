using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIS.Models;

namespace FIS.Controllers
{
    public class AttentsController : Controller
    {
        private FISEntities db = new FISEntities();

        // GET: Attents
        public ActionResult Index()
        {
            return View(db.Attents.ToList());
        }

        // GET: Attents/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attent attent = db.Attents.Find(id);
            if (attent == null)
            {
                return HttpNotFound();
            }
            return View(attent);
        }

        // GET: Attents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "log_id,user_id,log_time,device_id,log_type,description")] Attent attent)
        {
            if (ModelState.IsValid)
            {
                db.Attents.Add(attent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attent);
        }

        // GET: Attents/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attent attent = db.Attents.Find(id);
            if (attent == null)
            {
                return HttpNotFound();
            }
            return View(attent);
        }

        // POST: Attents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "log_id,user_id,log_time,device_id,log_type,description")] Attent attent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attent);
        }

        // GET: Attents/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attent attent = db.Attents.Find(id);
            if (attent == null)
            {
                return HttpNotFound();
            }
            return View(attent);
        }

        // POST: Attents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Attent attent = db.Attents.Find(id);
            db.Attents.Remove(attent);
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
