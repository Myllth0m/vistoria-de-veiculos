using System;
using System.Linq;
using VistoriaDeVeiculos.DataContext;
using VistoriaDeVeiculos.Models.ViewModels;

namespace VistoriaDeVeiculos.Services.ServicoDePainelDeControle
{
    public class BuscarDadosDoPainelDeControle
    {
        private readonly Contexto contexto;

        public BuscarDadosDoPainelDeControle(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public DadosDoPainelDeControleViewModel Executar()
        {
            var dataDeHoje = DateTime.Today.ToShortDateString();

            var quantidadeTotalDeFormulariosCriados = contexto.FormularioDeInspecao.Count();
            var quatidadeDeFormulariosCriadosHoje = contexto.FormularioDeInspecao.Count(x => x.DadosDoFormulario.DataDaInspecao.Contains(dataDeHoje));

            var dadosDoPainelDeControleViewModel = new DadosDoPainelDeControleViewModel()
            {
                QuantidadeTotalDeFormulariosCriados = quantidadeTotalDeFormulariosCriados,
                QuantidadeDeFormulariosCriadosHoje = quatidadeDeFormulariosCriadosHoje,
            };

            return dadosDoPainelDeControleViewModel;
        }
    }
}
