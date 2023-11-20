using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PartyProduct.Models;
using PartyProduct.ViewModels;

namespace PartyProduct.Controllers
{
    [Authorize]
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoices
        public ActionResult Index()
        {
            //return View(db.Invoices.Include(x => x.Party).Include(x => x.Product).ToList());
            return RedirectToAction("Create");
        }

        // GET: Invoices/Details/5


        // GET: Invoices/Create
        public ActionResult Create()
        {
            var party = db.Parties;


            ViewBag.list = party;

            BindInvoice bd = new BindInvoice()
            {
                invoices = db.Invoices.Include(x => x.Party).Include(x => x.Product)
            };
            return View(bd);
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BindInvoice invoice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pId = Convert.ToInt32(invoice.singleInvoice.Party.PartyName);
                    var prId = Convert.ToInt32(invoice.singleInvoice.Product.ProductName);
                    var party = db.Parties.Single(x => x.id == pId);
                    var product = db.Products.Single(x => x.id == prId);



                    Invoice Data = new Invoice()
                    {
                        Rate_Of_Product = invoice.singleInvoice.Rate_Of_Product,
                        Quantity = invoice.singleInvoice.Quantity,
                        Party = party,
                        Product = product
                    };
                    db.Invoices.Add(Data);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Create");
                }
                return RedirectToAction("Create");
            }

            return View(invoice);
        }



        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("create");
        }

        public ActionResult DeleteAll()
        {
            db.Invoices.RemoveRange(db.Invoices);
            db.SaveChanges();
            return RedirectToAction("Create");
        }




        public JsonResult GetProducts(int id)
        {

            var assign = db.AssignParties.Where(x => x.Party.id == id).Select(x => x.Product);
            return Json(assign, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRate(int id)
        {
            var rate = db.ProductRates.Where(x => x.Product.id == id).OrderBy(x => x.Date_Of_Rate);
            return Json(rate, JsonRequestBehavior.AllowGet);
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
