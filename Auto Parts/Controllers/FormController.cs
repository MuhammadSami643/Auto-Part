using Auto_Parts.Models;
using Auto_Parts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Parts.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDBContext context;

        public FormController(ApplicationDBContext context, IWebHostEnvironment environment)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var form=context.Form.OrderByDescending(p=>p.Name).ToList();
            return View(form);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(FormDto formdto)
        {
            return View(formdto);
        }

        Form form = new Form()
        {
            Name = FormDto.Name,
        };

     
    }
}
