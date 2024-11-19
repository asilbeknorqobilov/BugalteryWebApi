namespace Bugaltery.Model;

public class Address
{
    public int Id { get; set; }
    public string District { get; set; }
    public string Quarter { get; set; }
    public int Building { get; set; }
    public int Apartment { get; set; }
    //Ownerga ulash
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }
}