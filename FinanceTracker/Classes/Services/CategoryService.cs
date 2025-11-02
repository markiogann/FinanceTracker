using System;
using System.Collections.Generic;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;

namespace FinanceTracker.Classes.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo = new CategoryRepository();

        public List<Category> GetAll(bool includeDeleted = false) => _repo.GetAll(includeDeleted);
        public Category GetById(int id) => _repo.GetById(id);
        public Category GetByName(string name) => _repo.GetByName(name);

        public bool ExistsByName(string name, int? excludeId = null) => _repo.ExistsByName(name, excludeId);

        public int Create(string name) => _repo.Create(name);
        public int CreateCategory(string name) => _repo.Create(name);

        public void Update(int id, string newName) => _repo.Update(id, newName);
        public void UpdateName(int id, string newName) => _repo.Update(id, newName);
        public void RenameCategory(int id, string newName) => _repo.Update(id, newName);

        public void DeleteMany(IEnumerable<int> ids) => _repo.DeleteMany(ids);
        public void SoftDeleteMany(IEnumerable<int> ids) => _repo.SoftDeleteMany(ids);

        public int EnsureDefaultOther() => _repo.EnsureDefaultOther();
    }
}
