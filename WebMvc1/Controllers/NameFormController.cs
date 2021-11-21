using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Models;

namespace WebMvc1.Controllers
{
    public class NameFormController : Controller
    {
        private readonly ILogger<NameFormController> _logger;

        public NameFormController(ILogger<NameFormController> logger)
        {
            _logger = logger;
        }

        public IActionResult DisplayName()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DisplayName(NameFormModel model)
        {
            if (ModelState.IsValid)
            {
                return View("ShowUserName", model);
            } else {
                return View(model);
            }
        }
    }
}