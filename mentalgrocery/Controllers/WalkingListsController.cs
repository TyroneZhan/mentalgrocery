﻿using System;
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
    public class WalkingListsController : Controller
    {
        private webModels db = new webModels();

        /*// GET: WalkingLists
        public ActionResult Index()
        {
            return View(db.WalkingLists.ToList());
        }*/

        public ActionResult Index(int pageindex, int pagesize)
        {
            var user = db.WalkingLists.OrderBy(n => n.waId).Skip<WalkingList>(pagesize * (pageindex - 1)).Take<WalkingList>(10);
            int total = db.WalkingLists.Count();
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

        // GET: WalkingLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkingList walkingList = db.WalkingLists.Find(id);
            if (walkingList == null)
            {
                return HttpNotFound();
            }
            return View(walkingList);
        }

        // GET: WalkingLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkingLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "waId,groupId,waName,waAddress,waSuburb,waPostCode,waState,waLGA,waRegion,waPhone,waEmail,waWeb")] WalkingList walkingList)
        {
            if (ModelState.IsValid)
            {
                db.WalkingLists.Add(walkingList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(walkingList);
        }

        // GET: WalkingLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkingList walkingList = db.WalkingLists.Find(id);
            if (walkingList == null)
            {
                return HttpNotFound();
            }
            return View(walkingList);
        }

        // POST: WalkingLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "waId,groupId,waName,waAddress,waSuburb,waPostCode,waState,waLGA,waRegion,waPhone,waEmail,waWeb")] WalkingList walkingList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(walkingList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(walkingList);
        }

        // GET: WalkingLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WalkingList walkingList = db.WalkingLists.Find(id);
            if (walkingList == null)
            {
                return HttpNotFound();
            }
            return View(walkingList);
        }

        // POST: WalkingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WalkingList walkingList = db.WalkingLists.Find(id);
            db.WalkingLists.Remove(walkingList);
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
