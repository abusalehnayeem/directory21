using System.Linq;
using System.Web.Mvc;
using directory21.Service.CategoriesService;
using directory21.Service.ResourcesService;
using directory21.Web.ViewModels;

namespace directory21.Web.Controllers
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
            var res=_resourcesService.GetAllResources().Take(20);
            var cats = _categoriesService.GetAllCategories().Take(9);
            var model = new HomeViewModel
            {
                CategoriesList = cats,
                ResourcesList = res
            };
            return View(model);
        }

        public ActionResult Resource(int id)
        {
            //var cat = _categoriesService.GetCategoriesByResourcesId(id);
            return View();
        }
    }
}