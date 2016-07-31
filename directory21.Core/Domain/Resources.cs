using System;
using System.Collections.Generic;

namespace directory21.Core.Domain
{
    public class Resources : BaseEntity
    {
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
    }

}
