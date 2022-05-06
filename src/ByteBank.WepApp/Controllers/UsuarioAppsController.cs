using ByteBank.Dados.Repositorio;
using ByteBank.Dominio.Entidades;
using ByteBank.WebApp.Util;
using ByteBank.WebApp.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.WepApp.Controllers
{
    public class UsuarioAppsController : Controller
    {
        private UsuarioAppRepositorio _context;

        public UsuarioAppsController() => _context = new UsuarioAppRepositorio();

        public ActionResult Index() => View(_context.ObterTodos());

        public ActionResult Details(int id)
        {
            if (id == null) return NotFound();
            var usuarioApp = _context.ObterPorId(id);
            if (usuarioApp == null) return NotFound();
            return View(usuarioApp);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,UserName,Email,Senha")] UsuarioApp usuarioApp)
        {
            if (ModelState.IsValid)
            {
                _context.Adicionar(usuarioApp);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioApp);
        }

        public ActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            var usuarioApp = _context.ObterPorId(id);
            if (usuarioApp == null) return NotFound();
            return View(usuarioApp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,UserName,Email,Senha")] UsuarioApp usuarioApp)
        {
            if (id != usuarioApp.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Atualizar(id, usuarioApp);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioAppExists(usuarioApp.Id)) return NotFound();

                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioApp);
        }

        public ActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            var usuarioApp = _context.ObterPorId(id);

            if (usuarioApp == null) return NotFound();
            return View(usuarioApp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioApp = _context.ObterPorId(id);
            _context.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioAppExists(int id)
        {
            var usuarioApp = _context.ObterPorId(id);
            return usuarioApp == null ? true : false;
        }

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(UsuarioAppViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                string salto = Configuracao.Secret + usuario.Senha;
                string senha = Criptografia.sha256encrypt(salto);
                var _usuario = _context.ObterPorEmail(usuario.Email);
                if (_usuario != null)
                {
                    var token = TokenService.GenerateToken(_usuario);
                    if (_usuario.Senha == senha)
                    {
                        HttpContext.Request.Headers.Remove("Authorization");
                        HttpContext.Request.Headers.Add("Authorization", "Bearer " + token);
                        HttpContext.Session.SetString("JWToken", token);
                        HttpContext.Session.SetString("user", _usuario.UserName);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "UsuarioApps");
        }

    }
}
