namespace Bugaltery.Model;

public class Resident
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    //Addressga ulsh
    public int AddressId { get; set; }
    public Address? Address { get; set; }
    
}