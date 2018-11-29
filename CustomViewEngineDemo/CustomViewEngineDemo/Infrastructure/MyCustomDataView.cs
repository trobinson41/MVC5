﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomViewEngineDemo.Infrastructure
{
    public class MyCustomDataView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            Write(writer, "--Routing Data--");
            foreach (string key in viewContext.RouteData.Values.Keys)
            {
                Write(writer, $"Key: {key}, Value: {viewContext.RouteData.Values[key]}");
            }

            Write(writer, "--View Data--");
            foreach (string key in viewContext.ViewData.Keys)
            {
                Write(writer, $"Key: {key}, Value: {viewContext.ViewData[key]}");
            }
        }

        private void Write(TextWriter writer, string s)
        {
            writer.Write(s + "<p />");
        }
    }
}