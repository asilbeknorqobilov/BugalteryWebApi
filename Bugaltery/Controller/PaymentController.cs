using Bugaltery.Data;
using Bugaltery.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bugaltery.Controller;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private DataDbContext db;

    public PaymentController(DataDbContext dataDbContext)
    {
        db = dataDbContext;
    }

    [HttpPost]
    public ActionResult<Payment> Post(Payment payment)
    {
        db.Payments.Add(payment);
        db.SaveChanges();
        return Ok(payment);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Payment>> Get(float? paymentAmount)
    {
        var search = db.Payments.AsQueryable();

        if ((paymentAmount != null) && (paymentAmount > 0))
        {
            search = search.Where(x => x.PaymentAmount == paymentAmount);
        }

        var nat = search.ToList();
        return Ok(nat);
    }

    [HttpPut("{id}")]
    public ActionResult<Payment> Put(int id, [FromBody] Payment payment)
    {
        if (payment == null)
        {
            NotFound();
        }

        var old_payment = db.Payments.Find(id);

        if (old_payment == null)
        {
            return NotFound();
        }
        
        old_payment.OwnerId = payment.OwnerId;
        old_payment.PaymentTypeId = payment.PaymentTypeId;
        old_payment.DateTime = payment.DateTime;
        old_payment.PaymentAmount = payment.PaymentAmount;
        db.SaveChanges();
        return Ok(payment);
    }

    [HttpDelete("{id}")]
    public ActionResult<Payment> Delete(int id)
    {
        var pay_del = db.Payments.Find(id);
        db.Payments.Remove(pay_del);
        db.SaveChanges();
        return Ok();
    }
}