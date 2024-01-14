﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace System.Data.Entities
{
    public class Device : Entity
    {
        [Key]
        public int DeviceId { get; set; }
        public string Location { get; set; }

        [ForeignKey("SystemId")]
        public int? SystemId { get; set; }
        public virtual System System { get; set; }
    }
}
