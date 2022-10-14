using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IProductCategoryDbContext : ISaveChanges
    {
        DbSet<ProductCategory> ProductCategories { get; set; }
    }
}