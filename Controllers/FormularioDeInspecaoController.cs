using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VistoriaDeVeiculos.DataContext;
using VistoriaDeVeiculos.Models.ViewModels;
using VistoriaDeVeiculos.Services.ServicoDeFormularioDeInspecao;
using VistoriaDeVeiculos.Services.ServicoDePainelDeControle;

namespace VistoriaDeVeiculos.Controllers
{
    public class FormularioDeInspecaoController : Controller
    {
        private readonly Contexto contexto;

        public FormularioDeInspecaoController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index(
            [FromServices] BuscarDadosDoPainelDeControle buscarDadosDoPainelDeControle)
        {
            var dadosDoPainelDeControle = buscarDadosDoPainelDeControle.Executar();

            return View(dadosDoPainelDeControle);
        }

        [HttpPost]
        public IActionResult Novo(
            [FromServices] CriarFormularioDeInspecao criarFormularioDeInspecao)
        {
            var formularioId = criarFormularioDeInspecao.Executar();

            return RedirectToAction("Editar", new { formularioId });
        }

        public IActionResult Editar(
            [FromServices] BuscarFormularioDeInspecao buscarFormularioDeInspecao, 
            Guid formularioId)
        {
            var formularioDeInspecao = buscarFormularioDeInspecao.Executar(formularioId);

            return View(formularioDeInspecao);
        }

        [HttpPost]
        public IActionResult Finalizar(FormularioDeInspecaoViewModel formularioDeInspecao)
        {
            contexto.Update(formularioDeInspecao);
            contexto.Update(formularioDeInspecao.Perguntas);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
