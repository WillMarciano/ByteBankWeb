using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ByteBank.Aplicacao.AplicacaoServico;
using ByteBank.Dominio.Interfaces.Servicos;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Services;
using ByteBank.Aplicacao.DTO;

namespace ByteBank.WebApp.Controllers
{
    public class ClientesController : Controller
    {

        private readonly IClienteRepositorio _repositorio;
        private readonly IClienteServico _servico;
        private readonly ClienteServicoApp clienteServicoApp;
        public ClientesController(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
            _servico = new ClienteServico(_repositorio);
            clienteServicoApp = new ClienteServicoApp(_servico);
        }

        [Authorize]
        public IActionResult Index() => View(clienteServicoApp.ObterTodos());

        // GET: Clientes/Details/5
        [Authorize]
        public IActionResult Details(int id)
        {
            if (id == null) return NotFound();

            var cliente = clienteServicoApp.ObterPorId(id);

            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Identificador,CPF,Nome,Profissao")] ClienteDTO cliente)
        {
            if (ModelState.IsValid)
            {
                clienteServicoApp.Adicionar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            var cliente = clienteServicoApp.ObterPorId(id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, [Bind("Id,Identificador,CPF,Nome,Profissao")] ClienteDTO cliente)
        {
            if (id != cliente.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    clienteServicoApp.Atualizar(id, cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            var cliente = clienteServicoApp.ObterPorId(id);

            if (cliente == null) return NotFound();

            clienteServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = clienteServicoApp.ObterPorId(id);
            clienteServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            var cliente = clienteServicoApp.ObterPorId(id);
            return cliente == null ? true : false;
        }
    }
}
