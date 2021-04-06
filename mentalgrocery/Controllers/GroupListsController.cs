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
    public class GroupListsController : Controller
    {
        private webModels db = new webModels();

        // GET: GroupLists
        public ActionResult Index()
        {
            return View(db.GroupLists.ToList());
        }

        // GET: GroupLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupList groupList = db.GroupLists.Find(id);
            if (groupList == null)
            {
                return HttpNotFound();
            }
            return View(groupList);
        }

        // GET: GroupLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "groupId,groupName")] GroupList groupList)
        {
            if (ModelState.IsValid)
            {
                db.GroupLists.Add(groupList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupList);
        }

        // GET: GroupLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupList groupList = db.GroupLists.Find(id);
            if (groupList == null)
            {
                return HttpNotFound();
            }
            return View(groupList);
        }

        // POST: GroupLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "groupId,groupName")] GroupList groupList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupList);
        }

        // GET: GroupLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupList groupList = db.GroupLists.Find(id);
            if (groupList == null)
            {
                return HttpNotFound();
            }
            return View(groupList);
        }

        // POST: GroupLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupList groupList = db.GroupLists.Find(id);
            db.GroupLists.Remove(groupList);
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
