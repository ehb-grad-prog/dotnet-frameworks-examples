using HelloMVC.Data;
using HelloMVC.Entities;
using HelloMVC.Models.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloMVC.Controllers;

public class PeopleController : Controller
{
    public HelloMVCContext Context { get; }

    public PeopleController(HelloMVCContext context)
    {
        Context = context;
    }

    public IActionResult Index()
    {
        var people = Context.People.AsNoTracking();

        return View(people);
    }

    public IActionResult Show(long id)
    {
        var person = Context.People.FirstOrDefault(person => person.Id == id);

        if (person is null)
        {
            // person was not found in the database
            return NotFound();
        }

        return View(person);
    }

    public IActionResult Update(long id)
    {
        var person = Context.People.FirstOrDefault(person => person.Id == id);

        if (person is null)
        {
            // person was not found in the database
            return NotFound();
        }

        return View(new UpdatePersonModel
        {
            Id = id,
            Name = person.Name,
            Age = person.Age,
        });
    }

    [HttpPost]
    public IActionResult Update(UpdatePersonModel model)
    {
        long id = model.Id;
        var person = Context.People.FirstOrDefault(person => person.Id == id);

        if (person is null)
        {
            // person was not found in the database
            return NotFound();
        }

        if (ModelState.IsValid is false)
        {
            return View(model);
        }

        // data is valid.
        person.Name = model.Name;
        person.Age = model.Age ?? person.Age;
        Context.SaveChanges();

        return RedirectToAction("Show", new { id });
    }

    public IActionResult Delete(long id)
    {
        var person = Context.People.FirstOrDefault(person => person.Id == id);

        if (person is null)
        {
            return NotFound();
        }

        Context.People.Remove(person);
        Context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(CreatePersonModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }

        var person = new Person
        {
            Name = model.Name,
            Age = model.Age,
        };

        Context.People.Add(person);
        Context.SaveChanges();
        return RedirectToAction("Show", new { id = person.Id });
    }
}
