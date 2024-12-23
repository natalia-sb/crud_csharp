using Microsoft.AspNetCore.Mvc;
using System.Linq;
using YourNamespace.Data;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class FeriasController : Controller
    {
        private readonly AppDbContext _context;

        public FeriasController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var ferias = _context.Ferias
                .Join(_context.Funcionarios, 
                      f => f.FuncionarioId, 
                      func => func.Id, 
                      (f, func) => new 
                      {
                          f.Id,
                          Funcionario = func.Nome,
                          f.DataInicio,
                          f.DataTermino,
                          f.Status
                      })
                .ToList();

            return View(ferias);
        }


        public IActionResult Create()
        {
            ViewBag.Funcionarios = _context.Funcionarios.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ferias ferias)
        {
            if (ModelState.IsValid)
            {
                _context.Ferias.Add(ferias);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Funcionarios = _context.Funcionarios.ToList();
            return View(ferias);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ferias = _context.Ferias.Find(id);
            if (ferias == null)
                return NotFound();

            ViewBag.Funcionarios = _context.Funcionarios.ToList();
            return View(ferias);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ferias ferias)
        {
            if (id != ferias.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Ferias.Update(ferias);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Funcionarios = _context.Funcionarios.ToList();
            return View(ferias);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var ferias = _context.Ferias.Find(id);
            if (ferias == null)
                return NotFound();

            return View(ferias);
        }

  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ferias = _context.Ferias.Find(id);
            if (ferias != null)
            {
                _context.Ferias.Remove(ferias);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
