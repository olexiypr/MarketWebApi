using System.Threading;
using System.Threading.Tasks;

namespace Data.Interfaces;

public interface ISaveChanges
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}