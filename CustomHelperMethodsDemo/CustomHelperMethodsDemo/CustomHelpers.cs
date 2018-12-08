using CustomHelperMethodsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomHelperMethodsDemo
{
    public static class CustomHelpers
    {
        public static MvcHtmlString ListPlayers(this HtmlHelper html, IEnumerable<Person> people)
        {
            TagBuilder tag = new TagBuilder("ul");

            foreach (Person p in people)
            {
                TagBuilder itemTag = new TagBuilder("li");

                itemTag.SetInnerText(p.FirstName);

                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }
    }
}