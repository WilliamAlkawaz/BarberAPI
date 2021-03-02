using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarberAdmin.Models;

namespace BarberAdmin.Controllers
{
    public class BarbersController : Controller
    {
        private BarberAdminDB db = new BarberAdminDB();

        // GET: Barbers
        public ActionResult Index()
        {
            return View(db.Barbers.ToList());
        }

        // GET: Barbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // GET: Barbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarberID,Name,PhotoFile,About")] Barber barber, HttpPostedFileBase image, string sun, string mon, string tue, string wed, string thur, string fri, string sat)
        {
            List<string> Days = new List<string>(); 
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    barber.ImageMimeType = image.ContentType;
                    barber.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(barber.PhotoFile, 0, image.ContentLength);
                }
                if(sun != null)
                {
                    Days.Add(sun); 
                }
                if (mon != null)
                {
                    Days.Add(mon);
                }
                if (tue != null)
                {
                    Days.Add(tue);
                }
                if (wed != null)
                {
                    Days.Add(wed);
                }
                if (thur != null)
                {
                    Days.Add(thur);
                }
                if (fri != null)
                {
                    Days.Add(fri);
                }
                if (sat != null)
                {
                    Days.Add(sat);
                }
                foreach(var day in Days)
                {
                    db.Days.Add(new Day { Barber = barber, day = day }); 
                }

                db.Barbers.Add(barber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barber);
        }

        // GET: Barbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // POST: Barbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarberID,Name,PhotoFile,About")] Barber barber, HttpPostedFileBase image, string sun, string mon, string tue, string wed, string thur, string fri, string sat)
        {
            List<string> Days = new List<string>(); 
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    barber.ImageMimeType = image.ContentType;
                    barber.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(barber.PhotoFile, 0, image.ContentLength);
                }
                if (sun != null)
                {
                    Days.Add(sun);
                }
                if (mon != null)
                {
                    Days.Add(mon);
                }
                if (tue != null)
                {
                    Days.Add(tue);
                }
                if (wed != null)
                {
                    Days.Add(wed);
                }
                if (thur != null)
                {
                    Days.Add(thur);
                }
                if (fri != null)
                {
                    Days.Add(fri);
                }
                if (sat != null)
                {
                    Days.Add(sat);
                }
                var DDays = db.Days.Where(x => x.Barber.BarberID == barber.BarberID);
                foreach(var item in DDays)
                {
                    db.Days.Remove(item);
                }
                foreach (var day in Days)
                {
                    db.Days.Add(new Day { Barber = barber, day = day });
                }
                db.Entry(barber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barber);
        }

        // GET: Barbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barber barber = db.Barbers.Find(id);
            db.Barbers.Remove(barber);
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
        public FileContentResult GetImage(int id)
        {
            Barber barber = db.Barbers.Find(id);
            if (barber != null)
            {
                return File(barber.PhotoFile, barber.ImageMimeType); 
            }
            else
            {
                return null; 
            }
        }
    }
}
