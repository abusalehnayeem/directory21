using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace directory21.Core.Domain
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        //public DateTime EntryDate { get; set; }
        //public DateTime UpdateDate { get; set; }
    }
}
