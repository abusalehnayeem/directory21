using System.Web.Mvc;
using directory21.Service.CategoriesService;
using directory21.Service.ResourcesService;

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
            var res=_resourcesService.GetAllResources();

            return View(res);
        }

        public ActionResult Resource(int id)
        {
            //var cat = _categoriesService.GetCategoriesByResourcesId(id);
            return View();
        }
    }
}