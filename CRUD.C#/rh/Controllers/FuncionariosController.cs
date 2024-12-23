using Microsoft.AspNetCore.Mvc;
using System.Linq;
using YourNamespace.Data;
using YourNamespace.Models;

[Route("api/[controller]")]
[ApiController]
public class FuncionariosApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionariosApiController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult GetFuncionarios()
    {
        var funcionarios = _context.Funcionarios.ToList();
        return Ok(funcionarios);
    }
}

namespace YourNamespace.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly AppDbContext _context;

        public FuncionariosController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var funcionarios = _context.Funcionarios.ToList();
            return View(funcionarios);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
                return NotFound();

            return View(funcionario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Funcionario funcionario)
        {
            if (id != funcionario.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Funcionarios.Update(funcionario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
                return NotFound();

            return View(funcionario);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
