using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers;

[ApiController]
[Route("/animals-controller")]
// [Route("[controller]")]
public class AnimalsController : ControllerBase
{
    private MockDb _db = new MockDb();
    
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _db.Animals;
        return Ok(animals);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animals = _db.Animals;
        if (id < animals.Count)
        {
            return NotFound();
        }
        return Ok(animals[id]);
    }
    
    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        _db.Animals.Add(animal);
        return Created();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal animal){
        var existingAnimal = _db.Animals.FirstOrDefault(a => a.Id == id);
        if(existingAnimal == null){
            return NotFound();
        }
        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.Color = animal.Color;
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToRemove = _db.Animals.FirstOrDefault(a => a.Id == id);
        if (animalToRemove == null)
        {
            return NotFound();
        }

        _db.Animals.Remove(animalToRemove);
        return NoContent();
    }

}