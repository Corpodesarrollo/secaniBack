﻿using MSEntidad.Core.Modelos;
using MSEntidad.Core.Modelos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEntidad.Core.DTOs
{
    public class ContactoEntidadResponse: BaseEntity
    {
        public long EntidadId { get; set; }
        public string Nombres { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefonos { get; set; }
        public Entidad Entidad { get; set; }
    }
}
