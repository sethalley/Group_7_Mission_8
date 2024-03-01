using Group_7_Mission_8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Group_7_Mission_8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ToDosContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //Here is the controller code for the task form page. First the page should be displayed
        //there must be a submission class/model to store the data gathered from the form
        //then using a 'post' method the data will be added and saved to the database
        //NOTES: There must be a CONTEXT FILE and there must be a SUBMISSION class that records the data
        public IActionResult TaskForm()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View("TaskForm", new ToDo());
        }

        [HttpPost]
        public IActionResult TaskForm(ToDo response)
        {
            if (ModelState.IsValid)
            {
                // Save submission to the database or perform other operations
                _context.ToDo.Add(response);
                _context.SaveChanges();

                // Redirect to a confirmation page
                return RedirectToAction("List");
            }
            else
            {
                return View(response);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

        // This is the code for the controllers fro the index page that will ultimately become the quadrant page
        //This first portion routes to the index page and takes the objects of type Submissions and makes them a list
        //This will have to be adapted to fit the needs of the new database created by Sarah, as well as the quadrant view
        //that will be created by Tristan
        public IActionResult Index()
        {
            var submissions = _context.ToDos.ToList();
            return View(submissions);
        }

        //The controller that redirects to the view in which the record can be edited
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.ToDos.FirstOrDefault(ToDo => ToDo.TaskId == id);
            if (recordToEdit == null)
                return NotFound();
            ViewBag.Categories = _context.Categories.ToList();
            return View("TaskForm", recordToEdit);
        }

        //The post method that will actually fulfill the edits made by the user and apply them to the database
        //note: on form submission
        [HttpPost]
        public IActionResult Edit(ToDo updatedToDo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedToDo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View("TaskForm", updatedToDo);
        }

        //The get method that will allow for the delete function to work, additionally this will reroute to a deletion
        //confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.ToDo.FirstOrDefault(ToDo => ToDo.TaskId == id);
            if (recordToDelete == null)
                return NotFound();
            return View(recordToDelete);
        }
    }
}
