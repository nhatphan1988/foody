﻿using Foody.Controllers;
using Foody.Filters;
using System.Web;
using System.Web.Mvc;

namespace Foody
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggingFilterAttribute());
        }
    }
}