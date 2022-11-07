using VistoriaDeVeiculos.Models.Enums;

namespace VistoriaDeVeiculos.Models.ViewModels
{
    public class DadosDoFormularioViewModel
    {
        public string PeriodicaSemanal { get; set; }
        public EnumDeTranferencia TipoDeTransferencia { get; set; }
        public string Obra { get; set; }
        public string DataDaInspecao { get; set; }
        public string NumeroDoFormulario { get; set; }
    }
}
