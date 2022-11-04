using System;

namespace VistoriaDeVeiculos.Models.Entities
{
    public class Motorista
    {
        public int Id { get; set; }
        public string Cnh { get; set; }
        public string Categoria { get; set; }

        public Guid FormularioId { get; set; }
        public FormularioDeInspecao FormularioDeInspecao { get; set; }
    }
}
