using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Filters
{
    public class ManejoErroresFiltroAttribute : ActionFilterAttribute
    {

        // Se ejecuta antes de la action
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;

            // Validar si el modelo es valido
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                controller.TempData["Error"] = "Por favor corrige los errores del formulario.";

                filterContext.Result = new ViewResult
                {
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData,
                    ViewName = filterContext.ActionDescriptor.ActionName
                };
            }
        }

        // Se ejecuta despues de la action
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller as Controller;

            // Manejar excepciones no controladas
            if (filterContext.Exception != null)
            {
                controller.TempData["Error"] = "Ocurrió un error inesperado. Por favor intenta nuevamente.";

                // Marcar la excepcion como manejada
                filterContext.ExceptionHandled = true;
                    
                // Redirigir
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                    { "controller", "Error" },
                    { "action", "General" }
                    }
                );
            }
        }






        //
    }
}