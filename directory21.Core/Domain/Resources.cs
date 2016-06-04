using System;

namespace directory21.Core.Domain
{
    public class Resources : BaseEntity
    {
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public virtual Categories Categories { get; set; }
    }

}
