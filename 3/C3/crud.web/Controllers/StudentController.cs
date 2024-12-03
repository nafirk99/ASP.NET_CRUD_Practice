using crud.web.Data;
using crud.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace crud.web.Controllers
{
    public class StudentController : Controller
    {
        readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddViewModel model) 
        {
            var student = new Student
            {
                Name = model.Name,
                Email = model.Email,
                Subscribed = model.Subscribed,
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var student = _context.Students.ToList();
            return View(student);
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            var student = _context.Students.Find(model.Id);
            if (student is not null)
            {
                student.Name = model.Name;
                student.Email = model.Email;
                student.Subscribed = model.Subscribed;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(List));
        }
        public IActionResult Delete(Guid id)
        {
            var student = _context.Students.Find(id);
            if (student is not null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(List));
        }
    }
}
