using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEntidad.Core.Modelos.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public DateTime DateDeleted { get; set; } = DateTime.Now;
        public long CreatedByUserId { get; set; } = 0;
        public long UpdatedByUserId { get; set; } = 0;
        public long DeletedByUserId { get; set; } = 0;
        public bool IsDeleted { get; set; }
    }
}
