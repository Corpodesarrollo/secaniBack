using MSAuthentication.Core.Modelos.Common;

namespace MSAuthentication.Core.Modelos
{
    public class Alerta : BaseEntity
    {
        public int SubcategoriaId { get; set; }
        public string Descripcion { get; set; }
        public char Alias { get; set; }
    }
}
