﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSNNA.Core.Request
{
    public class ContactoNNARequest
    {
        public long NNAId { get; set; }
        public string Nombres { get; set; }
        public int ParentescoId { get; set; }
        public string Email { get; set; }
        public string Telefonos { get; set; }
        public string TelefnosInactivos { get; set; }
        public long Cuidador { get; set; }
    }
}
