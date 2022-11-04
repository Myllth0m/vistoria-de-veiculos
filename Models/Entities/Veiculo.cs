namespace VistoriaDeVeiculos.Models.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string UltimaRevisao { get; set; }

        public int FormularioId { get; set; }
        public FormularioDeInspecao FormularioDeInspecao { get; set; }
    }
}
