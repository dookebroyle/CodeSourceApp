using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdsDAO : PostContext
    {
        public int AddAds(Ad ads)
        {
            try
            {
                db.Ads.Add(ads);
                db.SaveChanges();
                return ads.ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AdsDTO> GetAds()
        {
            try
            {
                List<Ad> list = db.Ads.Where(x => x.isDeleted == false).ToList();
                List<AdsDTO> dtolist = new List<AdsDTO>();
                foreach (var item in list)
                {
                    AdsDTO dto = new AdsDTO
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Link = item.Link,
                        ImagePath = item.ImagePath
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

        public AdsDTO GetAdWithID(int iD)
        {
            try
            {
                Ad ad = db.Ads.First(x => x.ID == iD);
                AdsDTO dto = new AdsDTO
                {
                    ID = ad.ID,
                    Name = ad.Name,
                    ImagePath = ad.ImagePath,
                    Link = ad.ImagePath,
                    ImageSize = ad.Size
                };
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteAd(int iD)
        {
            try
            {

                Ad ads = db.Ads.First(x => x.ID == iD);
                ads.isDeleted = true;
                ads.DeletedDate = DateTime.Now;
                ads.LastUpdateDate = DateTime.Now;
                ads.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateAds(AdsDTO model)
        {
            try
            {
                Ad ads = db.Ads.First(x => x.ID == model.ID);
                string oldImagePath = ads.ImagePath;
                ads.Name = model.Name;
                ads.Link = model.Link;
                ads.Size = model.ImageSize;
                ads.LastUpdateDate = DateTime.Now;
                ads.LastUpdateUserID = UserStatic.UserID;
                if (model.AdsImage != null)
                    ads.ImagePath = model.ImagePath;
                db.SaveChanges();
                return oldImagePath;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
