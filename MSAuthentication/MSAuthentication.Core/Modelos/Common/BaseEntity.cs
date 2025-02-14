﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAuthentication.Core.Modelos.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string CreatedByUserId { get; set; }
        public string? UpdatedByUserId { get; set; }
        public string? DeletedByUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
