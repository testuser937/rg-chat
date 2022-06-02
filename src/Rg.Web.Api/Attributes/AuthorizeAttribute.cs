using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rg.Web.Api.Models;

namespace Rg.Web.Api.Attributes;

// [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
// public class AuthorizeAttribute : Attribute, IAuthorizationFilter
// {
//     public void OnAuthorization(AuthorizationFilterContext context)
//     {
//         if (context.HttpContext.Items["User"] is not User)
//         {
//             context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
//             context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = HttpStatusCode.Unauthorized.ToString();
//             context.Result = new JsonResult(HttpStatusCode.Unauthorized.ToString())
//             {
//                 Value = new
//                 {
//                     Message = "Token validation failed"
//                 }
//             };
//         }
//     }
// }