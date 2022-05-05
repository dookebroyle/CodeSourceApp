using DTO;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL
{
    public class CategoryDAO : PostContext
    {
        public int AddCategory(Category category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return category.ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CategoryDTO> GetCategories()
        {
            try
            {
                List<Category> list = db.Categories.Where(x => x.isDeleted == false).ToList();
                List<CategoryDTO> dtolist = new List<CategoryDTO>();
                foreach (var item in list)
                {
                    CategoryDTO dto = new CategoryDTO
                    {
                        ID = item.ID,
                        CategoryName = item.CategoryName,
                        AddDate = item.AddDate
                    };
                    dtolist.Add(dto);
                }
                return dtolist;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static IEnumerable<SelectListItem> GetCategoriesForDropDown()
        {
            IEnumerable<SelectListItem> categorylist = db.Categories
                .Where(x => x.isDeleted == false)
                .OrderByDescending(x => x.AddDate)
                .Select(x => new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = SqlFunctions.StringConvert((double)x.ID)
                }).ToList();
            return categorylist;
        }

        public List<Post> DeleteCategory(int iD)
        {
            try
            {
                Category ct = db.Categories.First(x => x.ID == iD);
                ct.isDeleted = true;
                ct.DeletedDate = DateTime.Now;
                ct.LastUpdateDate = DateTime.Now;
                ct.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                List<Post> postlist = db.Posts.Where(x => x.isDeleted == false && x.CategoryID == iD).ToList();

                return postlist;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateCategory(CategoryDTO model)
        {
            try
            {
                Category category = db.Categories.First(x => x.ID == model.ID);
                category.CategoryName = model.CategoryName;
                category.LastUpdateDate = DateTime.Now;
                category.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CategoryDTO FindCategoryByID(int iD)
        {
            try
            {
                Category category = db.Categories.First(x => x.ID == iD);
                CategoryDTO dto = new CategoryDTO
                {
                    ID = category.ID,
                    CategoryName = category.CategoryName,
                    AddDate = category.AddDate
                };

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
