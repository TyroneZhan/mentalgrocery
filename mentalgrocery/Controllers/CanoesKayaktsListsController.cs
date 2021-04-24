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
    public class CanoesKayaktsListsController : Controller
    {
        private webModels db = new webModels();

        // GET: CanoesKayaktsLists
        /*public ActionResult Index()
        {
            return View(db.CanoesKayaktsLists.ToList());
        }*/

        public ActionResult Index(int pageindex, int pagesize)
        {
            var user = db.CanoesKayaktsLists.OrderBy(n => n.ckId).Skip<CanoesKayaktsList>(pagesize * (pageindex - 1)).Take<CanoesKayaktsList>(10);
            int total = db.CanoesKayaktsLists.Count();
            if (total % pagesize == 0)
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

            // GET: CanoesKayaktsLists/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanoesKayaktsList canoesKayaktsList = db.CanoesKayaktsLists.Find(id);
            if (canoesKayaktsList == null)
            {
                return HttpNotFound();
            }
            return View(canoesKayaktsList);
        }

        // GET: CanoesKayaktsLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CanoesKayaktsLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ckId,groupId,ckName,ckAddress,ckSuburb,ckPostCode,ckState,ckLGA,ckRegion,ckPhone,ckEmail,ckWeb")] CanoesKayaktsList canoesKayaktsList)
        {
            if (ModelState.IsValid)
            {
                db.CanoesKayaktsLists.Add(canoesKayaktsList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(canoesKayaktsList);
        }

        // GET: CanoesKayaktsLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanoesKayaktsList canoesKayaktsList = db.CanoesKayaktsLists.Find(id);
            if (canoesKayaktsList == null)
            {
                return HttpNotFound();
            }
            return View(canoesKayaktsList);
        }

        // POST: CanoesKayaktsLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ckId,groupId,ckName,ckAddress,ckSuburb,ckPostCode,ckState,ckLGA,ckRegion,ckPhone,ckEmail,ckWeb")] CanoesKayaktsList canoesKayaktsList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canoesKayaktsList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(canoesKayaktsList);
        }

        // GET: CanoesKayaktsLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanoesKayaktsList canoesKayaktsList = db.CanoesKayaktsLists.Find(id);
            if (canoesKayaktsList == null)
            {
                return HttpNotFound();
            }
            return View(canoesKayaktsList);
        }

        // POST: CanoesKayaktsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CanoesKayaktsList canoesKayaktsList = db.CanoesKayaktsLists.Find(id);
            db.CanoesKayaktsLists.Remove(canoesKayaktsList);
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
