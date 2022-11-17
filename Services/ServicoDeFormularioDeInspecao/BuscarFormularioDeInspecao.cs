using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VistoriaDeVeiculos.DataContext;
using VistoriaDeVeiculos.Models.ViewModels;

namespace VistoriaDeVeiculos.Services.ServicoDeFormularioDeInspecao
{
    public class BuscarFormularioDeInspecao
    {
        private readonly Contexto contexto;

        public BuscarFormularioDeInspecao(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public FormularioDeInspecaoViewModel Executar(Guid formularioId)
        {
            var formularioDeInspecao = contexto.FormularioDeInspecao
                .Include(x => x.DadosDoVeiculo)
                .Include(x => x.DadosDoMotorista)
                .Include(x => x.Perguntas)
                .First(x => x.Id == formularioId);

            var formularioDeInspecaoViewModel = new FormularioDeInspecaoViewModel()
            {
                Id = formularioDeInspecao.Id,
            };

            formularioDeInspecaoViewModel.DadosDoFormulario = new DadosDoFormularioViewModel()
            {
                PeriodicaSemanal = formularioDeInspecao.DadosDoFormulario.PeriodicaSemanal,
                DataDaInspecao = formularioDeInspecao.DadosDoFormulario.DataDaInspecao,
                NumeroDoFormulario = formularioDeInspecao.DadosDoFormulario.NumeroDoFormulario,
                Obra = formularioDeInspecao.DadosDoFormulario.Obra,
                TipoDeTransferencia = formularioDeInspecao.DadosDoFormulario.TipoDeTransferencia,
            };

            formularioDeInspecaoViewModel.DadosDoVeiculo = new VeiculoViewModel()
            {
                Id = formularioDeInspecao.DadosDoVeiculo.Id,
                Placa = formularioDeInspecao.DadosDoVeiculo.Placa,
                UltimaRevisao = formularioDeInspecao.DadosDoVeiculo.UltimaRevisao,
            };

            formularioDeInspecaoViewModel.DadosDoMotorista = new MotoristaViewModel()
            {
                Id = formularioDeInspecao.DadosDoMotorista.Id,
                Cnh = formularioDeInspecao.DadosDoMotorista.Cnh,
                Categoria = formularioDeInspecao.DadosDoMotorista.Categoria,
            };
            
            formularioDeInspecaoViewModel.Perguntas = new List<PerguntaViewModel>();

            foreach (var pergunta in formularioDeInspecao.Perguntas)
            {
                formularioDeInspecaoViewModel.Perguntas.Add(new PerguntaViewModel()
                {
                    Id = pergunta.Id,
                    Titulo = pergunta.Titulo,
                    TipoDeResposta = pergunta.TipoDeResposta,
                });
            }

            return formularioDeInspecaoViewModel;
        }
    }
}
