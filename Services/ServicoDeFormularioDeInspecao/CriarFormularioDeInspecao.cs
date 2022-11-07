using System;
using System.Collections.Generic;
using VistoriaDeVeiculos.DataContext;
using VistoriaDeVeiculos.Models.Entities;

namespace VistoriaDeVeiculos.Services.ServicoDeFormularioDeInspecao
{
    public class CriarFormularioDeInspecao
    {
        private readonly Contexto contexto;

        public CriarFormularioDeInspecao(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public Guid Executar()
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

            return novoFormularioDeInspecao.Id;
        }
    }
}
