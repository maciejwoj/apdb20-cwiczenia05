using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers;

[ApiController]
[Route("/visits-controller")]
// [Route("[controller]")]

public class VisitController : ControllerBase
{
    private readonly MockDb _db;

    public VisitController(MockDb db)
    {
        _db = db;
    }

    [HttpGet("animal/{animalId}")]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        var visits = _db.Visits.Where(v => v.AnimalId == animalId).ToList();
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        _db.Visits.Add(visit);
        return CreatedAtAction(nameof(GetVisit), new { id = visit.Id }, visit);
    }

    [HttpGet("{id}")]
    public IActionResult GetVisit(int id)
    {
        var visit = _db.Visits.FirstOrDefault(v => v.Id == id);
        if (visit == null)
            return NotFound();

        return Ok(visit);
    }
}