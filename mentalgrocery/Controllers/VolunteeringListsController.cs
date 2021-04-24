using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mentalgrocery.Models;

namespace mentalgrocery.Controllers
{
    public class VolunteeringListsController : Controller
    {
        private webModels db = new webModels();

        // GET: VolunteeringLists
        /*public ActionResult Index()
        {
            return View(db.VolunteeringLists.ToList());
        }*/
        public ActionResult Index(int pageindex, int pagesize)
        {
            var user = db.VolunteeringLists.OrderBy(n => n.voId).Skip<VolunteeringList>(pagesize * (pageindex - 1)).Take<VolunteeringList>(10);
            int total = db.VolunteeringLists.Count();
            if(total%pagesize==0)
            {
                ViewBag.current = pageindex;
                ViewBag.TotalPage = total / pagesize;
            }
            else
            {
                ViewBag.current = pageindex;
                ViewBag.TotalPage = total / pagesize + 1;
            }
            return View(user);
        }

        // GET: VolunteeringLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteeringList volunteeringList = db.VolunteeringLists.Find(id);
            if (volunteeringList == null)
            {
                return HttpNotFound();
            }
            return View(volunteeringList);
        }

        // GET: VolunteeringLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VolunteeringLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "voId,groupId,voName,voAddress,voSuburb,vpPostCode,vpState,voLGA,voRegion,voPhone,voEmail,voWeb")] VolunteeringList volunteeringList)
        {
            if (ModelState.IsValid)
            {
                db.VolunteeringLists.Add(volunteeringList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteeringList);
        }

        // GET: VolunteeringLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteeringList volunteeringList = db.VolunteeringLists.Find(id);
            if (volunteeringList == null)
            {
                return HttpNotFound();
            }
            return View(volunteeringList);
        }

        // POST: VolunteeringLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "voId,groupId,voName,voAddress,voSuburb,vpPostCode,vpState,voLGA,voRegion,voPhone,voEmail,voWeb")] VolunteeringList volunteeringList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteeringList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteeringList);
        }

        // GET: VolunteeringLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteeringList volunteeringList = db.VolunteeringLists.Find(id);
            if (volunteeringList == null)
            {
                return HttpNotFound();
            }
            return View(volunteeringList);
        }

        // POST: VolunteeringLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VolunteeringList volunteeringList = db.VolunteeringLists.Find(id);
            db.VolunteeringLists.Remove(volunteeringList);
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
