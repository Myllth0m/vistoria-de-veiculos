using VistoriaDeVeiculos.Models.Enums;

namespace VistoriaDeVeiculos.Models.Entities
{
    public class Pergunta
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public EnumDeResposta TipoDeResposta { get; set; }
    }
}
