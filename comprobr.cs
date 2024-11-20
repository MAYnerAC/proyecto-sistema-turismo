using System;
using System.Web.Mvc;

public class ManejoErroresFiltroAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var controller = filterContext.Controller as Controller;

        // Validar el modelo antes de ejecutar la acción
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

    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var controller = filterContext.Controller as Controller;

        // Manejar excepciones no controladas
        if (filterContext.Exception != null)
        {
            controller.TempData["Error"] = "Ocurrió un error inesperado. Por favor intenta nuevamente.";
            
            // Marcar la excepción como manejada
            filterContext.ExceptionHandled = true;

            // Redirigir a la vista principal o cualquier otra vista
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary
                {
                    { "controller", filterContext.RouteData.Values["controller"] },
                    { "action", "Index" }
                }
            );
        }
    }
}
