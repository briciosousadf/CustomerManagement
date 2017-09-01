using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCustumerManagerApp.Models;

namespace WebCustumerManagerApp.Controllers
{
    public class EntityOccupationGroupController : Controller
    {
        private WebCustumerManagerAppContext db = new WebCustumerManagerAppContext();

        // GET: EntityOccupationGroup
        public ActionResult Index()
        {
            return View(db.EntityOccupationGroups.Include(e => e.ListOfCustomers).ToList());
        }

        // GET: EntityOccupationGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityOccupationGroup entityOccupationGroup = db.EntityOccupationGroups.Find(id);
            if (entityOccupationGroup == null)
            {
                return HttpNotFound();
            }
            return View(entityOccupationGroup);
        }

        // GET: EntityOccupationGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntityOccupationGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OccupationGroupId,OccupationGroupTitle")] EntityOccupationGroup entityOccupationGroup)
        {
            if (ModelState.IsValid)
            {
                db.EntityOccupationGroups.Add(entityOccupationGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entityOccupationGroup);
        }

        // GET: EntityOccupationGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityOccupationGroup entityOccupationGroup = db.EntityOccupationGroups.Find(id);
            if (entityOccupationGroup == null)
            {
                return HttpNotFound();
            }
            return View(entityOccupationGroup);
        }

        // POST: EntityOccupationGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OccupationGroupId,OccupationGroupTitle")] EntityOccupationGroup entityOccupationGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityOccupationGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entityOccupationGroup);
        }

        // GET: EntityOccupationGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityOccupationGroup entityOccupationGroup = db.EntityOccupationGroups.Find(id);
            if (entityOccupationGroup == null)
            {
                return HttpNotFound();
            }
            return View(entityOccupationGroup);
        }

        // POST: EntityOccupationGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityOccupationGroup entityOccupationGroup = db.EntityOccupationGroups.Find(id);
            try
            {
                db.EntityOccupationGroups.Remove(entityOccupationGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (SqlException)
            {

                throw new Exception("error");
                
                
            }
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
