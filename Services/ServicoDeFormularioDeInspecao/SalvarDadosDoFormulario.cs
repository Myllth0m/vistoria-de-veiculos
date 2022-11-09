using System;
using VistoriaDeVeiculos.DataContext;
using VistoriaDeVeiculos.Models.Entities;
using VistoriaDeVeiculos.Models.ViewModels;

namespace VistoriaDeVeiculos.Services.ServicoDeFormularioDeInspecao
{
    public class SalvarDadosDoFormulario
    {
        private readonly Contexto contexto;

        public SalvarDadosDoFormulario(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public Guid Executar(FormularioDeInspecaoViewModel formularioDeInspecaoViewModel)
        {
            var formularioDeInspecao = new FormularioDeInspecao()
            {
                Id = formularioDeInspecaoViewModel.Id,
                DadosDoFormulario = new DadosDoFormulario()
                {
                    DataDaInspecao = formularioDeInspecaoViewModel.DadosDoFormulario.DataDaInspecao,
                    NumeroDoFormulario = formularioDeInspecaoViewModel.DadosDoFormulario.NumeroDoFormulario,
                    Obra = formularioDeInspecaoViewModel.DadosDoFormulario.Obra,
                    PeriodicaSemanal = formularioDeInspecaoViewModel.DadosDoFormulario.PeriodicaSemanal,
                    TipoDeTransferencia = formularioDeInspecaoViewModel.DadosDoFormulario.TipoDeTransferencia,
                },
            };
            
            var dadosDoMotorista = new Motorista()
            {
                Id = formularioDeInspecaoViewModel.DadosDoMotorista.Id,
                Cnh = formularioDeInspecaoViewModel.DadosDoMotorista.Cnh,
                Categoria = formularioDeInspecaoViewModel.DadosDoMotorista.Categoria,
                FormularioId = formularioDeInspecaoViewModel.Id,
            };

            var dadosDoVeiculo = new Veiculo()
            {
                Id = formularioDeInspecaoViewModel.DadosDoVeiculo.Id,
                Placa = formularioDeInspecaoViewModel.DadosDoVeiculo.Placa,
                UltimaRevisao = formularioDeInspecaoViewModel.DadosDoVeiculo.UltimaRevisao,
                FormularioId = formularioDeInspecaoViewModel.Id,
            };

            contexto.Update(formularioDeInspecao);
            contexto.Update(dadosDoMotorista);
            contexto.Update(dadosDoVeiculo);
            contexto.SaveChanges();

            return formularioDeInspecaoViewModel.Id;
        }
    }
}
