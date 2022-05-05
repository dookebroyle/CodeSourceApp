using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BLL;
using System.Drawing;
using System.IO;

namespace UI.Areas.Admin.Controllers
{
    public class AdsController : Controller
    {
        AdsBLL bll = new AdsBLL();
        // GET: Admin/Ads
        public ActionResult AddAds()
        {
            AdsDTO dto = new AdsDTO();
            return View(dto);
        }
        [HttpPost]
        public ActionResult AddAds(AdsDTO model)
        {
            if(model.AdsImage == null)
            {
                ViewBag.ProcessState = General.Messages.ImageMissing;
            }
            else if (ModelState.IsValid)
            {
                string filename = "";
                HttpPostedFileBase postedfile = model.AdsImage;
                Bitmap AdsImage = new Bitmap(postedfile.InputStream);
                Bitmap resizeImage = new Bitmap(AdsImage, 128, 128);
                string ext = Path.GetExtension(postedfile.FileName).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                {
                    string uniquenumber = Guid.NewGuid().ToString();
                    filename = uniquenumber + postedfile.FileName;
                    AdsImage.Save(Server.MapPath("~/Areas/Admin/Content/AdImages/" + filename));
                    model.ImagePath = filename;
                    bll.AddAd(model);
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new AdsDTO();
                }
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            return View(model);
        }

        public ActionResult AdsList() 
        {
            List<AdsDTO> adslist = new List<AdsDTO>();
            adslist = bll.GetAds();
            return View(adslist);
        }

        public ActionResult UpdateAd(int ID)
        {
            AdsDTO dto = bll.GetAdWithID(ID);
            return View(dto);
        }
        [HttpPost]
        public ActionResult UpdateAd(AdsDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            else
            {
                if(model.AdsImage!= null)
                {
                    string filename = "";
                    HttpPostedFileBase postedfile = model.AdsImage;
                    Bitmap AdsImage = new Bitmap(postedfile.InputStream);
                    Bitmap resizeImage = new Bitmap(AdsImage, 128, 128);
                    string ext = Path.GetExtension(postedfile.FileName).ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                    {
                        string uniquenumber = Guid.NewGuid().ToString();
                        filename = uniquenumber + postedfile.FileName;
                        AdsImage.Save(Server.MapPath("~/Areas/Admin/Content/AdImages/" + filename));
                        model.ImagePath = filename;
                        bll.AddAd(model);
                        ViewBag.ProcessState = General.Messages.AddSuccess;
                        ModelState.Clear();
                        model = new AdsDTO();
                    }
                }
                string oldImagePath = bll.UpdateAds(model);
                if(model.AdsImage!= null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/AdImages/" + oldImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/AdImages/" + oldImagePath));
                    }
                }
                ViewBag.ProcessState = General.Messages.UpdateSuccess;
            }
            return View(model);
        }
        public JsonResult DeleteAds(int ID)
        {
            bll.DeleteAd(ID);
            return Json("");
        }
    }
}