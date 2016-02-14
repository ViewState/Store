using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(String name = null);
        Category GetCategory(int id);
        Category GetCategory(String name);
        void CreateCategory(Category category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetCategories(String name = null)
        {
            if (String.IsNullOrEmpty(name))
                return _categoryRepository.GetAll();

            return _categoryRepository.GetAll().Where(c => c.Name == name);
        }

        public Category GetCategory(Int32 id) => _categoryRepository.GetById(id);

        public Category GetCategory(String name) => _categoryRepository.GetCategoryByName(name);

        public void CreateCategory(Category category) => _categoryRepository.Add(category);

        public void SaveCategory() => _unitOfWork.Commit();
    }

}
