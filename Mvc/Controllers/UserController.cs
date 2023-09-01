using Dal.Interfaces;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers;

public class UserController : Controller
{
    private readonly ICrudRepository<User, int> _userRepository;

    public UserController(ICrudRepository<User, int> userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View(_userRepository.GetAll());
    }

    public IActionResult Details(int id)
    {
        User? user = _userRepository.GetById(id);
        return View(user);
    }



    public IActionResult Create()
    {
        User user = new User();
        return View(user);
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }
        _userRepository.Add(user);
        TempData["Toast"] = "User Created";
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        User? user = _userRepository.GetById(id);
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }
        _userRepository.Update(user);
        return RedirectToAction("Details", new {id = user.Id});
        // return RedirectToAction("Details", user);
    }

    public IActionResult Delete(int id)
    {
        _userRepository.Delete(id);
        TempData["Toast"] = "User deleted";
        return RedirectToAction("Index");
    }
}