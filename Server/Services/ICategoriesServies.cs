using DTOs;

namespace Services
{
    public interface ICategoriesServies
    {
        Task<CategoryDTO> AddCategory(CategoryCreateDTO categoryCreate);
        Task<bool> DeleteCategory(int id);
        Task<List<CategoryDTO>> getCategories();
        Task<CategoryDTO> getCategoryById(int id);
        Task<CategoryDTO> UpdateCategory(int id, CategoryUpdateDTO categoryUpdate);
    }
}