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

        public ActionResult SearchPostCodes(int? postcode)
        {

            var viewList = db.VolunteeringLists
                .Where(x => x.vpPostCode.Equals(postcode.ToString()))
                .OrderBy(n => n.voId);

            if (viewList.Count() == 0)
            {
                List<VolunteeringList> temp_list = db.VolunteeringLists
                    .ToList();
                int up_one = -1;
                int up_two = -1;
                int down_one = -1;
                int down_two = -1;

                var uplist = temp_list
                    .Where(c => int.Parse(c.vpPostCode) > postcode)
                    .OrderBy(c => int.Parse(c.vpPostCode)).ToList();
                var downlist = temp_list
                    .Where(c => int.Parse(c.vpPostCode) < postcode)
                    .OrderByDescending(c => int.Parse(c.vpPostCode)).ToList();

                ViewBag.Message = "sorry no groups In the " + postcode + " postcode. Here are the nearest groups. For more information please click the In Map button";

                if (downlist.Count < 1 && uplist.Count > 2)
                {
                    up_one = int.Parse(uplist.ElementAt(0).vpPostCode);
                    up_two = int.Parse(uplist.ElementAt(1).vpPostCode);

                    var results = db.VolunteeringLists
                        .Where(c => c.vpPostCode.Equals(up_one.ToString())
                                    | c.vpPostCode.Equals(up_two.ToString())).ToList();
                    return View(results);

                }
                else if (downlist.Count == 1 && uplist.Count > 2)
                {
                    up_one = int.Parse(uplist.ElementAt(0).vpPostCode);
                    up_two = int.Parse(uplist.ElementAt(1).vpPostCode);
                    down_one = int.Parse(downlist.ElementAt(0).vpPostCode);

                    var results = db.VolunteeringLists
                        .Where(c => c.vpPostCode.Equals(up_one.ToString())
                                    | c.vpPostCode.Equals(up_two.ToString())
                                    | c.vpPostCode.Equals(down_one.ToString())).ToList();
                    return View(results);

                }
                else if (downlist.Count > 2 && uplist.Count < 1)
                {
                    down_one = int.Parse(downlist.ElementAt(0).vpPostCode);
                    down_two = int.Parse(downlist.ElementAt(1).vpPostCode);

                    var results = db.VolunteeringLists
                        .Where(c => c.vpPostCode.Equals(down_one.ToString())
                                    | c.vpPostCode.Equals(down_two.ToString())).ToList();
                    return View(results);
                }
                else if (downlist.Count > 2 && uplist.Count == 1)
                {
                    down_one = int.Parse(downlist.ElementAt(0).vpPostCode);
                    down_two = int.Parse(downlist.ElementAt(1).vpPostCode);
                    up_one = int.Parse(uplist.ElementAt(0).vpPostCode);

                    var results = db.VolunteeringLists
                        .Where(c => c.vpPostCode.Equals(down_one.ToString())
                                    | c.vpPostCode.Equals(down_two.ToString())
                                    | c.vpPostCode.Equals(up_one.ToString())).ToList();
                    return View(results);
                }
                else
                {
                    up_one = int.Parse(uplist.ElementAt(0).vpPostCode);
                    up_two = int.Parse(uplist.ElementAt(1).vpPostCode);

                    down_one = int.Parse(downlist.ElementAt(0).vpPostCode);
                    down_two = int.Parse(downlist.ElementAt(1).vpPostCode);

                    var results = db.VolunteeringLists
                        .Where(c => c.vpPostCode.Equals(up_one.ToString())
                                    | c.vpPostCode.Equals(up_two.ToString())
                                    | c.vpPostCode.Equals(down_one.ToString())
                                    | c.vpPostCode.Equals(down_two.ToString())).ToList();
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
