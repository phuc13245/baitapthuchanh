using baitapthuchanh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.ModelBinding;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace baitapthuchanh.Controllers
{
    public class BookController : Controller
    {
        BookManagerContext context = new BookManagerContext();
        public ActionResult ListBook()
        {

            return View(context.Books.ToList());
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        public ActionResult CreateBook()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind(Include = "ID,Title,Description,Author,Images,Price")] Book book)
        {

            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("ListBook");

            }
            return View(book);
        }
    }
}
