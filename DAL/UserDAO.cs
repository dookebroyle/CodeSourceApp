using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UserDAO:PostContext
    {
        public UserDTO GetUserWithUsernameAndPassword(UserDTO model)
        {
            UserDTO dto = new UserDTO();
            T_User user = db.T_User.First(x=>x.UserName == model.Username && x.Password == model.Password);
            if(user!=null && user.ID != 0)
            {
                dto.ID = user.ID;
                dto.Username = user.UserName;
                dto.Name = user.NameSurname;
                dto.ImagePath = user.ImagePath;
                dto.isAdmin = user.isAdmin;
            }
            return dto;
        }

        public int AddUser(T_User user)
        {
            try
            {
                db.T_User.Add(user);
                db.SaveChanges();
                return user.ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UserDTO> GetUsers()
        {

            List<T_User> list = db.T_User.Where(x => x.isDeleted == false || x.isDeleted == null).OrderBy(x=>x.AddDate).ToList();
            List<UserDTO> userlist = new List<UserDTO>();
            foreach (var item in list)
            {
                UserDTO dto = new UserDTO();
                dto.Name = item.NameSurname;
                dto.Username = item.UserName;
                dto.ID = item.ID;
                dto.ImagePath = item.ImagePath;
                dto.isDeleted = false;
                userlist.Add(dto);
            }
            return userlist;
        }

        public string DeleteUser(int iD)
        {
            try
            {
                T_User user = db.T_User.First(x => x.ID == iD);
                user.isDeleted = true;
                user.DeletedDate = DateTime.Now;
                user.LastUpdateDate = DateTime.Now;
                user.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                return user.ImagePath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdateUser(UserDTO model)
        {
            try
            {
                T_User user = db.T_User.First(x => x.ID == model.ID);
                string oldImagePath = user.ImagePath;
                user.NameSurname = model.Name;
                user.UserName = model.Username;
                if(model.ImagePath != null)
                {
                    user.ImagePath = model.ImagePath;
                }
                user.Email = model.Email;
                user.Password = model.Password;
                user.LastUpdateDate = DateTime.Now;
                user.LastUpdateUserID = UserStatic.UserID;
                user.isAdmin = model.isAdmin;
                db.SaveChanges();
                return oldImagePath;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserDTO GetUserWithID(int iD)
        {
            T_User user = db.T_User.First(x => x.ID == iD);
            UserDTO dto = new UserDTO
            {
                ID = user.ID,
                Name = user.NameSurname,
                Username = user.UserName,
                Password = user.Password,
                isAdmin = user.isAdmin,
                Email = user.Email,
                ImagePath = user.ImagePath,
            };
            return dto;
            
        }
    }
}
