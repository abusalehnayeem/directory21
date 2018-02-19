using System;
using System.Collections;
using System.Collections.Generic;
using directory21.Core.Domain;

namespace directory21.Web.ViewModels
{
    public class HomeViewModel : IEnumerable
    {
        public string ResourceName { get; set; }
        public int CategoriesCount { get; set; }
        public ICollection<Categories> Categorieses { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}