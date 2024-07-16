using MSSeguimiento.Core.Modelos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Modelos
{
    public class Plantilla : BaseEntity
    {
        public string Headerjpg { get; set; }
        public string Footerjpg { get; set; }
        public long ConfigurationEmailId { get; set; }

    }
}
