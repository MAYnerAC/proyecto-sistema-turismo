using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuarios)
        {
            if (IsValid(usuarios))
            {
                // Obtener datos completos del usuario autenticado
                Usuario usuarioAutenticado = usuarios.ObtenerDatos(usuarios.email);

                // Verifica si el usuario autenticado es válido
                if (usuarioAutenticado != null)
                {
                    // Almacenar información en la sesión
                    Session["id_usuario"] = usuarioAutenticado.id_usuario;
                    Session["nombre_usuario"] = usuarioAutenticado.nombre;
                    Session["correo_usuario"] = usuarioAutenticado.email;
                    Session["tipo_usuario"] = usuarioAutenticado.Tipo_Usuario.nombre_tipo;
                    Session["id_tipo_usuario"] = usuarioAutenticado.id_tipo_usuario; // 1 = Admin, 2 = Proveedor, 3 = Turista

                    // Redirige según el tipo de usuario
                    int tipoUsuario = usuarioAutenticado.id_tipo_usuario;
                    if (tipoUsuario == 1) // Admin
                    {
                        return RedirectToAction("Index", "Panel", new { area = "Admin" });
                    }
                    else if (tipoUsuario == 2) // Proveedor
                    {
                        return RedirectToAction("Index", "Panel", new { area = "Proveedor" });
                    }
                    else // Turista
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }
                else
                {
                    TempData["mensaje"] = "Error al obtener los datos del usuario autenticado.";
                    return View(usuarios);
                }
            }

            TempData["mensaje"] = "Correo o contraseña incorrectos";
            return View(usuarios);
        }


        // Método para validar el usuario
        private bool IsValid(Usuario usuarios)
        {
            return usuarios.Autenticar();
        }


        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }






        public ActionResult Registro()
        {
            return View();
        }

        // Registro de Usuario
        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                bool usuarioRegistrado = usuario.RegistrarUsuario();

                if (usuarioRegistrado)
                {
                    TempData["mensaje"] = "Usuario registrado exitosamente.";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    TempData["mensaje"] = "Hubo un problema al registrar el usuario.";
                }
            }

            return View(usuario);
        }









        //
    }
}