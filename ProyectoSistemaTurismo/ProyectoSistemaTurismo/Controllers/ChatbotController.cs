using ProyectoSistemaTurismo.WSChatbot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaTurismo.Controllers
{
    public class ChatbotController : Controller
    {
        private WSChatbot.WebService1SoapClient ws = new WSChatbot.WebService1SoapClient();

        // GET: Chatbot
        public ActionResult Index()
        {
            return View();
        }

        // Acción para procesar la consulta del usuario desde el formulario
        [HttpPost]
        public ActionResult GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                ViewBag.ErrorMessage = "Por favor, ingresa una pregunta.";
                return View("Index");
            }

            try
            {
                // Crear una instancia del cliente del servicio web
                var client = new WebService1SoapClient();

                // Llamar al método que interactúa con el chatbot
                var result = client.InteractuarConChatbot(userInput);

                // Pasar la respuesta del chatbot a la vista
                ViewBag.ChatbotResponse = result;
            }
            catch (Exception ex)
            {
                // Manejo de errores si algo falla
                ViewBag.ErrorMessage = "Hubo un error al procesar tu solicitud: " + ex.Message;
            }

            // Devolver la vista con la respuesta del chatbot
            return View("Index");
        }


        //
    }
}

/*
 
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTAPI.Controllers
{
    public class ChatbotController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Muestra la vista donde el usuario puede ingresar una consulta
        }

        [HttpPost]
        public async Task<IActionResult> ConsultarChatGPT(string query)
        {
            // Lógica para llamar a la API y obtener la respuesta
            var response = await GetChatGPTResponse(query);
            ViewData["Response"] = response;
            return View("Index");
        }

        private async Task<string> GetChatGPTResponse(string query)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync($"https://localhost:5001/api/chat/UseChatGPT?query={query}");
                return response;
            }
        }
    }
} 

 */