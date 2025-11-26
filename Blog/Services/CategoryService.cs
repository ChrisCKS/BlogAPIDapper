using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryrepository)
        {
            _categoryRepository = categoryrepository;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task CreateCategoryAsync(CategoryRequestDTO category) 
        {
            var newCategory = new Category(category.Name, category.Name.ToLower().Replace(" ", " - ") );

            await _categoryRepository.CreateCategoryAsync(newCategory);
        }
    }
}
