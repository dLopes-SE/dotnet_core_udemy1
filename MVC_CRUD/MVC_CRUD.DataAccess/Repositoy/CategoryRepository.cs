﻿using MVC_CRUD.Data;
using MVC_CRUD.DataAccess.Interfaces;
using MVC_CRUD.Models;

namespace MVC_CRUD.DataAccess.Repositoy
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
