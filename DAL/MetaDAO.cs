﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MetaDAO : PostContext
    {
        public int AddMeta(Meta meta)
        {
            try
            {
                db.Metas.Add(meta);
                db.SaveChanges();
                return meta.ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MetaDTO> GetMetaData()
        {
            List<MetaDTO> metalist = new List<MetaDTO>();
            List<Meta> list = db.Metas.Where(x=>x.isDeleted == false).OrderBy(x=>x.AddDate).ToList();
            foreach(var item in list)
            {
                MetaDTO dto = new MetaDTO();
                dto.MetaID = item.ID;
                dto.Name = item.Name;
                dto.MetaContent = item.MetaContent;
                metalist.Add(dto);
            }
            return metalist;
            foreach (var item in metalist)
            {
                Console.WriteLine(item.MetaID);
            }
        }

        public MetaDTO GetMetaWithID(int iD)
        {
            try
            {
                Meta meta = db.Metas.First(x => x.ID == iD);
                MetaDTO dto = new MetaDTO();
                dto.MetaID = meta.ID;
                dto.Name = meta.Name;
                dto.MetaContent = meta.MetaContent;
                return dto;
                Console.WriteLine(dto.MetaID);
            }
            catch (Exception)
            {

                throw;
            }
   
        }

        public void UpdateMeta(MetaDTO model)
        {
            try
            {
                Meta meta = db.Metas.First(x => x.ID == model.MetaID);
                Console.WriteLine(meta.ID);
                meta.Name = model.Name;
                meta.MetaContent = model.MetaContent;
                meta.LastUpdateDate = DateTime.Now;
                meta.LastUpdateUserID = UserStatic.UserID;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}