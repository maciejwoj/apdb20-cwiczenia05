using Tutorial4.Models;

namespace Tutorial4.Database;

public class MockDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Visit> Visits{ get; set; } = new List<Visit>();

    public MockDb()
    {
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Visits.Add(new Visit());
        Visits.Add(new Visit());
        Visits.Add(new Visit());
    }
}