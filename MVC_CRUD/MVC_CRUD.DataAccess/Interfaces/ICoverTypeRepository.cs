using MVC_CRUD.Models;

namespace MVC_CRUD.DataAccess.Interfaces
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType obj);
        void Save();
    }
}
