using Bugaltery.Data;
using Bugaltery.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bugaltery.Controller;


[ApiController]
[Route("api/[controller]")]
public class PaymentTypeController:ControllerBase
{
    private DataDbContext db;

    public PaymentTypeController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }

    [HttpPost]
    public ActionResult<PaymentType> Post(PaymentType paymentType)
    {
        db.PaymentTypes.Add(paymentType);
        db.SaveChanges();
        return Ok(paymentType);
    }

    [HttpGet]
    public ActionResult<IEnumerable<PaymentType>> Get(string? name)
    {
        var search = db.PaymentTypes.AsQueryable();
        if (name != null)
        {
            search = search.Where(x => EF.Functions.ILike(x.Name, $"%{name}%"));
        }

        var nat = search.ToList();
        return Ok(nat);
    }

    [HttpPut("{id}")]
    public ActionResult<PaymentType> Put(int id, PaymentType paymentType)
    {
        var old_owner = db.PaymentTypes.Find(id);
        if (paymentType != null)
        {
            NotFound();
        }

        old_owner.Name = paymentType.Name;
        db.SaveChanges();
        return Ok(paymentType);
    }

    [HttpDelete("{id}")]
    public ActionResult<PaymentType> Delete(int id)
    {
        var del_owner = db.PaymentTypes.Find(id);
        db.PaymentTypes.Remove(del_owner);
        db.SaveChanges();
        return Ok();
    }
}