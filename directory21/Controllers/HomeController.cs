using System.Linq;
using System.Web.Mvc;
using directory21.Service.ResourcesService;

namespace directory21.Controllers
{
    public class HomeController : Controller
    {
        //private IRepository<Resources> _repository;
        private readonly IResourcesService _resourcesService;
        //private readonly ICategoriesService _categoriesService;
        public HomeController(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
            //_categoriesService = categoriesService;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            //var homeViewModel = new HomeViewModel();
            var res = _resourcesService.GetAllResources().ToList();
            return View(res);
        }
    }
}