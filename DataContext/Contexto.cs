using Microsoft.EntityFrameworkCore;

namespace VistoriaDeVeiculos.DataContext
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        {
        }
    }
}
