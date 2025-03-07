using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        RMSEntities Init();
    }
    public interface IConnectionString
    {
        string MyConnection();
    }
}
