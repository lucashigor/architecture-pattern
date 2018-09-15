using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public interface IContextFactory
    {
        DbContext GetContext();
    }
}
