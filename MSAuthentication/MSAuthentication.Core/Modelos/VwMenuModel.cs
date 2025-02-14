﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSAuthentication.Core.Modelos

{
    [Table("VwMenu")]
    public class VwMenuModel
    {        
        public int PermisoId { get; set; }
        public int ModuloId { get; set; }
        public int ModuloIdPadre { get; set; }
        public string Menu { get; set; }
        public string MenuPath { get; set; }
        public string SubMenu { get; set; }
        public string SubMenuPath { get; set; }
        public string Rol { get; set; }
        public string RolId { get; set; }
        public string ModuloTipo { get; set; }
        public int ModuloTipoId { get; set; }
        public int MenuOrden { get; set; }
        public int SubMenuOrden { get; set; }
    }
}
