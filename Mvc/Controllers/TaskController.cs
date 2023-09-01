using Dal.Interfaces;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers;

public class TaskController : Controller
{
    private readonly ICrudRepository<TaskItem, int> _taskRepository;
    private readonly ICrudRepository<Project, int> _projectRepository;

    public TaskController(ICrudRepository<TaskItem, int> taskRepository, ICrudRepository<Project, int> projectRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public IActionResult Index()
    {
        return View(_taskRepository.GetAll());
    }

    public IActionResult Details(int id)
    {
        TaskItem? project = _taskRepository.GetById(id);
        return View(project);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        task.IsDone = false;
        task.Project = _projectRepository.GetById(1);
        _taskRepository.Add(task);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        TaskItem? task = _taskRepository.GetById(id);
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(TaskItem task)
    {
        _taskRepository.Update(task);
        return RedirectToAction("Details", task);
    }

    public IActionResult Delete(int id)
    {
        _taskRepository.Delete(id);
        return RedirectToAction("Index");
    }
}