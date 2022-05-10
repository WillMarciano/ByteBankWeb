using ByteBank.Aplicacao.AplicacaoServico;
using ByteBank.Aplicacao.DTO;
using ByteBank.Aplicacao.Interfaces;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Interfaces.Servicos;
using ByteBank.Dominio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.WebApp.Controllers
{
    public class AgenciaController : Controller
    {
        // GET: AgenciaController    
        private readonly IAgenciaRepositorio _repositorio;
        private readonly IAgenciaServico _servico;
        private readonly IAgenciaServicoApp agenciaServicoApp;

        public AgenciaController(IAgenciaRepositorio repositorio)
        {
            _repositorio = repositorio;
            _servico = new AgenciaServico(_repositorio);
            agenciaServicoApp = new AgenciaServicoApp(_servico);
        }

        [Authorize]
        public ActionResult Index() => View(agenciaServicoApp.ObterTodos());

        [Authorize]
        public ActionResult Details(int id)
        {
            var agencia = agenciaServicoApp.ObterPorId(id);
            return View(agencia);
        }

        [Authorize]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind("Id,Numero,Nome,Endereco,Identificador")] AgenciaDTO agencia)
        {
            try
            {
                agenciaServicoApp.Adicionar(agencia);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(agencia);
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {

            if (id == null)
                return NotFound();

            var agencia = agenciaServicoApp.ObterPorId(id);
            if (agencia == null)
            {
                return NotFound();
            }
            return View(agencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, [Bind("Id,Numero,Nome,Endereco, Identificador")] AgenciaDTO agencia)
        {

            if (id != agencia.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    agenciaServicoApp.Atualizar(id, agencia);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenciaExists(agencia.Id))
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
            return View(agencia);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var agencia = agenciaServicoApp.ObterPorId(id);

            if (agencia == null)
                return NotFound();

            agenciaServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var agencia = agenciaServicoApp.ObterPorId(id);
            agenciaServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AgenciaExists(int id)
        {
            var agencia = agenciaServicoApp.ObterPorId(id);
            return agencia == null ? true : false;
        }
    }
}
