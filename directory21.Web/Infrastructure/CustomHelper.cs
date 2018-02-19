using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace directory21.Web.Infrastructure
{
    public static class CustomHelper
    {
        public static HtmlEmpyEnd ListView<T>(this HtmlHelper html,
            string heading, string id, List<T> model) where T : class
        {
            //boxClass = "box " + boxClass + " box-solid";
            //html.ViewContext.Writer.Write(
            //    "<div class=\"" +
            //    boxClass +
            //    "\">" +
            //    "<div class=\"box-header with-border\">" +
            //    "<h3 class=\"box-title\">" +
            //    heading +
            //    "</h3>" +
            //    "<div class=\"box-tools pull-right\">" +
            //    "<button type=\"button\" class=\"btn btn-box-tool\" data-widget=\"collapse\"><i class=\"fa fa-minus\"></i></button>" +
            //    "</div>" +
            //    "</div>" +
            //    "<div class=\"box-body\">"
            //);
            var sb = new StringBuilder();

            sb.Append("<div id=\""+id+"\">\n");
            sb.Append("<h4>" + heading + "</h4>\n");
            sb.Append("<ul>");
            foreach(var item in model)
            {
                sb.Append("<li><a href=\"#\">"+model+"</a></li>");
            }
            sb.Append("</ul>\n");
            html.ViewContext.Writer.Write(sb.ToString());
            return new HtmlEmpyEnd(html.ViewContext);
        }
    }
}