using VistoriaDeVeiculos.Models.Enums;

namespace VistoriaDeVeiculos.Models.Entities
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public EnumDeResposta TipoDeResposta { get; set; }

        public int FormularioId { get; set; }
        public FormularioDeInspecao FormularioDeInspecao { get; set; }
    }
}
