using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IProductDbContext : ISaveChanges
    {
        DbSet<Product> Products { get; set; }
    }
}