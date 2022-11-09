using System;
using System.Collections.Generic;
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
        public IActionResult SalvarDadosDoVeiculoEMotorista(
            [FromServices] SalvarDadosDoFormulario salvarDadosDoFormulario, 
            FormularioDeInspecaoViewModel formularioDeInspecaoViewModel)
        {
            var formularioId = salvarDadosDoFormulario.Executar(formularioDeInspecaoViewModel);

            return RedirectToAction("Editar", new { formularioId });
        }

        [HttpPost]
        public IActionResult SalvarPerguntas(ICollection<PerguntaViewModel> perguntasDoFormulario)
        {
            contexto.Update(perguntasDoFormulario);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
