using Microsoft.AspNetCore.Mvc;
using Week6_TODO_APP.Models;
using Week6_TODO_APP.Utility;

namespace Week6_TODO_APP.Controllers
{
    public class TodoController : Controller
    {
        public readonly string connectionString = ConnectionString.CName;

         
        //Get: Todo
        public ActionResult Index()
        {
            IEnumerable<TodoModel> todoModels = todoDataAccessLayer.GetAllTodo();
            return View(todoModels);
        }

        //[HttpGet]
        //public async Task<IActionResult> Index(string Empsearch)
        //{
        //    ViewData["GerTodo"] = Empsearch;
        //    var empquery = from X in connectionString.todo select X;
        //    if (!string.IsNullOrWhiteSpace(Empsearch))
        //    {
        //        empquery = empquery.Where(x => x.TaskName.Contains(Empsearch) || x.Status.Countains(Empsearch));
        //    }
        //    return View(await empquery.AsNoTracking().ToListAysnc);
        //}


        //Get: Todo details
        public ActionResult Details(int id)
        {
            TodoModel todoModel = todoDataAccessLayer.GetTodoData(id);
            return View(todoModel);
        }

        //Get: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoModel todoModel)
        {
            try
            {
                //Todo: Add insert logic here
                todoDataAccessLayer.AddTodo(todoModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Get: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            TodoModel todoModel = todoDataAccessLayer.GetTodoData(id); 
            return View(todoModel);
        }

        //Get: Todo/Delete
        public ActionResult Delete(int id)
        {
            TodoModel todoModel = todoDataAccessLayer.GetTodoData(id);
            return View(todoModel);
        }

        //Post: Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TodoModel todoModel)
        {
            try
            {
                //Todo: Update logic
                todoDataAccessLayer.UpdateTodo(todoModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        //Get: Todo/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TodoModel todoModel)
        {
            try
            {
                //Todo: Add Delete Logic Here
                todoDataAccessLayer.DeleteTodo(todoModel.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        TodoDataAccessLayer todoDataAccessLayer = null;
        public TodoController()
        {
            todoDataAccessLayer = new TodoDataAccessLayer();
        }
    }
}
