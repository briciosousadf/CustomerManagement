using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCustumerManagerApp.Helper;
using WebCustumerManagerApp.Models;
using WebCustumerManagerApp.Models.ViewModels;

namespace WebCustumerManagerApp.Controllers
{
    public class EntityLoginUserController : Controller
    {
        private WebCustumerManagerAppContext db = new WebCustumerManagerAppContext();

        // GET: EntityLoginUser
        public ActionResult Index()
        {
            if(Session["loggedUserId"]!= null)
            {
                return View(db.EntityLoginUser.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
            
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

        public ActionResult Login()
        {
            return View();
        }
        
        // POST: EntityLoginUser/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login (string userName, string password)
        {
            //if (ModelState.IsValid)
            //{
            //using(WebCustumerManagerAppContext dc = new WebCustumerManagerAppContext())
            //{
            //var accesValue = dc.EntityLoginUser.Where(u => u.Username.Equals(loginUser.Username) && u.Password.Equals(loginUser.Password)).FirstOrDefault();
            //if(accesValue != null)
            //{
            //Session["loggedUserId"] = accesValue.Id.ToString();
            //Session["loggedUserName"] = accesValue.Username.ToString();
            //return RedirectToAction("Index");
            //}
            //}
            //}
            //return View();
            try
            {
                using (var contex = new WebCustumerManagerAppContext())
                {
                    var getUserName = (from s in contex.EntityLoginUser where s.Username == userName || s.Email == userName select s).FirstOrDefault();

                    if (getUserName != null)
                    {
                        var hashCode = getUserName.VCodePassword;
                        var encondingPasswordString = WebCustomerManagerHelper.EncodePassword(password, hashCode);
                        var query = (from s in contex.EntityLoginUser where (s.Username == userName || s.Email == userName) && s.Password.Equals(encondingPasswordString) select s).FirstOrDefault();
                        
                        if(query != null)
                        {
                            Session["loggedUserId"] = query.Id.ToString();
                            Session["loggedUserName"] = query.Username.ToString();
                            return RedirectToAction("Index");
                        }

                        ViewBag.errormessage = "Invalid User Name or Password";
                        return View();
                    }
                    ViewBag.errormessage = "Invalid User Name or Password";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Error!!! contact admin" + e;
                return View();
            }
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
        public ActionResult Create(EntityLoginUser entityLoginUser)
        {
            //if (ModelState.IsValid)
            //{
            //entityLoginUser.RegDate = DateTime.Now;
            //db.EntityLoginUser.Add(entityLoginUser);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            //}

            //return View(entityLoginUser);
            try
            {
                using(var contex = new WebCustumerManagerAppContext())
                {
                    var checkUser = (from s in contex.EntityLoginUser where s.Username == entityLoginUser.Username || s.Password == entityLoginUser.Password select s).FirstOrDefault();
                    if (checkUser == null)
                    {
                        var keyNew = WebCustomerManagerHelper.GeneratePassword(10);
                        var password = WebCustomerManagerHelper.EncodePassword(entityLoginUser.Password, keyNew);
                        entityLoginUser.Password = password;
                        entityLoginUser.RegDate = DateTime.Now;
                        entityLoginUser.VCodePassword = keyNew;
                        db.EntityLoginUser.Add(entityLoginUser);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Login");
                    }
                    ViewBag.errorMessage = "User Already Exist!!!!!";
                    return View();
                }
            }
            catch(Exception e)
            {
                ViewBag.errorMessage = "Some Exception occourred" + e;
                return View();
            }

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
