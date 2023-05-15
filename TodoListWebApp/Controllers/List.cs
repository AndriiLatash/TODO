using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using TodoListWebApp.GraphQl;
using TodoListWebApp.Models;
using TodoListWebApp.Repository;
using TodoListWebApp.ViewModels;

namespace TodoListWebApp.Controllers
{
	public class List : Controller
	{
		IListRepository repo;
		public List(IListRepository r)
		{
			repo = r;
		}
		public IActionResult Index(TODOCreationViewModel viewModel)
		{
			viewModel.Categories = repo.GetCategories();
			viewModel.ToDoList = repo.GetList();
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Create(TODOCreationViewModel viewModel)
		{

			repo.Create(viewModel.CreateNewItem);
			return RedirectToAction("Index");

		}
		[HttpPost]
		public IActionResult CreateCategory(TODOCreationViewModel viewModel)
		{

			repo.CreateCategory(viewModel.CreateCategory);
			return RedirectToAction("Index");

		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			repo.Delete(id);
			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult Update(int id, TODOlist list)
		{
			var currentList = repo.GetStatus(id);
			currentList.Status = !currentList.Status;

			repo.Update(id, currentList);

			return RedirectToAction("Index");

		}
		[HttpPost]
		public IActionResult Change(string selectForm)
		{
			if (selectForm == "Sql")
			{
				return RedirectToAction("Index", "List");
			}
			else if (selectForm == "Xml")
			{
				return RedirectToAction("Index", "Xml");
			}
			return RedirectToAction("Index");
		}
		
	}
}
