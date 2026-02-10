using AutoMapper;
using DTOs;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriesServies : ICategoriesServies
    {
        ICategoryRepository _iCategoryRepository;
        IMapper _mapper;
        public CategoriesServies(ICategoryRepository iCategoryRepository, IMapper mapper)
        {
            this._iCategoryRepository = iCategoryRepository;
            this._mapper = mapper;
        }

        // פונקציה להחזרת כל הקטגוריות
        public async Task<List<CategoryDTO>> getCategories()
        {
            return await _iCategoryRepository.getCategories();
        }

        // פונקציה להחזרת קטגוריה לפי ID
        public async Task<CategoryDTO> getCategoryById(int id)
        {
            Category category = await _iCategoryRepository.getCategoryById(id);
            CategoryDTO categoryDTO = _mapper.Map<Category, CategoryDTO>(category);
            return categoryDTO;
        }

        // פונקציה להוספת קטגוריה
        public async Task<CategoryDTO> AddCategory(CategoryCreateDTO categoryCreate)
        {
            Category category = _mapper.Map<CategoryCreateDTO, Category>(categoryCreate);
            category = await _iCategoryRepository.AddCategory(category);
            CategoryDTO categoryDTO = _mapper.Map<Category, CategoryDTO>(category);
            return categoryDTO;
        }

        // פונקציה לעדכון קטגוריה
        public async Task<CategoryDTO> UpdateCategory(int id, CategoryUpdateDTO categoryUpdate)
        {
            Category category = _mapper.Map<CategoryUpdateDTO, Category>(categoryUpdate);
            category.CategoryId = id;
            category = await _iCategoryRepository.UpdateCategory(category, id);
            return _mapper.Map<Category, CategoryDTO>(category);
        }

        // פונקציה למחיקת קטגוריה
        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _iCategoryRepository.getCategoryById(id);

            if (category == null) return false;

            await _iCategoryRepository.DeleteCategory(category);
            return true;
        }


    }
}
