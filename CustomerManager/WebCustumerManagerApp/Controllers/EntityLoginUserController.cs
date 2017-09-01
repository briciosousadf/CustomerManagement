using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCustumerManagerApp.Models;

namespace WebCustumerManagerApp.Controllers
{
    public class EntityLoginUserController : Controller
    {
        private WebCustumerManagerAppContext db = new WebCustumerManagerAppContext();

        // GET: EntityLoginUser
        public ActionResult Index()
        {
            return View(db.EntityLoginUser.ToList());
        }

        // GET: EntityLoginUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityLoginUser entityLoginUser = db.EntityLoginUser.Find(id);
            if (entityLoginUser == null)
            {
                return HttpNotFound();
            }
            return View(entityLoginUser);
        }

        // GET: EntityLoginUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntityLoginUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,RegDate,Email")] EntityLoginUser entityLoginUser)
        {
            if (ModelState.IsValid)
            {
                db.EntityLoginUser.Add(entityLoginUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entityLoginUser);
        }

        // GET: EntityLoginUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityLoginUser entityLoginUser = db.EntityLoginUser.Find(id);
            if (entityLoginUser == null)
            {
                return HttpNotFound();
            }
            return View(entityLoginUser);
        }

        // POST: EntityLoginUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,RegDate,Email")] EntityLoginUser entityLoginUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityLoginUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entityLoginUser);
        }

        // GET: EntityLoginUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityLoginUser entityLoginUser = db.EntityLoginUser.Find(id);
            if (entityLoginUser == null)
            {
                return HttpNotFound();
            }
            return View(entityLoginUser);
        }

        // POST: EntityLoginUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityLoginUser entityLoginUser = db.EntityLoginUser.Find(id);
            db.EntityLoginUser.Remove(entityLoginUser);
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
