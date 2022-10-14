using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IReceiptDbContext : ISaveChanges
    {
        DbSet<Receipt> Receipts { get; set; }
    }
}