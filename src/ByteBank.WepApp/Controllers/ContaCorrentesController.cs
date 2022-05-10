using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Interfaces.Servicos;
using ByteBank.Aplicacao.AplicacaoServico;
using ByteBank.Dominio.Services;
using ByteBank.Aplicacao.DTO;

namespace ByteBank.WebApp.Controllers
{

    public class ContaCorrentesController : Controller
    {
        private readonly IContaCorrenteRepositorio _repositorio;
        private readonly IContaCorrenteServico _servico;
        private readonly IClienteServico _servicoCliente;
        private readonly IAgenciaServico _servicoAgencia;
        private readonly ContaCorrenteServicoApp contaCorrenteServicoApp;

        public ContaCorrentesController(IContaCorrenteRepositorio repositorio,
                                        IClienteRepositorio repositorioCliente,
                                        IAgenciaRepositorio repositorioAgencia)
        {
            _repositorio = repositorio;
            _servico = new ContaCorrenteServico(_repositorio);
            _servicoCliente = new ClienteServico(repositorioCliente);
            _servicoAgencia = new AgenciaServico(repositorioAgencia); ;
            contaCorrenteServicoApp = new ContaCorrenteServicoApp(_servico, _servicoAgencia, _servicoCliente);
        }
        [Authorize]
        public ActionResult Index() => View(contaCorrenteServicoApp.ObterTodos());

        [Authorize]
        public IActionResult Details(int id)
        {
            if (id == null) return NotFound();
            var contaCorrente = contaCorrenteServicoApp.ObterPorId(id);

            if (contaCorrente == null) return NotFound();
            return View(contaCorrente);
        }

        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,AgenciaId,Numero,Identificador,Saldo,PixConta")] ContaCorrenteDTO contaCorrente)
        {
            if (ModelState.IsValid)
            {
                contaCorrenteServicoApp.Adicionar(contaCorrente);
                return RedirectToAction(nameof(Index));
            }
            return View(contaCorrente);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();
            var contaCorrente = contaCorrenteServicoApp.ObterPorId(id); ;
            if (contaCorrente == null) return NotFound();

            return View(contaCorrente);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,ClienteId,AgenciaId,Numero,Identificador,Saldo,PixConta")] ContaCorrenteDTO contaCorrente)
        {
            if (id != contaCorrente.Id) return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    contaCorrenteServicoApp.Atualizar(id, contaCorrente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaCorrenteExists(contaCorrente.Id))
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
            return View(contaCorrente);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            var contaCorrente = contaCorrenteServicoApp.ObterPorId(id);
            if (contaCorrente == null) return NotFound();

            contaCorrenteServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var contaCorrente = contaCorrenteServicoApp.ObterPorId(id);
            contaCorrenteServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ContaCorrenteExists(int id)
        {
            var contaCorrente = contaCorrenteServicoApp.ObterPorId(id);
            return contaCorrente == null ? true : false;
        }
    }
}
