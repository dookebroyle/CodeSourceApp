﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SocialMediaDAO : PostContext
    {
        public int AddSocialMedia(SocialMedia social)
        {
            try
            {
                db.SocialMedias.Add(social);
                db.SaveChanges();
                return social.ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SocialMediaDTO> GetSocialMedias()
        {
            try
            {
                List<SocialMedia> list = db.SocialMedias.Where(x => x.isDeleted == false).ToList();
                List<SocialMediaDTO> dtolist = new List<SocialMediaDTO>();

                foreach( var item in list)
                {
                    SocialMediaDTO dto = new SocialMediaDTO();
                    dto.Name = item.Name;
                    dto.Link = item.Link;
                    dto.ImagePath = item.ImagePath;
                    dto.ID = item.ID;
                    dtolist.Add(dto);
                }
                return dtolist;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SocialMediaDTO GetSocialMediaWithID(int iD)
        {
            try
            {
                SocialMedia socialmedia = db.SocialMedias.First(x => x.ID == iD);
                SocialMediaDTO dto = new SocialMediaDTO();
                dto.ID = socialmedia.ID;
                dto.Name = socialmedia.Name;
                dto.Link = socialmedia.Link;
                dto.ImagePath = socialmedia.ImagePath;
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
                
                
        }

        public string UpdateSocialMedia(SocialMediaDTO model)
        {
            try
            {
                SocialMedia social = db.SocialMedias.First(x => x.ID == model.ID);
                string oldImagePath = social.ImagePath;
                social.Name = model.Name;
                social.Link = model.Link;
                if (model.ImagePath != null)
                {
                    social.ImagePath = model.ImagePath;
                }
                social.LastUpdateDate = DateTime.Now;
                social.LastUpdateUserID = UserStatic.UserID;
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
