        private readonly OfertaService _ofertaService = new OfertaService();

        public ActionResult Index()
        {
            var ofertas = _ofertaService.ObtenerTodos();
            return View(ofertas);
        }

        public ActionResult Detalles(int id)
        {
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("Index");
            }
            return View(oferta);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _ofertaService.Agregar(oferta);
                TempData["Mensaje"] = "Oferta creada con éxito.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Por favor corrige los errores del formulario.";
            return View(oferta);
        }

        public ActionResult Editar(int id)
        {
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("Index");
            }
            return View(oferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _ofertaService.Actualizar(oferta);
                TempData["Mensaje"] = "Oferta actualizada con éxito.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Por favor corrige los errores del formulario.";
            return View(oferta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            var oferta = _ofertaService.ObtenerPorId(id);
            if (oferta == null)
            {
                TempData["Error"] = "La oferta no fue encontrada.";
                return RedirectToAction("Index");
            }

            _ofertaService.Eliminar(id);
            TempData["Mensaje"] = "Oferta eliminada con éxito.";
            return RedirectToAction("Index");
        }