using System.Collections.Generic;
using directory21.Core.Domain;

namespace directory21.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Resources> ResourcesList { get; set; }
        public IEnumerable<Categories> CategoriesList { get; set; }
    }
}