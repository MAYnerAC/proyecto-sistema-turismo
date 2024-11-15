using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Areas.Proveedor
{
    public class ProveedorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Proveedor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Proveedor_default",
                "Proveedor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}