using Guestbook.DAL;
using Guestbook.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
        private GuestbookContext db = new GuestbookContext();

        // GET: Guestbook
        public ActionResult Index()
        {
            var sortedEntries = from e in db.GuestbookEntries
                                orderby e.DatePosted descending
                                select e;
            return View(sortedEntries.ToList());
        }

        // GET: Guestbook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guestbook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Comment")] GuestbookEntry guestbookEntry)
        {
            guestbookEntry.DatePosted = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.GuestbookEntries.Add(guestbookEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestbookEntry);
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