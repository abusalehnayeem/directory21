using System.Web.Mvc;

namespace directory21.Web.Infrastructure
{
    public static class CustomHelper
    {
        public static HtmlEmpyEnd DefaultBox(this HtmlHelper html,
            string heading, string boxClass = "box-default")
        {
            boxClass = "box " + boxClass + " box-solid";
            html.ViewContext.Writer.Write(
                "<div class=\"" +
                boxClass +
                "\">" +
                "<div class=\"box-header with-border\">" +
                "<h3 class=\"box-title\">" +
                heading +
                "</h3>" +
                "<div class=\"box-tools pull-right\">" +
                "<button type=\"button\" class=\"btn btn-box-tool\" data-widget=\"collapse\"><i class=\"fa fa-minus\"></i></button>" +
                "</div>" +
                "</div>" +
                "<div class=\"box-body\">"
            );

            return new HtmlEmpyEnd(html.ViewContext);
        }
    }
}