using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IReceiptDetailsDbContext : ISaveChanges
    {
        DbSet<ReceiptDetail> ReceiptDetails { get; set; }
    }
}