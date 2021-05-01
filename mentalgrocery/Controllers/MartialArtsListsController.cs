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
        /* public ActionResult Index()
         {
             return View(db.MartialArtsLists.ToList());
         }*/
        public ActionResult Index(int pageindex, int pagesize)
        {
            var user = db.MartialArtsLists.OrderBy(n => n.maId).Skip<MartialArtsList>(pagesize * (pageindex - 1)).Take<MartialArtsList>(10);
            int total = db.MartialArtsLists.Count();
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

        public ActionResult SearchPostCodes(int? postcode)
        {

            var viewList = db.MartialArtsLists
                .Where(x => x.maPostCode.Equals(postcode.ToString()))
                .OrderBy(n => n.maId);

            if (viewList.Count() == 0)
            {
                List<MartialArtsList> temp_list = db.MartialArtsLists
                    .ToList();
                int up_one = -1;
                int up_two = -1;
                int down_one = -1;
                int down_two = -1;

                var uplist = temp_list
                    .Where(c => int.Parse(c.maPostCode) > postcode)
                    .OrderBy(c => int.Parse(c.maPostCode)).ToList();
                var downlist = temp_list
                    .Where(c => int.Parse(c.maPostCode) < postcode)
                    .OrderByDescending(c => int.Parse(c.maPostCode)).ToList();

                ViewBag.Message = "sorry no groups In the " + postcode + " postcode. Here are the nearest groups. For more information please click the In Map button";

                if (downlist.Count < 1 && uplist.Count > 2)
                {
                    up_one = int.Parse(uplist.ElementAt(0).maPostCode);
                    up_two = int.Parse(uplist.ElementAt(1).maPostCode);

                    var results = db.MartialArtsLists
                        .Where(c => c.maPostCode.Equals(up_one.ToString())
                                    | c.maPostCode.Equals(up_two.ToString())).ToList();
                    return View(results);

                }
                else if (downlist.Count == 1 && uplist.Count > 2)
                {
                    up_one = int.Parse(uplist.ElementAt(0).maPostCode);
                    up_two = int.Parse(uplist.ElementAt(1).maPostCode);
                    down_one = int.Parse(downlist.ElementAt(0).maPostCode);

                    var results = db.MartialArtsLists
                        .Where(c => c.maPostCode.Equals(up_one.ToString())
                                    | c.maPostCode.Equals(up_two.ToString())
                                    | c.maPostCode.Equals(down_one.ToString())).ToList();
                    return View(results);

                }
                else if (downlist.Count > 2 && uplist.Count < 1)
                {
                    down_one = int.Parse(downlist.ElementAt(0).maPostCode);
                    down_two = int.Parse(downlist.ElementAt(1).maPostCode);

                    var results = db.MartialArtsLists
                        .Where(c => c.maPostCode.Equals(down_one.ToString())
                                    | c.maPostCode.Equals(down_two.ToString())).ToList();
                    return View(results);
                }
                else if (downlist.Count > 2 && uplist.Count == 1)
                {
                    down_one = int.Parse(downlist.ElementAt(0).maPostCode);
                    down_two = int.Parse(downlist.ElementAt(1).maPostCode);
                    up_one = int.Parse(uplist.ElementAt(0).maPostCode);

                    var results = db.MartialArtsLists
                        .Where(c => c.maPostCode.Equals(down_one.ToString())
                                    | c.maPostCode.Equals(down_two.ToString())
                                    | c.maPostCode.Equals(up_one.ToString())).ToList();
                    return View(results);
                }
                else
                {
                    up_one = int.Parse(uplist.ElementAt(0).maPostCode);
                    up_two = int.Parse(uplist.ElementAt(1).maPostCode);

                    down_one = int.Parse(downlist.ElementAt(0).maPostCode);
                    down_two = int.Parse(downlist.ElementAt(1).maPostCode);

                    var results = db.MartialArtsLists
                        .Where(c => c.maPostCode.Equals(up_one.ToString())
                                    | c.maPostCode.Equals(up_two.ToString())
                                    | c.maPostCode.Equals(down_one.ToString())
                                    | c.maPostCode.Equals(down_two.ToString())).ToList();
                    return View(results);
                }

            }

            return View(viewList);
        }


        public ActionResult MapView()
        {
            return View();
        }
    }
}
