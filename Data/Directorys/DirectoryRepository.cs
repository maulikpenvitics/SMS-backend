 
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Directorys
{
     public class DirectoryRepository : RepositoryBase<Directory>, IDirectoryRepository
    {
        public DirectoryRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
    public interface IDirectoryRepository : IRepository<Directory>
    {

    }
}
   


