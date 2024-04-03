using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPractico.data;
using WebApplicationPractico.Models;
using WebApplicationPractico.Models.Entity;

namespace WebApplicationPractico.Controllers
{
    public class StudentController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {

            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = true

            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Student");
        }





        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var students = await dbContext.Students.FindAsync(id);
            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( Student viewModel)
        {
            var students = await dbContext.Students.FindAsync(viewModel.Id);
            if (students is not null)
            {
                students.Name = viewModel.Name;
                students.Email = viewModel.Email;
                students.Phone = viewModel.Phone;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List","Student");
        }


        //Eliminar Student
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var students = await dbContext.Students.FindAsync(id);
            if (students is not null)
            {
                students.Subscribed = false;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }

    }
}
