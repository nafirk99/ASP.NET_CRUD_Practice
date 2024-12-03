using crud.web.Data;
using crud.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
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
        public IActionResult Add(AddStudentViewModel model)
        {
            var student = new Student
            {
                Name = model.Name,
                Email= model.Email,
                Phone = model.Phone,
                Subscribed = model.Subscribed
            };

            _context.Add(student);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Edit(Guid id) 
        {
            var students = _context.Students.Find(id);
            return View(students);
        }
        [HttpPost]
        public IActionResult Edit(Student model) 
        {
            var student = _context.Students.Find(model.Id);
            if (student != null)
            {
                student.Name = model.Name;
                student.Email = model.Email;
                student.Phone = model.Phone;
                student.Subscribed = model.Subscribed;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(List));
        }
        public IActionResult Delete(Guid id) 
        {
            var student = _context.Students.Find(id);
            if (student != null) 
            {
               _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(List));
        }
    }
}
