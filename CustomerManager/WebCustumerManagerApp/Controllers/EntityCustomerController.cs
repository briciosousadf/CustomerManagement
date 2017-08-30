using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCustumerManagerApp.Models;
using WebCustumerManagerApp.Models.ViewModels;

namespace WebCustumerManagerApp.Controllers
{
    public class EntityCustomerController : Controller
    {
        private WebCustumerManagerAppContext db = new WebCustumerManagerAppContext();

        // GET: EntityCustomer
        public ActionResult Index()
        {
            return View(db.EntityCustomers.ToList());
        }

        // GET: EntityCustomer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityCustomer entityCustomer = db.EntityCustomers.Find(id);
            if (entityCustomer == null)
            {
                return HttpNotFound();
            }
            return View(entityCustomer);
        }

        // GET: EntityCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntityCustomer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerFirstName,CustomerLastName")] EntityCustomer entityCustomer)
        {
            if (ModelState.IsValid)
            {
                db.EntityCustomers.Add(entityCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entityCustomer);
        }

        // GET: EntityCustomer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityCustomer entityCustomer = db.EntityCustomers.Find(id);
            if (entityCustomer == null)
            {
                return HttpNotFound();
            }
            return View(entityCustomer);
        }

        // POST: EntityCustomer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerFirstName,CustomerLastName")] EntityCustomer entityCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entityCustomer);
        }

        // GET: EntityCustomer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityCustomer entityCustomer = db.EntityCustomers.Find(id);
            if (entityCustomer == null)
            {
                return HttpNotFound();
            }
            return View(entityCustomer);
        }

        // POST: EntityCustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityCustomer entityCustomer = db.EntityCustomers.Find(id);
            db.EntityCustomers.Remove(entityCustomer);
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
