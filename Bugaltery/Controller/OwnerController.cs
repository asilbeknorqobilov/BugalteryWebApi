using Bugaltery.Data;
using Bugaltery.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bugaltery.Controller;

[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{
    private DataDbContext db;

    public OwnerController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }

    [HttpPost]
    public ActionResult<Owner> Post(Owner owner)
    {
        db.Owners.Add(owner);
        db.SaveChanges();
        return Ok(owner);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Owner>> Get(string? name, string? surname)
    {
        var search = db.Owners.AsQueryable();
        if (name != null)
        {
            search = search.Where(x => EF.Functions.ILike(x.Name, $"%{name}%"));
        }

        if (surname != null)
        {
            search = search.Where(s => EF.Functions.ILike(s.Surname, $"%{surname}%"));
        }

        var nat = search.ToList();
        return Ok(nat);
    }

    [HttpPut("{id}")]
    public ActionResult<Owner> Put(int id, Owner owner)
    {
        var old_owner = db.Owners.Find(id);
        if (owner != null)
        {
            NotFound();
        }

        old_owner.Name = owner.Name;
        old_owner.Surname = owner.Surname;
        db.SaveChanges();
        return Ok(owner);
    }

    [HttpDelete("{id}")]
    public ActionResult<Owner> Delete(int id)
    {
        var del_owner = db.Owners.Find(id);
        db.Owners.Remove(del_owner);
        db.SaveChanges();
        return Ok();
    }
}