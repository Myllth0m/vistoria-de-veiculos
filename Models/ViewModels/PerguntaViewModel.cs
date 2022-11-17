using VistoriaDeVeiculos.Models.Enums;

namespace VistoriaDeVeiculos.Models.ViewModels
{
    public class PerguntaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public EnumDeResposta TipoDeResposta { get; set; }
    }
}
