using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using directory21.Core.Data;
using directory21.Core.Domain;
using directory21.Data;
using directory21.Service.CategoriesService;
using directory21.Service.ItemsService;
using directory21.Service.ResourcesService;
using directory21.ViewModels;

namespace directory21.Controllers
{
    public class HomeController : Controller
    {
        //private IRepository<Resources> _repository;
        private readonly IResourcesService _resourcesService;
        private readonly ICategoriesService _categoriesService;
        public HomeController(IResourcesService resourcesService, ICategoriesService categoriesService)
        {
            _resourcesService = resourcesService;
            _categoriesService = categoriesService;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {

            var homeViewModel=new HomeViewModel
            {
                Resource =_resourcesService.GetAllResources(),
                Categoty = _categoriesService.GetAllCategories()
            };

      
            return View(homeViewModel);
            //return View(_resourcesService.GetAllResources());
        }

        

    }
}
