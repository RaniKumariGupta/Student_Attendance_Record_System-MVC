using Microsoft.AspNetCore.Mvc;
using Student_Attendance_Record_SysteM.Models;
using System.Linq; 
using System.Collections.Generic;
using Microsoft.Extensions.Logging; 

namespace Student_Attendance_Record_SysteM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Subjects = new List<string> { " Science", "Math", "English" };
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                student.IsPresent = true;
                _context.Student.Add(student); 
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.Subjects = new List<string> { "Science", "Math", "English" };
            return View(student);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /* [HttpPost]
         public IActionResult Login(User user)
         {
             var existingUser = _context.User.FirstOrDefault(u => u.StudentName == user.StudentName && u.Password == user.Password);

             if (existingUser != null)
             {
                 // Log for debugging
                 _logger.LogInformation($"User {existingUser.StudentName} logged in successfully.");

                 // Redirect to dashboard
                 return RedirectToAction("Dashboard");
             }

             ModelState.AddModelError("", "Invalid login attempt.");
             return View(user);
         }*/
        [HttpPost]
        public IActionResult Login(User user)
        {
            var existingUser = _context.User.FirstOrDefault(u => u.StudentName == user.StudentName && u.Password == user.Password);

            if (existingUser != null)
            {
                // Log for debugging
                _logger.LogInformation($"User {existingUser.StudentName} logged in successfully.");

                // Update attendance status
                var student = _context.Student.FirstOrDefault(s => s.StudentName == existingUser.StudentName);
                if (student != null)
                {
                    student.IsPresent = true; // Set attendance status during login
                    _context.SaveChanges();
                }

                // Redirect to dashboard
                return RedirectToAction("Dashboard","Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(user);
        }



        public IActionResult Dashboard(string subjectFilter, string levelFilter)
        {
            // Get the students based on subject and level filters
            var students = _context.Student.AsQueryable();

            if (!string.IsNullOrEmpty(subjectFilter))
            {
                students = students.Where(s => s.Subject == subjectFilter);
            }

            if (!string.IsNullOrEmpty(levelFilter))
            {
                students = students.Where(s => s.Level == levelFilter);
            }

            // Pass the subject and level filter values to the view
            ViewBag.SubjectFilter = subjectFilter;
            ViewBag.LevelFilter = levelFilter;

            return View(students.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            // Populate subjects dropdown list
            ViewBag.Subjects = new List<string> { "Science", "Math", "English" };
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Student.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            ViewBag.Subjects = new List<string> { "Science", "Math", "English" };
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

    }
}
