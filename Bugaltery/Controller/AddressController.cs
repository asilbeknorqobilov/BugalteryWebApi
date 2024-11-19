using Bugaltery.Data;
using Bugaltery.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bugaltery.Controller;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private DataDbContext db;

    public AddressController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }

    [HttpPost]
    public ActionResult<Address> Post(Address address)
    {
        db.Addresses.Add(address);
        db.SaveChanges();
        return Ok(address);
    }


    [HttpGet]
    public ActionResult<IEnumerable<Address>> Get(string? district, string? quarter, int? buliding, int? apartment)
    {
        var search = db.Addresses.AsQueryable();
        if (district != null)
        {
            search = search.Where(x => EF.Functions.ILike(x.District, $"%{district}%"));
        }

        if (quarter != null)
        {
            search = search.Where(x => EF.Functions.ILike(x.Quarter, $"%{quarter}%"));
        }

        if ((buliding != null) && (buliding > 0))
        {
            search = search.Where(x => x.Building == buliding);
        }

        if ((apartment != null) && (apartment > 0))
        {
            search = search.Where(x => x.Apartment == apartment);
        }

        var nat = search.ToList();
        return Ok(nat);
    }


    [HttpPut("{id}")]
    public ActionResult<Address> Put(int id, [FromBody] Address address)
    {
        if (address == null)
        {
            NotFound();
        }

        var old_adress = db.Addresses.Find(id);

        if (old_adress == null)
        {
            return NotFound();
        }

        old_adress.District = address.District;
        old_adress.Quarter = address.Quarter;
        old_adress.Building = address.Building;
        old_adress.Apartment = address.Apartment;
        old_adress.OwnerId = address.OwnerId;
        db.SaveChanges();
        return Ok(address);
    }

    [HttpDelete("{id}")]
    public ActionResult<Address> Delete(int id)
    {
        var del_owner = db.Addresses.Find(id);
        db.Addresses.Remove(del_owner);
        db.SaveChanges();
        return Ok();
    }
}