using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Filters
{
    public class OfertaSeleccionadaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["OfertaId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                    { "controller", "Oferta" },
                    { "action", "MisOfertas" },
                    { "area", "Proveedor" }
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}