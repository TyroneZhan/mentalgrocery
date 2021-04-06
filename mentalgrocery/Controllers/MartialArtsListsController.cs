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
    public class MartialArtsListsController : Controller
    {
        private webModels db = new webModels();

        // GET: MartialArtsLists
        public ActionResult Index()
        {
            return View(db.MartialArtsLists.ToList());
        }

        // GET: MartialArtsLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MartialArtsList martialArtsList = db.MartialArtsLists.Find(id);
            if (martialArtsList == null)
            {
                return HttpNotFound();
            }
            return View(martialArtsList);
        }

        // GET: MartialArtsLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MartialArtsLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maId,groupId,maName,maAddress,maSuburb,maPostCode,maState,maLGA,maRegion,maPhone,maEmail,maWeb")] MartialArtsList martialArtsList)
        {
            if (ModelState.IsValid)
            {
                db.MartialArtsLists.Add(martialArtsList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(martialArtsList);
        }

        // GET: MartialArtsLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MartialArtsList martialArtsList = db.MartialArtsLists.Find(id);
            if (martialArtsList == null)
            {
                return HttpNotFound();
            }
            return View(martialArtsList);
        }

        // POST: MartialArtsLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maId,groupId,maName,maAddress,maSuburb,maPostCode,maState,maLGA,maRegion,maPhone,maEmail,maWeb")] MartialArtsList martialArtsList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(martialArtsList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(martialArtsList);
        }

        // GET: MartialArtsLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MartialArtsList martialArtsList = db.MartialArtsLists.Find(id);
            if (martialArtsList == null)
            {
                return HttpNotFound();
            }
            return View(martialArtsList);
        }

        // POST: MartialArtsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MartialArtsList martialArtsList = db.MartialArtsLists.Find(id);
            db.MartialArtsLists.Remove(martialArtsList);
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
