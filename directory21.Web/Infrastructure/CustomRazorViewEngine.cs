using System.Linq;
using System.Web.Mvc;

namespace directory21.Web.Infrastructure
{
    public class CustomRazorViewEngine : RazorViewEngine
    {
        private readonly string _extension;

        public CustomRazorViewEngine(string viewTypeExtension)
        {
            _extension = viewTypeExtension;
            AreaMasterLocationFormats = Filter(AreaMasterLocationFormats);
            AreaPartialViewLocationFormats = Filter(AreaPartialViewLocationFormats);
            AreaViewLocationFormats = Filter(AreaViewLocationFormats);
            FileExtensions = Filter(FileExtensions);
            MasterLocationFormats = Filter(MasterLocationFormats);
            PartialViewLocationFormats = Filter(PartialViewLocationFormats);
            ViewLocationFormats = Filter(ViewLocationFormats);
        }

        private string[] Filter(string[] source)
        {
            return source.Where(
                s =>
                    s.Contains(_extension)).ToArray();
        }
    }
}