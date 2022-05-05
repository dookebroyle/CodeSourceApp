using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class AdsBLL
    {
        AdsDAO dao = new AdsDAO();
        public void AddAd(AdsDTO model)
        {
            Ad ads = new Ad
            {
                ID = model.ID,
                Name = model.Name,
                ImagePath = model.ImagePath,
                Link = model.Link,
                Size = model.ImageSize,
                AddDate = DateTime.Now,
                LastUpdateUserID = UserStatic.UserID,
                LastUpdateDate = DateTime.Now
            };
            int ID = dao.AddAds(ads);
            LogDAO.AddLog(General.ProcessType.AdsAdd, General.TableName.Ads, model.ID);
        }

        public List<AdsDTO> GetAds()
        {
            return dao.GetAds();
        }

        public AdsDTO GetAdWithID(int iD)
        {
            return dao.GetAdWithID(iD);
        }

        public string UpdateAds(AdsDTO model)
        {
            string oldImagePath = dao.UpdateAds(model);
            
            LogDAO.AddLog(General.ProcessType.AdsUpdate, General.TableName.Ads, model.ID);
            return oldImagePath;
        }

        public void DeleteAd(int iD)
        {
            dao.DeleteAd(iD);
            LogDAO.AddLog(General.ProcessType.AdsDelete, General.TableName.Ads, iD);
        }
    }
}
