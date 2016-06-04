using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace directory21.Core.Domain
{
    public class Categories:BaseEntity
    {
        public string CategotyName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual Resources Resources { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
