using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chatter.Models;

namespace Chatter.Controllers
{
    public class Chat1Controller : Controller
    {
        private ChatterEntities db = new ChatterEntities();

        // GET: Chat1
        public ActionResult Index()
        {
            var chat1 = db.Chat1.Include(c => c.AspNetUser);
            return View(chat1.ToList());
        }

        // GET: Chat1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chat1 chat1 = db.Chat1.Find(id);
            if (chat1 == null)
            {
                return HttpNotFound();
            }
            return View(chat1);
        }

        // GET: Chat1/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Chat1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChatID,UserID,ChatMessage,DateTimeStamp")] Chat1 chat1)
        {
            if (ModelState.IsValid)
            {
                db.Chat1.Add(chat1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", chat1.UserID);
            return View(chat1);
        }

        // GET: Chat1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chat1 chat1 = db.Chat1.Find(id);
            if (chat1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", chat1.UserID);
            return View(chat1);
        }

        // POST: Chat1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChatID,UserID,ChatMessage,DateTimeStamp")] Chat1 chat1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chat1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", chat1.UserID);
            return View(chat1);
        }

        // GET: Chat1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chat1 chat1 = db.Chat1.Find(id);
            if (chat1 == null)
            {
                return HttpNotFound();
            }
            return View(chat1);
        }

        // POST: Chat1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chat1 chat1 = db.Chat1.Find(id);
            db.Chat1.Remove(chat1);
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
