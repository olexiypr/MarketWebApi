using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IPersonDbContext : ISaveChanges
    {
        DbSet<Person> Persons { get; set; }
    }
}