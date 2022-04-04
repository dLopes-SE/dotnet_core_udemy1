using MVC_CRUD.Models;

namespace MVC_CRUD.DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        void Save();
    }
}
