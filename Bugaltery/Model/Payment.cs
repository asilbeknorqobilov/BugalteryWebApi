using System.Runtime.InteropServices.JavaScript;

namespace Bugaltery.Model;

public class Payment
{
    public int Id { get; set; }
    //Ownerga ulash
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }

    //PaymentTypega ulash
    public int PaymentTypeId { get; set; }
    public PaymentType? PaymentType { get; set; }

    public DateTime DateTime { get; set; }
    public float PaymentAmount { get; set; }
}   