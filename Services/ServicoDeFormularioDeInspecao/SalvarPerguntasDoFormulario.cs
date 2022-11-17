using System;
using System.Collections.Generic;
using VistoriaDeVeiculos.DataContext;
using VistoriaDeVeiculos.Models.Entities;
using VistoriaDeVeiculos.Models.ViewModels;

namespace VistoriaDeVeiculos.Services.ServicoDeFormularioDeInspecao
{
    public class SalvarPerguntasDoFormulario
    {
        private readonly Contexto contexto;

        public SalvarPerguntasDoFormulario(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void Executar(ICollection<PerguntaViewModel> perguntasViewModel, string formularioId)
        {
            foreach (var perguntaVm in perguntasViewModel)
            {
                var pergunta = new Pergunta()
                {
                    Id = perguntaVm.Id,
                    Titulo = perguntaVm.Titulo,
                    TipoDeResposta = perguntaVm.TipoDeResposta,
                    FormularioId = Guid.Parse(formularioId),
                };

                contexto.Update(pergunta);
            }

            contexto.SaveChanges();
        }
    }
}
