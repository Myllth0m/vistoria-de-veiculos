using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VistoriaDeVeiculos.DataContext;
using VistoriaDeVeiculos.Models.Entities;

namespace VistoriaDeVeiculos.Controllers
{
    public class FormularioDeInspecaoController : Controller
    {
        private readonly Contexto contexto;

        public FormularioDeInspecaoController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {
            ViewBag.QuantidadeDeFormulariosCriados = contexto.FormularioDeInspecao.Count();

            return View();
        }

        [HttpPost]
        public IActionResult Novo()
        {
            var novoFormularioDeInspecao = new FormularioDeInspecao()
            {
                Id = Guid.NewGuid(),
                DadosDoFormulario = new DadosDoFormulario()
                {
                    DataDaInspecao = DateTime.Now.ToString(),
                    NumeroDoFormulario = "",
                    Obra = "",
                    PeriodicaSemanal = "",
                    TipoDeTransferencia = Models.Enums.EnumDeTranferencia.saida,
                },
                DadosDoMotorista = new Motorista()
                {
                    Cnh = "",
                    Categoria = "",
                },
                DadosDoVeiculo = new Veiculo()
                {
                    Placa = "",
                    UltimaRevisao = "",
                },
                Perguntas = new List<Pergunta>()
                {
                    new Pergunta()
                    {
                        Titulo = "Motorista: vestuário/conduta",
                        Descricao = "",
                        TipoDeResposta = Models.Enums.EnumDeResposta.nt,
                    },
                    new Pergunta()
                    {
                        Titulo = "Documentação do veículo",
                        Descricao = "",
                        TipoDeResposta = Models.Enums.EnumDeResposta.nt,
                    },
                    new Pergunta()
                    {
                        Titulo = "Lanternas",
                        Descricao = "",
                        TipoDeResposta = Models.Enums.EnumDeResposta.nt,
                    },
                    new Pergunta()
                    {
                        Titulo = "Buzinas",
                        Descricao = "",
                        TipoDeResposta = Models.Enums.EnumDeResposta.nt,
                    },
                    new Pergunta()
                    {
                        Titulo = "Luz de freio",
                        Descricao = "",
                        TipoDeResposta = Models.Enums.EnumDeResposta.nt,
                    },
                }
            };

            contexto.Add(novoFormularioDeInspecao);
            contexto.SaveChanges();

            return RedirectToAction("Editar", new { formularioId = novoFormularioDeInspecao.Id });
        }

        public IActionResult Editar(Guid formularioId)
        {
            var formularioDeInspecao = contexto.FormularioDeInspecao
                .Include(x => x.DadosDoVeiculo)
                .Include(x => x.DadosDoMotorista)
                .Include(x => x.Perguntas)
                .First(x => x.Id == formularioId);

            return View(formularioDeInspecao);
        }

        [HttpPost]
        public IActionResult Finalizar(FormularioDeInspecao formularioDeInspecao)
        {
            contexto.Update(formularioDeInspecao);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
