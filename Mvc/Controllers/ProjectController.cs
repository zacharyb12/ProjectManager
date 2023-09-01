using Dal.Interfaces;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers;

public class ProjectController : Controller
{
    private readonly ICrudRepository<Project, int> _projectRepository;
    private readonly ICrudRepository<User, int> _userRepository;

    public ProjectController(ICrudRepository<Project, int> projectRepository, ICrudRepository<User, int> userRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View(_projectRepository.GetAll());
    }

    public IActionResult Details(int id)
    {
        Project? project = _projectRepository.GetById(id);
        return View(project);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Project project)
    {
        project.CreatedAt = DateTime.Now;
        project.User = _userRepository.GetById(1);
        _projectRepository.Add(project);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        Project? project = _projectRepository.GetById(id);
        return View(project);
    }

    [HttpPost]
    public IActionResult Edit(Project project)
    {
        _projectRepository.Update(project);
        return RedirectToAction("Details", project);
    }

    public IActionResult Delete(int id)
    {
        _projectRepository.Delete(id);
        return RedirectToAction("Index");
    }
}