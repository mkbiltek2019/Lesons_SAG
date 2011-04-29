using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ChocoPlanet.HtmlHelpers
{
    public static class PagingHelpers
    {
        
        public static HtmlString PageLinks(this HtmlHelper html, int currentPage, int totalPage, Func<int, string> pageUrl)
        {
            HtmlString resultHtml;
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= totalPage; i++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", pageUrl(i));
                tagBuilder.InnerHtml = i.ToString();
                if (i == currentPage)
                    tagBuilder.AddCssClass("selected");
                result.AppendLine(tagBuilder.ToString());

            }
            resultHtml = new HtmlString(result.ToString());
            return resultHtml;
        }

    }
}