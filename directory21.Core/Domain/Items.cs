using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace directory21.Core.Domain
{
    public class Items:BaseEntity
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int CategoriesId { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
