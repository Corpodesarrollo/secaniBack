using MSSeguimiento.Core.Modelos.Common;

namespace MSSeguimiento.Core.Modelos
{
    public class Alerta : BaseEntity
    {
        public int SubcategoriaId { get; set; }
        public string Descripcion { get; set; }
        public char Alias { get; set; }
    }
}
