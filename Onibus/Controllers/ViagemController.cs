using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Onibus.Models;

namespace Onibus.Controllers
{
    [Authorize]
    public class ViagemController : Controller
    {
        private Context db = new Context();

        // GET: Viagem
        public ActionResult Index()
        {
            var viagens = db.Viagens.Include(v => v.Motorista).Include(v => v.Onibus);
            return View(viagens.ToList());
        }

        // GET: Viagem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagens.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // GET: Viagem/Create
        public ActionResult Create()
        {
            ViewBag.MotoristaId = new SelectList(db.Motoristas, "Id", "Nome");
            ViewBag.OnibusId = new SelectList(db.Onibus, "Id", "Placa");
            return View();
        }

        // POST: Viagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Destino,Data,OnibusId,MotoristaId")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                db.Viagens.Add(viagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MotoristaId = new SelectList(db.Motoristas, "Id", "Nome", viagem.MotoristaId);
            ViewBag.OnibusId = new SelectList(db.Onibus, "Id", "Placa", viagem.OnibusId);
            return View(viagem);
        }

        // GET: Viagem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagens.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MotoristaId = new SelectList(db.Motoristas, "Id", "Nome", viagem.MotoristaId);
            ViewBag.OnibusId = new SelectList(db.Onibus, "Id", "Placa", viagem.OnibusId);
            return View(viagem);
        }

        // POST: Viagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Destino,Data,OnibusId,MotoristaId")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MotoristaId = new SelectList(db.Motoristas, "Id", "Nome", viagem.MotoristaId);
            ViewBag.OnibusId = new SelectList(db.Onibus, "Id", "Placa", viagem.OnibusId);
            return View(viagem);
        }

        // GET: Viagem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viagem viagem = db.Viagens.Find(id);
            if (viagem == null)
            {
                return HttpNotFound();
            }
            return View(viagem);
        }

        // POST: Viagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viagem viagem = db.Viagens.Find(id);
            db.Viagens.Remove(viagem);
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
