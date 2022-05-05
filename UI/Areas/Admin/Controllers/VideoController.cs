using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class VideoController : Controller
    {
        VideoBLL bll = new VideoBLL();
        // GET: Admin/Video
        public ActionResult AddVideo()
        {
            VideoDTO model = new VideoDTO();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddVideo(VideoDTO model)
        {

            //< iframe width = "560" height = "315" src = "https://www.youtube.com/embed/e2H15MCOvm8" title = "YouTube video player" frameborder = "0" allow = "accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen ></ iframe >
            //    https://www.youtube.com/watch?v=e2H15MCOvm8
            if (ModelState.IsValid)
            {
                string path = model.OriginalVideoPath.Substring(32);
                string mergelink = "https://www.youtube.com/embed/";
                mergelink += path;
                model.VideoPath = String.Format(@"< iframe width = ""560"" height = ""315"" src = ""{0}"" title = ""YouTube video player"" frameborder = ""0"" allow = ""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></ iframe >", mergelink);
                if (bll.AddVideo(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new VideoDTO();
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            return View(model);
        }

        public ActionResult VideoList()
        {
            List<VideoDTO> model = bll.GetVideos();
            return View(model);
        }

        public ActionResult UpdateVideo(int ID)
        {
            VideoDTO model = bll.GetVideoWithID(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateVideo(VideoDTO model)
        {
            if (ModelState.IsValid)
            {
                string path = model.OriginalVideoPath.Substring(32);
                string mergelink = "https://www.youtube.com/embed/";
                mergelink += path;
                model.VideoPath = String.Format(@"< iframe width = ""560"" height = ""315"" src = ""{0}"" title = ""YouTube video player"" frameborder = ""0"" allow = ""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen ></ iframe >", mergelink);

                if (bll.UpdateVideo(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                    ModelState.Clear();
                    model = new VideoDTO();
                    
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }

            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            return View(model);
        }

        public JsonResult DeleteVideo(int ID)
        {
            bll.DeleteVideo(ID);
            return Json("");
        }
    }
}