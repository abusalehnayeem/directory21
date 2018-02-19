using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace directory21.Web.Infrastructure
{
    public class HtmlEmpyEnd : IDisposable
    {
        private readonly ViewContext _viewContext;
        public HtmlEmpyEnd(ViewContext viewContext)
        {
            _viewContext = viewContext;
        }
        public void Dispose()
        {
            _viewContext.Writer.Write("</div>");
        }
    }
}