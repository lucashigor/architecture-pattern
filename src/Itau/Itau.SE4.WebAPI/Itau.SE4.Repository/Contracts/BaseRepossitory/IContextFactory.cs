using Microsoft.EntityFrameworkCore;

namespace Itau.SE4.Repository
{
    public interface IContextFactory
    {
        DbContext GetContext();
    }
}
