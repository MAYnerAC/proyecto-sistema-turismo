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
    /// <summary>
    /// Controlador encargado de la autenticación de usuarios y el registro.
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// Muestra la vista de inicio de sesión.
        /// </summary>
        /// <returns>Vista del login</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Procesa los datos del formulario de login.
        /// Valida al usuario y redirige según el tipo de usuario.
        /// </summary>
        /// <param name="usuarios">Objeto Usuario con credenciales ingresadas</param>
        /// <returns>Redirección o vista de login con mensaje</returns>
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

        /// <summary>
        /// Valida si el usuario ingresado es correcto según la lógica del modelo.
        /// </summary>
        /// <param name="usuarios">Usuario con las credenciales ingresadas</param>
        /// <returns>True si es válido, false si no</returns>
        private bool IsValid(Usuario usuarios)
        {
            return usuarios.Autenticar();
        }

        /// <summary>
        /// Cierra sesión del usuario y lo redirige al inicio.
        /// </summary>
        /// <returns>Redirección a la vista de inicio</returns>
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Muestra la vista de registro de nuevos usuarios.
        /// </summary>
        /// <returns>Vista de registro</returns>
        public ActionResult Registro()
        {
            return View();
        }

        /// <summary>
        /// Procesa el formulario de registro de usuario.
        /// </summary>
        /// <param name="usuario">Usuario a registrar</param>
        /// <returns>Redirección al login o vista con mensaje</returns>
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