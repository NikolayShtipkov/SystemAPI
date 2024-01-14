﻿using System.ComponentModel.DataAnnotations;

namespace System.Data.Entities
{
    public abstract class Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
