using System.Collections.Generic;

namespace VistoriaDeVeiculos.Models.Entities
{
    public class FormularioDeInspecao
    {
        public int Id { get; set; }
        public DadosDoFormulario DadosDoFormulario { get; set; }
        public Veiculo DadosDoVeiculo { get; set; }
        public Motorista DadosDoMotorista { get; set; }
        public ICollection<Pergunta> Perguntas { get; set; }
    }
}
