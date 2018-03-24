using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Onibus.Models;

namespace Onibus.Controllers
{
    [Authorize]
    public class PassageiroController : Controller
    {
        private Context db = new Context();

        // GET: Passageiro
        public ActionResult Index()
        {
            return View(db.Passageiros.ToList());
        }

        // GET: Passageiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passageiro passageiro = db.Passageiros.Find(id);
            if (passageiro == null)
            {
                return HttpNotFound();
            }
            return View(passageiro);
        }

        // GET: Passageiro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passageiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Rg,Nascimento")] Passageiro passageiro)
        {
            if (ModelState.IsValid)
            {
                db.Passageiros.Add(passageiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passageiro);
        }

        // GET: Passageiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passageiro passageiro = db.Passageiros.Find(id);
            if (passageiro == null)
            {
                return HttpNotFound();
            }
            return View(passageiro);
        }

        // POST: Passageiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Rg,Nascimento")] Passageiro passageiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passageiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passageiro);
        }

        // GET: Passageiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passageiro passageiro = db.Passageiros.Find(id);
            if (passageiro == null)
            {
                return HttpNotFound();
            }
            return View(passageiro);
        }

        // POST: Passageiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passageiro passageiro = db.Passageiros.Find(id);
            db.Passageiros.Remove(passageiro);
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
