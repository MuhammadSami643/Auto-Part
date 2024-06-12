using Auto_Parts.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Mono.TextTemplating;
using Auto_Parts.Models;

namespace Auto_Parts.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDBContext context;
        private readonly IWebHostEnvironment environment;

        public FormController(ApplicationDBContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {

            var form = context.Form.OrderByDescending(p => p.Name).ToList();
            return View(form);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FormDto formdto)
        {
            Form form = new Form()
            {
                Name = FormDto.Name,
                Email = formdto.Email,
                Age = formdto.Age,
                Password = formdto.Password,


            };

            context.Form.Add(form);
            context.SaveChanges();

            return RedirectToAction("Index", "Form");
        }

        public IActionResult Edit(String Name)
        {
            var formdto = context.Form.Find(Name);

            if (formdto == null)
            {
                return RedirectToAction("Index", "Form");
            }

            var formdt = new FormDto()
            {
                /*Name = FormDto.Name,*/
                Email = formdto.Email,
                Age = formdto.Age,
                Password = formdto.Password,
            };

          
            return View(formdto);
        }

        [HttpPost]
        public IActionResult Edit(String Name, FormDto formDto)
        {
            var form = context.Form.Find(Name);
            if (form == null)
            {
                return RedirectToAction("Index", "Form");

            }
            // update the data.
            form.Name = FormDto.Name;
            form.Email = formDto.Email;
            form.Age = formDto.Age;
            form.Password = formDto.Password;

            context.SaveChanges();
            return RedirectToAction("Index", "Form");


        }

        public IActionResult Delete(String Name)
        {
            var form = context.Form.Find(Name);
            if (form == null)
            {
                return RedirectToAction("Index", "Form");
            }

            context.Form.Remove(form);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Form");
        }
    }
}
