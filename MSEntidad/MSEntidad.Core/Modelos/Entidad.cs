using MSEntidad.Core.Modelos.Common;

namespace MSEntidad.Core.Modelos
{
    public class Entidad : BaseEntity
    {
        public int TipoEntidadId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<ContactoEntidad> ContactosEntidad { get; set; }
    }
}
