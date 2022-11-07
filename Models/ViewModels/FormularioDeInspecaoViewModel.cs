using System;
using System.Collections.Generic;

namespace VistoriaDeVeiculos.Models.ViewModels
{
    public class FormularioDeInspecaoViewModel
    {
        public Guid Id { get; set; }
        public DadosDoFormularioViewModel DadosDoFormulario { get; set; }
        public VeiculoViewModel DadosDoVeiculo { get; set; }
        public MotoristaViewModel DadosDoMotorista { get; set; }
        public ICollection<PerguntaViewModel> Perguntas { get; set; }
    }
}
