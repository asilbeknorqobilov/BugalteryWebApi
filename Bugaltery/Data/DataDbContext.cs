using Bugaltery.Model;
using Microsoft.EntityFrameworkCore;

namespace Bugaltery.Data;

public class DataDbContext:DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Resident> Residents { get; set; }
}