using Bugaltery.Data;
using Bugaltery.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bugaltery.Controller;

[ApiController]
[Route("api/[controller]")]
public class ResidentController : ControllerBase
{
    private DataDbContext db;

    public ResidentController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }
    
    [HttpPost]
    public ActionResult<Resident> Post(Resident resident)
    {
        db.Residents.Add(resident);
        db.SaveChanges();
        return Ok(resident);
    }


    [HttpGet]
    public ActionResult<IEnumerable<Resident>> Get(string? name, string? surname)
    {
        var search = db.Residents.AsQueryable();
        if (name != null)
        {
            search = search.Where(x => EF.Functions.ILike(x.Name, $"%{name}%"));
        }

        if (surname != null)
        {
            search = search.Where(x => EF.Functions.ILike(x.Surname, $"%{surname}%"));
        }

        var nat = search.ToList();
        return Ok(nat);
    }


    [HttpPut("{id}")]
    public ActionResult<Resident> Put(int id, [FromBody] Resident resident)
    {
        if (resident == null)
        {
            NotFound();
        }

        var old_resident = db.Residents.Find(id);

        if (old_resident == null)
        {
            return NotFound();
        }

        old_resident.Name = resident.Name;
        old_resident.Surname = resident.Surname;
        old_resident.AddressId = resident.AddressId;
        db.SaveChanges();
        return Ok(resident);
    }

    [HttpDelete("{id}")]
    public ActionResult<Resident> Delete(int id)
    {
        var del_resident = db.Residents.Find(id);
        db.Residents.Remove(del_resident);
        db.SaveChanges();
        return Ok();
    }

}