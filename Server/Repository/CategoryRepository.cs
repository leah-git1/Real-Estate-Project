using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _ShopContext;

        public CategoryRepository(ShopContext shopContext)
        {
            this._ShopContext = shopContext;
        }

        // החזרת כל הקטגוריות
        public async Task<List<Category>> getCategories()
        {
            return await _ShopContext.Categories.ToListAsync();
        }

        // החזרת קטגוריה לפי ID
        public async Task<Category> getCategoryById(int id)
        {
            return await _ShopContext.Categories
                .FirstOrDefaultAsync(c => c.CategoryId == id); // מחפש את הקטגוריה לפי ה-ID
        }

        // הוספת קטגוריה חדשה
        public async Task<Category> AddCategory(Category category)
        {
            await _ShopContext.Categories.AddAsync(category); // מוסיף את הקטגוריה למסד הנתונים
            await _ShopContext.SaveChangesAsync(); // שומר את השינויים
            return category; // מחזיר את הקטגוריה שהוזנה
        }

        // עדכון קטגוריה קיימת
        public async Task<Category> UpdateCategory(Category category)
        {
            _ShopContext.Categories.Update(category); // מעדכן את הקטגוריה
            await _ShopContext.SaveChangesAsync(); // שומר את השינויים
            return category; // מחזיר את הקטגוריה המעודכנת
        }

        // מחיקת קטגוריה לפי ID
        public async Task DeleteCategory(Category category)
        {
            _ShopContext.Categories.Remove(category); // מסיר את הקטגוריה מהמסד
            await _ShopContext.SaveChangesAsync(); // שומר את השינויים
        }
    }
}
