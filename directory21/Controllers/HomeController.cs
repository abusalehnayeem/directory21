using System.Linq;
using System.Web;
using System.Web.Mvc;
using directory21.Service.CategoriesService;
using directory21.Service.ResourcesService;

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
            //var homeViewModel = new HomeViewModel();
            //var httpModule = HttpContext.ApplicationInstance;

            //var httpModuleCollection = httpModule.Modules;
            //ViewBag.ModuleCount = httpModuleCollection.Count;

            //var res = _resourcesService.GetAllResources().ToList();
            return View();
        }

        public ActionResult Resource(int id)
        {
            //var cat = _categoriesService.GetCategoriesByResourcesId(id);
            return View();
        }
    }
}