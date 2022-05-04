using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VideoDAO : PostContext
    {
        public int AddVideo(Video video)
        {
            try
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return video.ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VideoDTO> GetVideos()
        {
            try
            {
                List<Video> list = db.Videos.Where(x => x.isDeleted == false).ToList();
                List<VideoDTO> dtolist = new List<VideoDTO>();
                foreach (var item in list)
                {
                    VideoDTO dto = new VideoDTO
                    {
                        ID = item.ID,
                        Title = item.Title,
                        VideoPath = item.VideoPath,
                        OriginalVideoPath = item.OriginalVideoPath,
                        AddDate = item.AddDate,
                        AddUserID = item.AddUserID
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

        public void UpdateVideo(VideoDTO model)
        {
            try
            {
                Video video = db.Videos.First(x => x.ID == model.ID);
                video.VideoPath = model.VideoPath;
                video.Title = model.Title;
                video.OriginalVideoPath = model.OriginalVideoPath;
                video.LastUpdateDate = DateTime.Now;
                video.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public VideoDTO GetVideoWithID(int iD)
        {
            Video video = db.Videos.First(x => x.ID == iD);
            VideoDTO videodto = new VideoDTO
            {
                ID = video.ID,
                VideoPath = video.VideoPath,
                Title = video.Title,
                OriginalVideoPath = video.OriginalVideoPath,
                AddDate = video.AddDate,
                AddUserID = video.AddUserID
            };
            return videodto;
        }


    }
}
