using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface ICustomerDbContext : ISaveChanges
    {
        DbSet<Customer> Customers { get; set; }
    }
}