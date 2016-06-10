using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace directory21.Core.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
