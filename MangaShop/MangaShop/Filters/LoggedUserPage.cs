﻿using MangaShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Net.Mime;

namespace MangaShop.Filters
{
    public class LoggedUserPage : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("LoggedUserSession");

            if (string.IsNullOrEmpty(userSession)) 
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            } else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });

                }
            }
            base.OnActionExecuting(context);
        }
    }
}
