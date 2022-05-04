using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BLL
{
    public class CategoryBLL
    {
        CategoryDAO dao = new CategoryDAO();
        public bool AddCategory(CategoryDTO model)
        {
            Category category = new Category
            {
                CategoryName = model.CategoryName,
                AddDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                LastUpdateUserID = UserStatic.UserID
            };
            int ID = dao.AddCategory(category);
            LogDAO.AddLog(General.ProcessType.CategoryAdd, General.TableName.Category, ID);
            return true;
        }

        public static IEnumerable<SelectListItem> GetCategoriesForDropDown()
        {
            return CategoryDAO.GetCategoriesForDropDown();
        }

        public List<CategoryDTO> GetCategories()
        {
            List<CategoryDTO> categorylist = dao.GetCategories();
            return categorylist;
        }

        public CategoryDTO FindCategoryByID(int iD)
        {
            CategoryDTO dto = dao.FindCategoryByID(iD);
            return dto;
        }

        public bool UpdateCategory(CategoryDTO model)
        {
            dao.UpdateCategory(model);
            LogDAO.AddLog(General.ProcessType.CategoryUpdate, General.TableName.Category, model.ID);
            return true;
        }
    }
}
